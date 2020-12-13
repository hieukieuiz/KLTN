using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services.TestOnline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.TestOnline
{
    public class BaiThiService : IBaiThiService
    {
        private readonly IRepository<BaiThi> _baiThiRepository;
        private readonly IRepository<DeThi> _deThiRepository;
        private readonly IRepository<ChiTietBaiThi> _chiTietBaiThiRepository;
        public BaiThiService(IRepository<BaiThi> baiThiRepository,
                             IRepository<ChiTietBaiThi> chiTietBaiThiRepository,
                             IRepository<DeThi> deThiRepository)
        {
            _baiThiRepository = baiThiRepository;
            _chiTietBaiThiRepository = chiTietBaiThiRepository;
            _deThiRepository = deThiRepository;
        }
        public IQueryable<BaiThi> GetBaiThi(string keywords, int deThiId)
        {
            var query = _baiThiRepository.TableUntracked
                                         .Include(x => x.UngVien)
                                         .Where(x => x.DeThiId == deThiId)
                                         .OrderByDescending(x=>x.TongDiemCham.Value)
                                         .AsQueryable();
            if (!string.IsNullOrEmpty(keywords))
            {
                query = query.Where(x => x.UngVien.HoTen.ToLower().Contains(keywords.ToLower())
                                      || x.TaiKhoan.ToLower().Contains(keywords.ToLower()));
            }
            return query;
        }
        public int DemCauTracNghiemDaLam(int baiThiId)
        {
            return _chiTietBaiThiRepository.TableUntracked
                .Include(x => x.CauHoi)
                .ThenInclude(x => x.DangCauHoi)
                .Count(x => !x.CauHoi.DangCauHoi.TenDangCauHoi.ToLower().Contains("text") && x.BaiThiId == baiThiId);
        }

        public int DemCauTuLuanDaLam(int baiThiId)
        {
            return _chiTietBaiThiRepository.TableUntracked
                .Include(x => x.CauHoi)
                .ThenInclude(x => x.DangCauHoi)
                .Count(x => x.CauHoi.DangCauHoi.TenDangCauHoi.ToLower().Contains("text") && x.BaiThiId == baiThiId);
        }

        public int DemCauTuLuanChuaCham(int baiThiId)
        {
            return _chiTietBaiThiRepository.TableUntracked
                .Include(x => x.CauHoi)
                .ThenInclude(x => x.DangCauHoi)
                .Count(x => x.CauHoi.DangCauHoi.TenDangCauHoi.ToLower().Contains("text") && x.BaiThiId == baiThiId && x.DiemCham == null);
        }

        public double? TinhDiemCham(int baiThiId)
        {
            return _chiTietBaiThiRepository.TableUntracked
               .Where(x => x.BaiThiId == baiThiId).Sum(x => x.DiemCham);
        }
        public async Task ScanBaiThi(int deThiId)
        {
            var deThi = _deThiRepository.TableUntracked
                                        .Include(x => x.BaiThi)
                                        .FirstOrDefault(x => x.Id == deThiId);
            var lstBaiThi = deThi.BaiThi.ToList();
            var thoiGianLamBai = deThi.ThoiGianLamBai;
            if (thoiGianLamBai.HasValue)
            {
                foreach (var baiThi in lstBaiThi)
                {
                    var thoiGianBatDauLam = baiThi.ThoiGianTao;
                    var thoiGianDaLam = (int)Math.Floor(DateTime.Now.Subtract(thoiGianBatDauLam).TotalSeconds);

                    if (thoiGianDaLam >= thoiGianLamBai * 60)
                    {
                        if (!baiThi.DaNopBai)
                        {
                            baiThi.ThoiGianHoanThanh = baiThi.ThoiGianTao.AddMinutes(thoiGianLamBai.Value);
                            baiThi.DaNopBai = true;
                            await _baiThiRepository.UpdateAsync(baiThi);
                        }
                    }
                }
            }
        }
    }
}
