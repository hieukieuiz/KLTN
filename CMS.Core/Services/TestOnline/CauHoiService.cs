using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Extensions;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using CMS.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace CMS.Core.Services
{
    public class CauHoiService : ICauHoiService
    {
        private readonly IRepository<CauHoi> _cauHoiRepository;
        private readonly IRepository<DapAnCauHoi> _dapAnCauHoiRepository;
        private readonly IRepository<KhoCauHoi> _khoCauHoiRepository;
        public CauHoiService(IRepository<CauHoi> cauHoiRepository,
            IRepository<DapAnCauHoi> dapAnCauHoiRepository,
            IRepository<KhoCauHoi> khoCauHoiRepository)
        {
            _cauHoiRepository = cauHoiRepository;
            _dapAnCauHoiRepository = dapAnCauHoiRepository;
            _khoCauHoiRepository = khoCauHoiRepository;
        }
        public IQueryable<CauHoi> GetCauHoi(
                                            string keywords,
                                            int? dangCauHoiId = null,
                                            int? loaiCauHoiId = null,
                                            int? mucDoId = null)
        {
            var query = _cauHoiRepository.TableUntracked
                                         .Include(x => x.DangCauHoi)
                                         .Include(x => x.KhoCauHoi)
                                         .Include(x => x.MucDo)
                                         .AsNoTracking();

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(cauHoi =>
                        cauHoi.TenCauHoi.Contains(keywords) ||
                        cauHoi.KyHieu.Contains(keywords)
                    );
            }
            if (dangCauHoiId.HasValue)
            {
                query = query.Where(x => x.DangCauHoiId == dangCauHoiId);
            }
            if (loaiCauHoiId.HasValue)
            {
                query = query.Where(x => x.KhoCauHoiId == loaiCauHoiId);
            }
            if (mucDoId.HasValue)
            {
                query = query.Where(x => x.MucDoId == mucDoId);
            }
            return query;
        }

        public async Task<CauHoi> GetCauHoiById(int id)
        {
            return await _cauHoiRepository.TableUntracked
                                          .Include(x => x.DangCauHoi)
                                          .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ServiceResult> CreateCauHoi(CauHoi cauHoi)
        {
            if (_cauHoiRepository.TableUntracked.Any(x => x.KyHieu == cauHoi.KyHieu))
                return ServiceResult.Failed("Ký hiệu đã được sử dụng");
            var lstDapAn = cauHoi.DapAnCauHoi;
            cauHoi.DapAnCauHoi = null;
            await _cauHoiRepository.AddAsync(cauHoi);
            if (!lstDapAn.IsNullOrEmpty())
            {
                foreach (var dapAn in lstDapAn)
                {
                    dapAn.CauHoiId = cauHoi.Id;
                    await _dapAnCauHoiRepository.AddAsync(dapAn);
                }
            }
            return ServiceResult.Success;
        }
        public async Task UpdateCauHoi(CauHoi cauHoi)
        {
            if (cauHoi.DapAnCauHoi.IsNullOrEmpty())
            {
                var danhSachDapAnHienTai = _dapAnCauHoiRepository.TableUntracked
                    .Where(x => x.CauHoiId == cauHoi.Id);
                await _dapAnCauHoiRepository.DeleteRangeAsync(danhSachDapAnHienTai);
            }
            else
            {
                var danhSachDapAnHienTai = _dapAnCauHoiRepository.TableUntracked
                    .Where(x => x.CauHoiId == cauHoi.Id).ToList();
                var danhSachDapAnDelete = new List<DapAnCauHoi>();
                foreach (var dapAn in danhSachDapAnHienTai)
                {
                    if (!cauHoi.DapAnCauHoi.Any(x => x.Id == dapAn.Id))
                    {
                        danhSachDapAnDelete.Add(dapAn);
                    }
                    else
                    {
                        var dapAnMoi = cauHoi.DapAnCauHoi.FirstOrDefault(x => x.Id == dapAn.Id);
                        dapAn.TenDapAn = dapAnMoi.TenDapAn;
                        dapAn.GiaTri = dapAnMoi.GiaTri;
                        dapAn.ThuTu = dapAnMoi.ThuTu;
                        dapAn.CauHoi = null;
                        await _dapAnCauHoiRepository.UpdateAsync(dapAn);
                    }
                }
                await _dapAnCauHoiRepository.DeleteRangeAsync(danhSachDapAnDelete);
                foreach (var dapAn in cauHoi.DapAnCauHoi)
                {
                    if (!danhSachDapAnHienTai.Any(x => x.Id == dapAn.Id))
                    {
                        dapAn.CauHoi = null;
                        dapAn.CauHoiId = cauHoi.Id;
                        await _dapAnCauHoiRepository.AddAsync(dapAn);
                    }
                }
            }
            cauHoi.DapAnCauHoi = null;
            await _cauHoiRepository.UpdateAsync(cauHoi);
        }
        public async Task DeleteCauHoi(int id)
        {
            var cauHoi = await _cauHoiRepository.GetByIdAsync(id);
            await _cauHoiRepository.DeleteAsync(cauHoi);
        }
        public async Task<string> GetSuggestKyHieu(int khoCauHoiId)
        {
            var khoCauHoi = await _khoCauHoiRepository.TableUntracked
                                        .FirstOrDefaultAsync(x => x.Id == khoCauHoiId);
            var lstCauHoi = _cauHoiRepository.TableUntracked
                                               .Where(x => x.KhoCauHoiId == khoCauHoiId)?
                                               .Select(x => x.KyHieu)
                                               .ToList();
            string kyHieu = khoCauHoi.KyHieuKho;
            if (lstCauHoi.Count != 0)
            {
                var lstTemp = new List<int>();
                lstCauHoi.ForEach(x =>
                {
                    int so = int.Parse(x.Trim().Substring(khoCauHoi.KyHieuKho.Trim().Length));
                    lstTemp.Add(so);
                });
                int currMax = lstTemp.Max();
                string nextMax = (currMax + 1).ToString();
                if (currMax < 9)
                {
                    kyHieu = kyHieu + "000" + nextMax;
                }
                else if (currMax < 99)
                {
                    kyHieu = kyHieu + "00" + nextMax;
                }
                else if (currMax < 999)
                {
                    kyHieu = kyHieu + "0" + nextMax;
                }
                else
                {
                    kyHieu = kyHieu + nextMax;
                }
            }
            else kyHieu = kyHieu + "0001";
            return kyHieu;
        }
    }
}