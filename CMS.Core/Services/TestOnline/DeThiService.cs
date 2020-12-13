using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Enums;
using CMS.Core.Extensions;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using CMS.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace CMS.Core.Services
{
    public class DeThiService : IDeThiService
    {
        private readonly IRepository<DeThi> _deThiRepository;
        private readonly IRepository<HienThiDeThi> _hienThiDeThiRepository;
        private readonly IRepository<NguonDeThi> _nguonDeThiRepository;
        private readonly IRepository<ChiTietBaiThi> _chiTietBaiThiRepository;
        private readonly IRepository<BaiThi> _baiThiRepository;
        private readonly IRepository<ChiTietDeThi> _chiTietDeThiRepository;
        private readonly IRepository<CauHoi> _cauHoiRepository;
        private readonly IRepository<ChiTietDapAnDeThi> _chiTietDapAnDeThiRepository;
        private readonly IRepository<CauHinhDoKho> _cauHinhDoKhoRepository;
        //private readonly IRepository<HocVien> _hocVienRepository;
        public DeThiService(IRepository<DeThi> deThiRepository,
            IRepository<ChiTietBaiThi> chiTietBaiThiRepository,
            IRepository<BaiThi> baiThiRepository,
            IRepository<ChiTietDeThi> chiTietDeThiRepository,
            IRepository<HienThiDeThi> hienThiDeThiRepository,
            IRepository<NguonDeThi> nguonDeThiRepository,
            IRepository<CauHoi> cauHoiRepository,
            IRepository<ChiTietDapAnDeThi> chiTietDapAnDeThiRepository,
            IRepository<CauHinhDoKho> cauHinhDoKhoRepository)
            //IRepository<HocVien> hocVienRepository)
        {
            _deThiRepository = deThiRepository;
            _chiTietBaiThiRepository = chiTietBaiThiRepository;
            _baiThiRepository = baiThiRepository;
            _chiTietDeThiRepository = chiTietDeThiRepository;
            _hienThiDeThiRepository = hienThiDeThiRepository;
            _nguonDeThiRepository = nguonDeThiRepository;
            _cauHoiRepository = cauHoiRepository;
            _chiTietDapAnDeThiRepository = chiTietDapAnDeThiRepository;
            _cauHinhDoKhoRepository = cauHinhDoKhoRepository;
            //_hocVienRepository = hocVienRepository;
        }
        public IQueryable<DeThi> GetDeThi(string keywords,
            DateTime? tuNgayTao = null,
            DateTime? denNgayTao = null,
            int? linhVucThiId = null,
            int? tuSoBaiNop = null,
            int? denSoBaiNop = null,
            bool? daXuatBan = null)
        {
            var query = _deThiRepository.TableUntracked
                                        .Include(x => x.LinhVucThi)
                                        .Include(x => x.BaiThi)
                                        //.ThenInclude(x => x.HocVien)
                                        .AsNoTracking();
            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(x => x.TenDeThi.Contains(keywords));
            }
            if (linhVucThiId.HasValue)
            {
                query = query.Where(x => x.LinhVucThiId == linhVucThiId);
            }
            if (tuNgayTao.HasValue)
            {
                query = query.Where(x => x.NgayTao >= tuNgayTao);
            }
            if (denNgayTao.HasValue)
            {
                query = query.Where(x => x.NgayTao <= denNgayTao);
            }
            if (daXuatBan.HasValue)
            {
                query = query.Where(x => x.IsActive == daXuatBan);
            }
            if (tuSoBaiNop.HasValue)
            {
                query = query.Where(x => _baiThiRepository.TableUntracked.Count(y => y.DeThiId == x.Id) >= tuSoBaiNop);
            }
            if (denSoBaiNop.HasValue)
            {
                query = query.Where(x => _baiThiRepository.TableUntracked.Count(y => y.DeThiId == x.Id) >= denSoBaiNop);
            }
            return query.OrderByDescending(x => x.Id);
        }

        public async Task<DeThi> GetChiTietDeThi(int id)
        {
            return await _deThiRepository
                .TableUntracked
                .Include(x => x.ChiTietDeThi)
                .ThenInclude(x => x.CauHoi)
                .ThenInclude(x => x.DapAnCauHoi)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<DeThi> GetDeThiById(int id)
        {
            return await _deThiRepository
                .TableUntracked
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<DeThi> GetDeThiByMetaUrl(string metaUrl)
        {
            return await _deThiRepository
                .TableUntracked
                .FirstOrDefaultAsync(x => x.MetaUrl.ToLower() == metaUrl.ToLower());
        }
        public async Task<DeThi> GetThongTinCaiDatDeThiById(int id)
        {
            return await _deThiRepository
                .TableUntracked
                .Include(x => x.ChiTietDeThi)
                .ThenInclude(x => x.CauHoi)
                .Include(x => x.HienThiDeThi)
                .Include(x => x.NguonDeThi)
                .Include(x => x.CauHinhDoKho)
                .ThenInclude(x => x.MucDo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ServiceResult> CreateDeThi(DeThi deThi)
        {
            var lstNguonDeThi = deThi.NguonDeThi;
            var lstKhoCauHoiId = lstNguonDeThi.ToList().Select(x => x.KhoCauHoiId);
            var queryCauHoi = _cauHoiRepository.TableUntracked
                               .Include(x => x.DapAnCauHoi)
                               .Where(x => lstKhoCauHoiId.Contains(x.KhoCauHoiId.Value))?
                               .ToList();
            if (deThi.SoCau > queryCauHoi.Count) return ServiceResult.Failed("Số câu trong đề thi vượt quá số lượng câu hỏi trong kho");
            var lstCauHinhDoKho = deThi.CauHinhDoKho;
            var lstHienThiDeThi = deThi.HienThiDeThi;
            var lstCauHoi = deThi.ChiTietDeThi;
            deThi.HienThiDeThi = null;
            deThi.CauHinhDoKho = null;
            deThi.NguonDeThi = null;
            deThi.ChiTietDeThi = null;
            deThi.HienThiSoThuTu = true;
            deThi.IsActive = true;
            deThi.NgayTao = DateTime.Now;
            deThi.Guid = Guid.NewGuid();
            if (deThi.LaVoHanHieuLuc) deThi.ThoiGianHieuLuc = null;
            deThi.TrangThaiXuatBan = (int)TrangThaiDeThi.DA_XUAT_BAN;
            // _deThiRepository.AutoCommitEnabled = false;
            await _deThiRepository.AddAsync(deThi);
            if (!deThi.IsShowPublic)
            {
                if (!lstHienThiDeThi.IsNullOrEmpty())
                {
                    foreach (var hienThi in lstHienThiDeThi)
                    {
                        hienThi.DeThiId = deThi.Id;
                        await _hienThiDeThiRepository.AddAsync(hienThi);
                    }
                }
            }
            if (!lstNguonDeThi.IsNullOrEmpty())
            {
                foreach (var nguonDeThi in lstNguonDeThi)
                {
                    nguonDeThi.DeThiId = deThi.Id;
                    await _nguonDeThiRepository.AddAsync(nguonDeThi);
                }
            }
            if (deThi.PhuongThucTao == 1)//Ngẫu nhiên + đảo đáp án
            {
                if (!queryCauHoi.IsNullOrEmpty())
                {
                    var lstIndexCauHoiRandom = new List<int>();
                    for (int i = 0; i < deThi.SoCau; i++)
                    {
                        var random = new Random();
                        int idxRandom;
                        do
                        {
                            idxRandom = random.Next(0, queryCauHoi.Count);
                        } while (lstIndexCauHoiRandom.Contains(idxRandom));
                        lstIndexCauHoiRandom.Add(idxRandom);
                        var chiTietDeThi = new ChiTietDeThi()
                        {
                            DeThiId = deThi.Id,
                            CauHoiId = queryCauHoi[idxRandom].Id,
                            BatBuocTraLoi = false,
                            HienThiSoThuTu = true,
                            DiemToiDa = 1,
                            DaoDapAn = true,
                            ThuTu = i + 1
                        };
                        await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                        var lstDapAn = queryCauHoi[idxRandom].DapAnCauHoi.Select(da => da.Id).ToList();
                        if (lstDapAn.Count > 0)
                        {
                            var lstThuTuRandom = new List<int>();
                            for (int j = 0; j < lstDapAn.Count; j++)
                            {
                                int idxThuTuRandom;
                                do
                                {
                                    idxThuTuRandom = random.Next(0, lstDapAn.Count());
                                } while (lstThuTuRandom.Contains(idxThuTuRandom));
                                lstThuTuRandom.Add(idxThuTuRandom);
                                var thuTuDapAnMoi = new ChiTietDapAnDeThi()
                                {
                                    ChiTietDeThiId = chiTietDeThi.Id,
                                    DapAnCauHoiId = lstDapAn[idxThuTuRandom],
                                    ThuTuMoi = idxThuTuRandom + 1
                                };
                                await _chiTietDapAnDeThiRepository.AddAsync(thuTuDapAnMoi);
                            }
                        }
                    }
                }
            }
            else if (deThi.PhuongThucTao == 2)//Ngẫu nhiên theo độ khó
            {
                if (!lstCauHinhDoKho.IsNullOrEmpty())
                {
                    if (!queryCauHoi.IsNullOrEmpty())
                    {
                        var lstError = new List<string>();
                        foreach (var doKho in lstCauHinhDoKho)
                        {

                            var soCauHoiHienTai = queryCauHoi.Count(x => x.MucDoId == doKho.MucDoId);
                            if (doKho.SoLuongCauHoi.Value > soCauHoiHienTai)
                            {
                                lstError.Add($"Số lượng câu hỏi \"{doKho.MucDo.TenMucDo}\" không hợp lệ");
                            }
                        }
                        if (lstError.Count != 0) return ServiceResult.Failed(lstError.ToArray());
                        var random = new Random();
                        int thuTu = 1;
                        foreach (var doKho in lstCauHinhDoKho)
                        {
                            doKho.DeThiId = deThi.Id;
                            doKho.MucDo = null;
                            await _cauHinhDoKhoRepository.AddAsync(doKho);
                            var lstCauHoiTheoDoKho = queryCauHoi.Where(x => x.MucDoId == doKho.MucDoId).ToList();
                            if (!lstCauHoiTheoDoKho.IsNullOrEmpty())
                            {
                                var lstIndexCauHoiRandom = new List<int>();
                                for (int i = 0; i < doKho.SoLuongCauHoi; i++)
                                {
                                    int idxRandom;
                                    do
                                    {
                                        idxRandom = random.Next(0, lstCauHoiTheoDoKho.Count);
                                    } while (lstIndexCauHoiRandom.Contains(idxRandom));
                                    lstIndexCauHoiRandom.Add(idxRandom);
                                    var chiTietDeThi = new ChiTietDeThi()
                                    {
                                        DeThiId = deThi.Id,
                                        CauHoiId = lstCauHoiTheoDoKho[idxRandom].Id,
                                        BatBuocTraLoi = false,
                                        HienThiSoThuTu = true,
                                        DiemToiDa = doKho.Diem,
                                        DaoDapAn = doKho.DaoDapAn,
                                        ThuTu = thuTu
                                    };
                                    await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                                    if (doKho.DaoDapAn)
                                    {
                                        var lstDapAn = lstCauHoiTheoDoKho[idxRandom].DapAnCauHoi.Select(da => da.Id).ToList();
                                        if (lstDapAn.Count > 0)
                                        {
                                            var lstThuTuRandom = new List<int>();
                                            for (int j = 0; j < lstDapAn.Count; j++)
                                            {
                                                int idxThuTuRandom;
                                                do
                                                {
                                                    idxThuTuRandom = random.Next(0, lstDapAn.Count());
                                                } while (lstThuTuRandom.Contains(idxThuTuRandom));
                                                lstThuTuRandom.Add(idxThuTuRandom);
                                                var thuTuDapAnMoi = new ChiTietDapAnDeThi()
                                                {
                                                    ChiTietDeThiId = chiTietDeThi.Id,
                                                    DapAnCauHoiId = lstDapAn[idxThuTuRandom],
                                                    ThuTuMoi = idxThuTuRandom + 1
                                                };
                                                await _chiTietDapAnDeThiRepository.AddAsync(thuTuDapAnMoi);
                                            }
                                        }
                                    }
                                    thuTu += 1;
                                }
                            }
                            else break;
                        }
                    }
                    else return ServiceResult.Failed("Chưa có câu hỏi nào thuộc kho đề trên");
                }

            }
            else if (deThi.PhuongThucTao == 3)//Tùy chỉnh
            {
                if (!lstCauHoi.IsNullOrEmpty())
                {
                    foreach (var cauHoi in lstCauHoi)
                    {
                        cauHoi.DeThiId = deThi.Id;
                        await _chiTietDeThiRepository.AddAsync(cauHoi);
                    }
                }
            }
            // await _deThiRepository.CommitAsync();
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> LuuNhapDeThi(DeThi deThi)
        {
            var lstNguonDeThi = deThi.NguonDeThi;
            var lstKhoCauHoiId = lstNguonDeThi.ToList().Select(x => x.KhoCauHoiId);
            var queryCauHoi = _cauHoiRepository.TableUntracked
                               .Include(x => x.DapAnCauHoi)
                               .Where(x => lstKhoCauHoiId.Contains(x.KhoCauHoiId.Value))?
                               .ToList();
            if (deThi.SoCau > queryCauHoi.Count) return ServiceResult.Failed("Số câu trong đề thi vượt quá số lượng câu hỏi trong kho");
            var lstCauHinhDoKho = deThi.CauHinhDoKho;
            var lstHienThiDeThi = deThi.HienThiDeThi;
            var lstCauHoi = deThi.ChiTietDeThi;
            deThi.HienThiDeThi = null;
            deThi.CauHinhDoKho = null;
            deThi.NguonDeThi = null;
            deThi.ChiTietDeThi = null;
            deThi.HienThiSoThuTu = true;
            deThi.IsActive = false;
            deThi.NgayTao = DateTime.Now;
            deThi.Guid = Guid.NewGuid();
            if (deThi.LaVoHanHieuLuc) deThi.ThoiGianHieuLuc = null;
            deThi.TrangThaiXuatBan = (int)TrangThaiDeThi.LUU_NHAP;
            // _deThiRepository.AutoCommitEnabled = false;
            await _deThiRepository.AddAsync(deThi);
            if (!deThi.IsShowPublic)
            {
                if (!lstHienThiDeThi.IsNullOrEmpty())
                {
                    foreach (var hienThi in lstHienThiDeThi)
                    {
                        hienThi.DeThiId = deThi.Id;
                        await _hienThiDeThiRepository.AddAsync(hienThi);
                    }
                }
            }
            if (!lstNguonDeThi.IsNullOrEmpty())
            {
                foreach (var nguonDeThi in lstNguonDeThi)
                {
                    nguonDeThi.DeThiId = deThi.Id;
                    await _nguonDeThiRepository.AddAsync(nguonDeThi);
                }
            }
            if (deThi.PhuongThucTao == 1)//Ngẫu nhiên + đảo đáp án
            {
                if (!queryCauHoi.IsNullOrEmpty())
                {
                    var lstIndexCauHoiRandom = new List<int>();
                    for (int i = 0; i < deThi.SoCau; i++)
                    {
                        var random = new Random();
                        int idxRandom;
                        do
                        {
                            idxRandom = random.Next(0, queryCauHoi.Count);
                        } while (lstIndexCauHoiRandom.Contains(idxRandom));
                        lstIndexCauHoiRandom.Add(idxRandom);
                        var chiTietDeThi = new ChiTietDeThi()
                        {
                            DeThiId = deThi.Id,
                            CauHoiId = queryCauHoi[idxRandom].Id,
                            BatBuocTraLoi = false,
                            HienThiSoThuTu = true,
                            DiemToiDa = 1,
                            DaoDapAn = true,
                            ThuTu = i + 1
                        };
                        await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                        var lstDapAn = queryCauHoi[idxRandom].DapAnCauHoi.Select(da => da.Id).ToList();
                        if (lstDapAn.Count > 0)
                        {
                            var lstThuTuRandom = new List<int>();
                            for (int j = 0; j < lstDapAn.Count; j++)
                            {
                                int idxThuTuRandom;
                                do
                                {
                                    idxThuTuRandom = random.Next(0, lstDapAn.Count());
                                } while (lstThuTuRandom.Contains(idxThuTuRandom));
                                lstThuTuRandom.Add(idxThuTuRandom);
                                var thuTuDapAnMoi = new ChiTietDapAnDeThi()
                                {
                                    ChiTietDeThiId = chiTietDeThi.Id,
                                    DapAnCauHoiId = lstDapAn[idxThuTuRandom],
                                    ThuTuMoi = idxThuTuRandom + 1
                                };
                                await _chiTietDapAnDeThiRepository.AddAsync(thuTuDapAnMoi);
                            }
                        }
                    }
                }
            }
            else if (deThi.PhuongThucTao == 2)//Ngẫu nhiên theo độ khó
            {
                if (!lstCauHinhDoKho.IsNullOrEmpty())
                {
                    if (!queryCauHoi.IsNullOrEmpty())
                    {
                        var lstError = new List<string>();
                        foreach (var doKho in lstCauHinhDoKho)
                        {

                            var soCauHoiHienTai = queryCauHoi.Count(x => x.MucDoId == doKho.MucDoId);
                            if (doKho.SoLuongCauHoi.Value > soCauHoiHienTai)
                            {
                                lstError.Add($"Số lượng câu hỏi \"{doKho.MucDo.TenMucDo}\" không hợp lệ");
                            }
                        }
                        if (lstError.Count != 0) return ServiceResult.Failed(lstError.ToArray());
                        var random = new Random();
                        int thuTu = 1;
                        foreach (var doKho in lstCauHinhDoKho)
                        {
                            doKho.DeThiId = deThi.Id;
                            doKho.MucDo = null;
                            await _cauHinhDoKhoRepository.AddAsync(doKho);
                            var lstCauHoiTheoDoKho = queryCauHoi.Where(x => x.MucDoId == doKho.MucDoId).ToList();
                            if (!lstCauHoiTheoDoKho.IsNullOrEmpty())
                            {
                                var lstIndexCauHoiRandom = new List<int>();
                                for (int i = 0; i < doKho.SoLuongCauHoi; i++)
                                {
                                    int idxRandom;
                                    do
                                    {
                                        idxRandom = random.Next(0, lstCauHoiTheoDoKho.Count);
                                    } while (lstIndexCauHoiRandom.Contains(idxRandom));
                                    lstIndexCauHoiRandom.Add(idxRandom);
                                    var chiTietDeThi = new ChiTietDeThi()
                                    {
                                        DeThiId = deThi.Id,
                                        CauHoiId = lstCauHoiTheoDoKho[idxRandom].Id,
                                        BatBuocTraLoi = false,
                                        HienThiSoThuTu = true,
                                        DiemToiDa = doKho.Diem,
                                        DaoDapAn = doKho.DaoDapAn,
                                        ThuTu = thuTu
                                    };
                                    await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                                    if (doKho.DaoDapAn)
                                    {
                                        var lstDapAn = lstCauHoiTheoDoKho[idxRandom].DapAnCauHoi.Select(da => da.Id).ToList();
                                        if (lstDapAn.Count > 0)
                                        {
                                            var lstThuTuRandom = new List<int>();
                                            for (int j = 0; j < lstDapAn.Count; j++)
                                            {
                                                int idxThuTuRandom;
                                                do
                                                {
                                                    idxThuTuRandom = random.Next(0, lstDapAn.Count());
                                                } while (lstThuTuRandom.Contains(idxThuTuRandom));
                                                lstThuTuRandom.Add(idxThuTuRandom);
                                                var thuTuDapAnMoi = new ChiTietDapAnDeThi()
                                                {
                                                    ChiTietDeThiId = chiTietDeThi.Id,
                                                    DapAnCauHoiId = lstDapAn[idxThuTuRandom],
                                                    ThuTuMoi = idxThuTuRandom + 1
                                                };
                                                await _chiTietDapAnDeThiRepository.AddAsync(thuTuDapAnMoi);
                                            }
                                        }
                                    }
                                    thuTu += 1;
                                }
                            }
                            else break;
                        }
                    }
                    else return ServiceResult.Failed("Chưa có câu hỏi nào thuộc kho đề trên");
                }

            }
            else if (deThi.PhuongThucTao == 3)//Tùy chỉnh
            {
                if (!lstCauHoi.IsNullOrEmpty())
                {
                    foreach (var cauHoi in lstCauHoi)
                    {
                        cauHoi.DeThiId = deThi.Id;
                        await _chiTietDeThiRepository.AddAsync(cauHoi);
                    }
                }
            }
            // await _deThiRepository.CommitAsync();
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateDeThi(DeThi deThi)
        {
            if (deThi.TrangThaiXuatBan == (int)TrangThaiDeThi.LUU_NHAP)
            {
                var lstKhoCauHoiId = deThi.NguonDeThi.ToList().Select(x => x.KhoCauHoiId);
                var queryCauHoi = _cauHoiRepository.TableUntracked
                                   .Include(x => x.DapAnCauHoi)
                                   .Where(x => lstKhoCauHoiId.Contains(x.KhoCauHoiId.Value))?
                                   .ToList();
                if (deThi.SoCau > queryCauHoi.Count)
                    return ServiceResult.Failed("Số câu trong đề thi vượt quá số lượng câu hỏi trong kho");

                //Update nguồn đề thi

                if (deThi.NguonDeThi.IsNullOrEmpty())
                {
                    var lstNguonDeThiHienTai = _nguonDeThiRepository.TableUntracked
                        .Where(x => x.DeThiId == deThi.Id).AsEnumerable();
                    await _nguonDeThiRepository.DeleteRangeAsync(lstNguonDeThiHienTai);
                }
                else
                {
                    var lstNguonDeThiHienTai = _nguonDeThiRepository.TableUntracked
                        .Where(x => x.DeThiId == deThi.Id).ToList();
                    var danhSachNguonDeThiDelete = new List<NguonDeThi>();
                    foreach (var nguonDeThi in lstNguonDeThiHienTai)
                    {
                        if (!deThi.NguonDeThi.Any(x => x.KhoCauHoiId == nguonDeThi.KhoCauHoiId))
                        {
                            danhSachNguonDeThiDelete.Add(nguonDeThi);
                        }
                    }
                    await _nguonDeThiRepository.DeleteRangeAsync(danhSachNguonDeThiDelete);
                    foreach (var nguonDeThi in deThi.NguonDeThi)
                    {
                        if (!lstNguonDeThiHienTai.Any(x => x.KhoCauHoiId == nguonDeThi.KhoCauHoiId))
                        {
                            nguonDeThi.DeThiId = deThi.Id;
                            await _nguonDeThiRepository.AddAsync(nguonDeThi);
                        }
                    }
                }

                if (deThi.PhuongThucTao == 1)
                {
                    await DeleteChiTietDeThi(deThi.Id);
                    if (!queryCauHoi.IsNullOrEmpty())
                    {
                        var lstIndexCauHoiRandom = new List<int>();
                        for (int i = 0; i < deThi.SoCau; i++)
                        {
                            var random = new Random();
                            int idxRandom;
                            do
                            {
                                idxRandom = random.Next(0, queryCauHoi.Count);
                            } while (lstIndexCauHoiRandom.Contains(idxRandom));
                            lstIndexCauHoiRandom.Add(idxRandom);
                            var chiTietDeThi = new ChiTietDeThi()
                            {
                                DeThiId = deThi.Id,
                                CauHoiId = queryCauHoi[idxRandom].Id,
                                BatBuocTraLoi = false,
                                HienThiSoThuTu = true,
                                DiemToiDa = 1,
                                DaoDapAn = true,
                                ThuTu = i + 1
                            };
                            await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                            var lstDapAn = queryCauHoi[idxRandom].DapAnCauHoi.Select(da => da.Id).ToList();
                            if (lstDapAn.Count > 0)
                            {
                                var lstThuTuRandom = new List<int>();
                                for (int j = 0; j < lstDapAn.Count; j++)
                                {
                                    int idxThuTuRandom;
                                    do
                                    {
                                        idxThuTuRandom = random.Next(0, lstDapAn.Count());
                                    } while (lstThuTuRandom.Contains(idxThuTuRandom));
                                    lstThuTuRandom.Add(idxThuTuRandom);
                                    var thuTuDapAnMoi = new ChiTietDapAnDeThi()
                                    {
                                        ChiTietDeThiId = chiTietDeThi.Id,
                                        DapAnCauHoiId = lstDapAn[idxThuTuRandom],
                                        ThuTuMoi = idxThuTuRandom + 1
                                    };
                                    await _chiTietDapAnDeThiRepository.AddAsync(thuTuDapAnMoi);
                                }
                            }
                        }
                    }
                }


                if (deThi.PhuongThucTao == 2)
                {
                    //Xóa chi tiết đề thi hiện tại
                    await DeleteChiTietDeThi(deThi.Id);

                    //Update cấu hình độ khó
                    if (deThi.CauHinhDoKho.IsNullOrEmpty())
                    {
                        var lstCauHinhDoKhoHienTai = _cauHinhDoKhoRepository.TableUntracked
                            .Where(x => x.DeThiId == deThi.Id).AsEnumerable();
                        await _cauHinhDoKhoRepository.DeleteRangeAsync(lstCauHinhDoKhoHienTai);
                    }
                    else
                    {
                        var lstCauHinhDoKhoHienTai = _cauHinhDoKhoRepository.TableUntracked
                            .Where(x => x.DeThiId == deThi.Id).ToList();
                        var danhSachCHDKDelete = new List<CauHinhDoKho>();
                        foreach (var cauHinh in lstCauHinhDoKhoHienTai)
                        {
                            if (!deThi.CauHinhDoKho.Any(x => x.Id == cauHinh.Id))
                            {
                                danhSachCHDKDelete.Add(cauHinh);
                            }
                            else
                            {
                                var cauHinhMoi = deThi.CauHinhDoKho.FirstOrDefault(x => x.Id == cauHinh.Id);
                                cauHinh.MucDoId = cauHinhMoi.MucDoId;
                                cauHinh.SoLuongCauHoi = cauHinhMoi.SoLuongCauHoi;
                                cauHinh.Diem = cauHinhMoi.Diem;
                                cauHinh.DaoDapAn = cauHinhMoi.DaoDapAn;
                                cauHinh.MucDo = null;
                                await _cauHinhDoKhoRepository.UpdateAsync(cauHinh);
                            }
                        }
                        await _cauHinhDoKhoRepository.DeleteRangeAsync(danhSachCHDKDelete);
                        foreach (var cauHinh in deThi.CauHinhDoKho)
                        {
                            if (!lstCauHinhDoKhoHienTai.Any(x => x.Id == cauHinh.Id))
                            {
                                cauHinh.DeThiId = deThi.Id;
                                await _cauHinhDoKhoRepository.AddAsync(cauHinh);
                            }
                        }
                    }

                    //Gen câu hỏi
                    if (!deThi.CauHinhDoKho.IsNullOrEmpty())
                    {
                        if (!queryCauHoi.IsNullOrEmpty())
                        {
                            var lstError = new List<string>();
                            foreach (var doKho in deThi.CauHinhDoKho)
                            {

                                var soCauHoiHienTai = queryCauHoi.Count(x => x.MucDoId == doKho.MucDoId);
                                if (doKho.SoLuongCauHoi.Value > soCauHoiHienTai)
                                {
                                    lstError.Add($"Số lượng câu hỏi \"{doKho.MucDo.TenMucDo}\" không hợp lệ");
                                }
                            }
                            if (lstError.Count != 0) return ServiceResult.Failed(lstError.ToArray());
                            var random = new Random();
                            int thuTu = 1;
                            foreach (var doKho in deThi.CauHinhDoKho)
                            {
                                var lstCauHoiTheoDoKho = queryCauHoi.Where(x => x.MucDoId == doKho.MucDoId).ToList();
                                if (!lstCauHoiTheoDoKho.IsNullOrEmpty())
                                {
                                    var lstIndexCauHoiRandom = new List<int>();
                                    for (int i = 0; i < doKho.SoLuongCauHoi; i++)
                                    {
                                        int idxRandom;
                                        do
                                        {
                                            idxRandom = random.Next(0, lstCauHoiTheoDoKho.Count);
                                        } while (lstIndexCauHoiRandom.Contains(idxRandom));
                                        lstIndexCauHoiRandom.Add(idxRandom);
                                        var chiTietDeThi = new ChiTietDeThi()
                                        {
                                            DeThiId = deThi.Id,
                                            CauHoiId = lstCauHoiTheoDoKho[idxRandom].Id,
                                            BatBuocTraLoi = false,
                                            HienThiSoThuTu = true,
                                            DiemToiDa = doKho.Diem,
                                            DaoDapAn = doKho.DaoDapAn,
                                            ThuTu = thuTu
                                        };
                                        await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                                        if (doKho.DaoDapAn)
                                        {
                                            var lstDapAn = lstCauHoiTheoDoKho[idxRandom].DapAnCauHoi.Select(da => da.Id).ToList();
                                            if (lstDapAn.Count > 0)
                                            {
                                                var lstThuTuRandom = new List<int>();
                                                for (int j = 0; j < lstDapAn.Count; j++)
                                                {
                                                    int idxThuTuRandom;
                                                    do
                                                    {
                                                        idxThuTuRandom = random.Next(0, lstDapAn.Count());
                                                    } while (lstThuTuRandom.Contains(idxThuTuRandom));
                                                    lstThuTuRandom.Add(idxThuTuRandom);
                                                    var thuTuDapAnMoi = new ChiTietDapAnDeThi()
                                                    {
                                                        ChiTietDeThiId = chiTietDeThi.Id,
                                                        DapAnCauHoiId = lstDapAn[idxThuTuRandom],
                                                        ThuTuMoi = idxThuTuRandom + 1
                                                    };
                                                    await _chiTietDapAnDeThiRepository.AddAsync(thuTuDapAnMoi);
                                                }
                                            }
                                        }
                                        thuTu += 1;
                                    }
                                }
                                else break;
                            }
                        }
                        else return ServiceResult.Failed("Chưa có câu hỏi nào thuộc kho đề trên");
                    }

                }
                //Update câu hỏi
                if (deThi.PhuongThucTao == 3)
                {
                    if (deThi.ChiTietDeThi.IsNullOrEmpty())
                    {
                        var danhSachCauHoiHienTai = _chiTietDeThiRepository.TableUntracked
                            .Where(x => x.DeThiId == deThi.Id);
                        await _chiTietDeThiRepository.DeleteRangeAsync(danhSachCauHoiHienTai);
                    }
                    else
                    {
                        var danhSachCauHoiHienTai = _chiTietDeThiRepository.TableUntracked
                            .Where(x => x.DeThiId == deThi.Id).ToList();
                        var danhSachCauHoiDelete = new List<ChiTietDeThi>();
                        foreach (var chiTietDeThi in danhSachCauHoiHienTai)
                        {
                            if (!deThi.ChiTietDeThi.Any(x => x.Id == chiTietDeThi.Id))
                            {
                                danhSachCauHoiDelete.Add(chiTietDeThi);
                            }
                            else
                            {
                                var chiTietDeThiMoi = deThi.ChiTietDeThi.FirstOrDefault(x => x.Id == chiTietDeThi.Id);
                                chiTietDeThi.BatBuocTraLoi = false;
                                chiTietDeThi.HienThiSoThuTu = true;
                                chiTietDeThi.CauHoiId = chiTietDeThiMoi.CauHoiId;
                                chiTietDeThi.ThuTu = chiTietDeThiMoi.ThuTu;
                                chiTietDeThi.PhuThuocVaoCauHoiId = chiTietDeThiMoi.PhuThuocVaoCauHoiId;
                                chiTietDeThi.GiaTriPhuThuoc = chiTietDeThiMoi.GiaTriPhuThuoc;
                                chiTietDeThi.DiemToiDa = chiTietDeThiMoi.DiemToiDa;
                                chiTietDeThi.DaoDapAn = chiTietDeThiMoi.DaoDapAn;
                                chiTietDeThi.CauHoi = null;
                                await _chiTietDeThiRepository.UpdateAsync(chiTietDeThi);
                            }
                        }
                        await _chiTietDeThiRepository.DeleteRangeAsync(danhSachCauHoiDelete);
                        foreach (var chiTietDeThi in deThi.ChiTietDeThi)
                        {
                            if (!danhSachCauHoiHienTai.Any(x => x.Id == chiTietDeThi.Id))
                            {
                                chiTietDeThi.CauHoi = null;
                                chiTietDeThi.DeThiId = deThi.Id;
                                chiTietDeThi.BatBuocTraLoi = false;
                                chiTietDeThi.HienThiSoThuTu = true;
                                await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
                            }
                        }
                    }
                }
            }

            //Update hiển thị đề thi
            if (!deThi.IsShowPublic)
            {
                if (deThi.HienThiDeThi.IsNullOrEmpty())
                {
                    var lstHienThiDeThiHienTai = _hienThiDeThiRepository.TableUntracked
                        .Where(x => x.DeThiId == deThi.Id).AsEnumerable();
                    await _hienThiDeThiRepository.DeleteRangeAsync(lstHienThiDeThiHienTai);
                }
                else
                {
                    var lstHienThiDeThiHienTai = _hienThiDeThiRepository.TableUntracked
                        .Where(x => x.DeThiId == deThi.Id).ToList();
                    var danhSachHienThiDeThiDelete = new List<HienThiDeThi>();
                    foreach (var hienThi in lstHienThiDeThiHienTai)
                    {
                        if (!deThi.HienThiDeThi.Any(x => x.KhoaHocId == hienThi.KhoaHocId))
                        {
                            danhSachHienThiDeThiDelete.Add(hienThi);
                        }
                    }
                    await _hienThiDeThiRepository.DeleteRangeAsync(danhSachHienThiDeThiDelete);
                    foreach (var hienThi in deThi.HienThiDeThi)
                    {
                        if (!lstHienThiDeThiHienTai.Any(x => x.KhoaHocId == hienThi.KhoaHocId))
                        {
                            hienThi.DeThiId = deThi.Id;
                            await _hienThiDeThiRepository.AddAsync(hienThi);
                        }
                    }
                }
            }
            else
            {
                var lstHienThiDeThiHienTai = _hienThiDeThiRepository.TableUntracked
                        .Where(x => x.DeThiId == deThi.Id).AsEnumerable();
                await _hienThiDeThiRepository.DeleteRangeAsync(lstHienThiDeThiHienTai);
            }

            deThi.ChiTietDeThi = null;
            deThi.HienThiDeThi = null;
            deThi.NguonDeThi = null;
            deThi.CauHinhDoKho = null;
            await _deThiRepository.UpdateAsync(deThi);
            return ServiceResult.Success;
        }
        public async Task DeleteDeThi(int id)
        {
            var deThi = await _deThiRepository.GetByIdAsync(id);
            await DeleteChiTietDeThi(id);
            await _deThiRepository.DeleteAsync(deThi);
        }
        public async Task DeleteChiTietDeThi(int deThiId)
        {
            var lstChiTietDeThi = _chiTietDeThiRepository.TableUntracked
                                                         .Where(x => x.DeThiId == deThiId)
                                                         .AsEnumerable();
            foreach (var chiTietDeThi in lstChiTietDeThi.ToList())
            {
                var lstChiTietDaoDapAn = _chiTietDapAnDeThiRepository.TableUntracked
                                         .Where(x => x.ChiTietDeThiId == chiTietDeThi.Id).AsEnumerable();
                await _chiTietDapAnDeThiRepository.DeleteRangeAsync(lstChiTietDaoDapAn);
            }
            await _chiTietDeThiRepository.DeleteRangeAsync(lstChiTietDeThi);
        }
        public async Task<ServiceResult> UpdateCauTraLoi(int deThiId,
                                            string taiKhoan,
                                            ChiTietBaiThi cauTraLoi)
        {
            if (_deThiRepository.TableUntracked.Any(x => x.Id == deThiId && x.IsActive))
            {
                var baiThi = await _baiThiRepository.TableUntracked
                    .Include(x => x.ChiTietBaiThi)
                    .FirstOrDefaultAsync(x => x.DeThiId == deThiId && x.TaiKhoan == taiKhoan);
                if (baiThi != null)
                {
                    var cauTraLoiOld = baiThi.ChiTietBaiThi.FirstOrDefault(x => x.CauHoiId == cauTraLoi.CauHoiId);
                    if (cauTraLoiOld != null)
                    {
                        cauTraLoiOld.CauTraLoi = cauTraLoi.CauTraLoi;
                        await _chiTietBaiThiRepository.UpdateAsync(cauTraLoiOld);
                    }
                    else
                    {
                        var cauTraLoiNew = new ChiTietBaiThi()
                        {
                            CauHoiId = cauTraLoi.CauHoiId,
                            CauTraLoi = cauTraLoi.CauTraLoi,
                            BaiThiId = baiThi.Id
                        };
                        await _chiTietBaiThiRepository.AddAsync(cauTraLoiNew);
                    }
                    baiThi.ThoiGianHoanThanh = DateTime.Now;
                    await _baiThiRepository.UpdateAsync(baiThi);
                }
                else
                {
                    var baiThiMoi = new BaiThi()
                    {
                        DeThiId = deThiId,
                        TaiKhoan = taiKhoan,
                        ThoiGianTao = DateTime.Now,
                        ThoiGianHoanThanh = DateTime.Now
                    };
                    await _baiThiRepository.AddAsync(baiThiMoi);
                    cauTraLoi.BaiThiId = baiThiMoi.Id;
                    await _chiTietBaiThiRepository.AddAsync(cauTraLoi);
                }
                return ServiceResult.Success;
            }
            else return ServiceResult.Failed("Đề thi không tồn tại");
        }
        public async Task<ServiceResult> NopBaiThi(int deThiId,
                                            string taiKhoan,
                                            ChiTietBaiThi cauTraLoi)
        {
            if (_deThiRepository.TableUntracked.Any(x => x.Id == deThiId && x.IsActive))
            {
                var baiThi = await _baiThiRepository.TableUntracked
                    .Include(x => x.ChiTietBaiThi)
                    .FirstOrDefaultAsync(x => x.DeThiId == deThiId && x.TaiKhoan == taiKhoan);
                if (baiThi != null)
                {
                    var cauTraLoiOld = baiThi.ChiTietBaiThi.FirstOrDefault(x => x.CauHoiId == cauTraLoi.CauHoiId);
                    if (cauTraLoiOld != null)
                    {
                        cauTraLoiOld.CauTraLoi = cauTraLoi.CauTraLoi;
                        await _chiTietBaiThiRepository.UpdateAsync(cauTraLoiOld);
                    }
                    else
                    {
                        var cauTraLoiNew = new ChiTietBaiThi()
                        {
                            CauHoiId = cauTraLoi.CauHoiId,
                            CauTraLoi = cauTraLoi.CauTraLoi,
                            BaiThiId = baiThi.Id
                        };
                        await _chiTietBaiThiRepository.AddAsync(cauTraLoiNew);
                    }
                    baiThi.ThoiGianHoanThanh = DateTime.Now;
                    baiThi.DaNopBai = true;
                    await _baiThiRepository.UpdateAsync(baiThi);
                }
                else
                {
                    var baiThiMoi = new BaiThi()
                    {
                        DeThiId = deThiId,
                        TaiKhoan = taiKhoan,
                        ThoiGianTao = DateTime.Now,
                        ThoiGianHoanThanh = DateTime.Now,
                        DaNopBai = true
                    };
                    await _baiThiRepository.AddAsync(baiThiMoi);
                    cauTraLoi.BaiThiId = baiThiMoi.Id;
                    await _chiTietBaiThiRepository.AddAsync(cauTraLoi);
                }
                return ServiceResult.Success;
            }
            else return ServiceResult.Failed("Đề thi không tồn tại");
        }
        public async Task<BaiThi> GetKetQuaBaiThi(int deThiId, string taiKhoan)
        {
            var baiThi = await _baiThiRepository.TableUntracked
                //.Include(x => x.HocVien)
                .Include(x => x.DeThi)
                .Include(x => x.ChiTietBaiThi)
                .FirstOrDefaultAsync(x => x.DeThiId == deThiId
                && x.TaiKhoan == taiKhoan);
            return baiThi;
        }
        public async Task<int> GetThoiGianLamBai(int deThiId, string taiKhoan)
        {
            if (_deThiRepository.TableUntracked.Any(x => x.Id == deThiId && x.IsActive))
            {
                if (!_baiThiRepository.TableUntracked.Any(x => x.DeThiId == deThiId && x.TaiKhoan == taiKhoan))
                {
                    var baiThiMoi = new BaiThi()
                    {
                        DeThiId = deThiId,
                        TaiKhoan = taiKhoan,
                        ThoiGianTao = DateTime.Now,
                        ThoiGianHoanThanh = DateTime.Now
                    };
                    await _baiThiRepository.AddAsync(baiThiMoi);
                }
                var thoiGianLamBai = _deThiRepository.TableUntracked
                                            .FirstOrDefault(x => x.Id == deThiId)
                                            .ThoiGianLamBai;
                DateTime thoiGianBatDauLam = _baiThiRepository.TableUntracked
                                            .FirstOrDefault(x => x.DeThiId == deThiId
                                                              && x.TaiKhoan == taiKhoan)
                                            .ThoiGianTao;
                var thoiGianDaLam = (int)Math.Floor(DateTime.Now.Subtract(thoiGianBatDauLam).TotalSeconds);
                if (thoiGianLamBai.HasValue)
                {
                    if (thoiGianDaLam < thoiGianLamBai * 60)
                        return thoiGianLamBai.Value * 60 - thoiGianDaLam;
                    else return 0;
                }
                else return 0;
            }
            else return 0;
        }
        public async Task<TrangThaiDeThi> CheckTrangThaiDeThi(int deThiId, string taiKhoan)
        {
            if (_deThiRepository.TableUntracked.Any(x => x.Id == deThiId && x.IsActive))
            {
                var deThi = await _deThiRepository.TableUntracked
                                            .FirstOrDefaultAsync(x => x.Id == deThiId);
                if (!deThi.IsShowPublic)
                {
                    var dsKhoaHocHienThi = _hienThiDeThiRepository.TableUntracked
                                                           .Where(x => x.DeThiId == deThiId)
                                                           .Select(x => x.KhoaHocId)
                                                           .ToList();
                    //var hocVien = _hocVienRepository.TableUntracked
                    //                            //.Include(x => x.DangKyHoc)
                    //                            .FirstOrDefault(x => x.Account == taiKhoan);
                    //var lstKhoaHocDangKy = hocVien.DangKyHoc.Where(x => x.IsActive)
                    //                                        .Select(x => x.KhoaHocId)
                    //                                        .ToList();
                    //if (!dsKhoaHocHienThi.Any(x => lstKhoaHocDangKy.Contains(x.Value)))
                    //    return TrangThaiDeThi.KHONG_CO_QUYEN;
                }
                if (!_baiThiRepository.TableUntracked.Any(x => x.DeThiId == deThiId && x.TaiKhoan == taiKhoan))
                {
                    if (!deThi.LaVoHanHieuLuc && deThi.ThoiGianHieuLuc.HasValue && DateTime.Now.Date > deThi.ThoiGianHieuLuc.Value.Date)
                        return TrangThaiDeThi.CHUA_LAM_VA_DA_HET_HAN;
                    return TrangThaiDeThi.CHUA_LAM;
                }
                else
                {
                    var baiThi = _baiThiRepository.TableUntracked
                                                .FirstOrDefault(x => x.DeThiId == deThiId
                                                                  && x.TaiKhoan == taiKhoan);

                    if (baiThi.DaNopBai)
                    {
                        if (!deThi.LaVoHanHieuLuc && deThi.ThoiGianHieuLuc.HasValue && DateTime.Now.Date > deThi.ThoiGianHieuLuc.Value.Date)
                            return TrangThaiDeThi.DA_LAM_VA_DA_HET_HAN;
                        return TrangThaiDeThi.LAM_XONG;
                    }
                    else
                    {
                        if (!deThi.LaVoHanHieuLuc && deThi.ThoiGianHieuLuc.HasValue && DateTime.Now.Date > deThi.ThoiGianHieuLuc.Value.Date)
                            return TrangThaiDeThi.DA_LAM_VA_DA_HET_HAN;
                        var thoiGianLamBai = deThi.ThoiGianLamBai;
                        var thoiGianBatDauLam = baiThi.ThoiGianTao;
                        var thoiGianDaLam = (int)Math.Floor(DateTime.Now.Subtract(thoiGianBatDauLam).TotalSeconds);
                        if (thoiGianLamBai.HasValue)
                        {
                            if (thoiGianDaLam > 0 && thoiGianDaLam < thoiGianLamBai * 60)
                                return TrangThaiDeThi.DANG_LAM;
                            else if (thoiGianDaLam >= thoiGianLamBai * 60)
                            {
                                baiThi.DaNopBai = true;
                                await _baiThiRepository.UpdateAsync(baiThi);
                                return TrangThaiDeThi.LAM_XONG;
                            }
                            else return TrangThaiDeThi.CHUA_LAM;
                        }
                        else return TrangThaiDeThi.KHONG_TON_TAI;
                    }

                }

            }
            else return TrangThaiDeThi.KHONG_TON_TAI;
        }
        public TrangThaiDeThi CheckTrangThaiDeThiHocVien(int deThiId, string taiKhoan)
        {
            if (_deThiRepository.TableUntracked.Any(x => x.Id == deThiId && x.IsActive))
            {
                var deThi = _deThiRepository.TableUntracked
                                            .FirstOrDefault(x => x.Id == deThiId);
                //if (DateTime.Now.Date >= deThi.ThoiGianHieuLuc.Value.Date) return TrangThaiDeThi.DA_HET_HAN;
                if (!_baiThiRepository.TableUntracked.Any(x => x.DeThiId == deThiId && x.TaiKhoan == taiKhoan))
                {
                    return TrangThaiDeThi.CHUA_LAM;
                }
                else
                {
                    var baiThi = _baiThiRepository.TableUntracked
                                                .FirstOrDefault(x => x.DeThiId == deThiId
                                                                  && x.TaiKhoan == taiKhoan);

                    if (baiThi.DaNopBai) return TrangThaiDeThi.LAM_XONG;
                    else
                    {
                        var thoiGianLamBai = deThi.ThoiGianLamBai;
                        var thoiGianBatDauLam = baiThi.ThoiGianTao;
                        var thoiGianDaLam = (int)Math.Floor(DateTime.Now.Subtract(thoiGianBatDauLam).TotalSeconds);
                        if (thoiGianLamBai.HasValue)
                        {
                            if (thoiGianDaLam > 0 && thoiGianDaLam < thoiGianLamBai * 60)
                                return TrangThaiDeThi.DANG_LAM;
                            else if (thoiGianDaLam >= thoiGianLamBai * 60)
                            {
                                return TrangThaiDeThi.LAM_XONG;
                            }
                            else return TrangThaiDeThi.CHUA_LAM;
                        }
                        else return TrangThaiDeThi.CHUA_LAM;
                    }

                }

            }
            else return TrangThaiDeThi.KHONG_TON_TAI;
        }
        public async Task<ServiceResult> ChamDiemBaiThiTuDong(int deThiId, string taiKhoan)
        {
            if (_deThiRepository.TableUntracked.Any(x => x.Id == deThiId && x.IsActive))
            {
                var deThi = await _deThiRepository.TableUntracked
                                              .Include(x => x.ChiTietDeThi)
                                              .ThenInclude(x => x.CauHoi)
                                              .FirstOrDefaultAsync(x => x.Id == deThiId && x.IsActive);
                if (_baiThiRepository.TableUntracked.Any(x => x.DeThiId == deThiId && x.TaiKhoan == taiKhoan && x.DaNopBai))
                {
                    var baiThi = await _baiThiRepository.TableUntracked
                                        .Include(x => x.ChiTietBaiThi)
                                        .FirstOrDefaultAsync(x => x.DeThiId == deThiId
                                                               && x.TaiKhoan == taiKhoan);
                    //if (baiThi.DaChamDiem) return ServiceResult.Success;
                    var lstCauTraLoi = baiThi.ChiTietBaiThi.ToList();
                    foreach (var ans in lstCauTraLoi)
                    {
                        foreach (var quest in deThi.ChiTietDeThi.ToList())
                        {
                            if (ans.CauHoiId == quest.CauHoiId)
                            {
                                if (!string.IsNullOrEmpty(ans.CauTraLoi)
                                  && ans.CauTraLoi.ToLower() == quest.CauHoi.GiaTriDapAn.ToLower())
                                {
                                    ans.DiemCham = quest.DiemToiDa;
                                    await _chiTietBaiThiRepository.UpdateAsync(ans);
                                    break;
                                }
                                else
                                {
                                    ans.DiemCham = 0;
                                    await _chiTietBaiThiRepository.UpdateAsync(ans);
                                    break;
                                }
                            }
                        }
                    }
                    baiThi.DaChamDiem = true;
                    if (deThi.BaoNgayKetQua) baiThi.DaBaoKetQua = true;
                    baiThi.TongDiemCham = lstCauTraLoi.Sum(x => x.DiemCham);
                    baiThi.TongDiemToiDa = deThi.ChiTietDeThi.Sum(x => x.DiemToiDa);
                    baiThi.NgayCham = DateTime.Now;
                    baiThi.ChiTietBaiThi = null;
                    await _baiThiRepository.UpdateAsync(baiThi);
                    return ServiceResult.Success;
                }
                else return ServiceResult.Failed("Bạn chưa hoàn thành đề thi này!");
            }
            else return ServiceResult.Failed("Đề thi không tồn tại!");
        }
        public async Task<bool> CheckBaoKetQua(int deThiId, string taiKhoan)
        {
            var baiThi = await _baiThiRepository.TableUntracked
                                          .FirstOrDefaultAsync(x => x.DeThiId == deThiId
                                                                 && x.TaiKhoan == taiKhoan);
            return baiThi.DaNopBai && baiThi.DaChamDiem && baiThi.DaBaoKetQua;
        }
        public async Task UpdateDiemCham(ChiTietBaiThi chiTietBaiThi)
        {
            await _chiTietBaiThiRepository.UpdateAsync(chiTietBaiThi);
            var baiThi = _baiThiRepository.TableUntracked
                                          .Include(x => x.ChiTietBaiThi)
                                          .FirstOrDefault(x => x.Id == chiTietBaiThi.BaiThiId);
            baiThi.TongDiemCham = baiThi.ChiTietBaiThi.Sum(x => x.DiemCham);
            baiThi.NgayCham = DateTime.Now;
            baiThi.ChiTietBaiThi = null;
            await _baiThiRepository.UpdateAsync(baiThi);
        }
        public async Task BaoDiemManual(BaiThi baiThi)
        {
            baiThi.DaBaoKetQua = true;
            await _baiThiRepository.UpdateAsync(baiThi);
        }
        public IQueryable<DeThi> GetDanhSachDeThiHocVien(string keywords, string taiKhoan, int? linhVucThiId = null)
        {
            //var hocVien = _hocVienRepository.TableUntracked
            //                                    //.Include(x => x.DangKyHoc)
            //                                    .FirstOrDefault(x => x.Account == taiKhoan);
            //var lstKhoaHocDangKy = hocVien.DangKyHoc.Where(x => x.IsActive).Select(x => x.KhoaHocId).ToList();
            var queryAllDeThi = _deThiRepository.TableUntracked
                                        .Include(x => x.LinhVucThi)
                                        .Include(x => x.HienThiDeThi)
                                        .Where(x => x.IsActive);
            //queryAllDeThi = queryAllDeThi.Where(x => x.IsShowPublic
            //                                      || x.HienThiDeThi
            //                                          .Any(y =>
            //                                          lstKhoaHocDangKy.Contains(y.KhoaHocId.Value)));
            if (!keywords.IsNullOrEmpty())
            {
                queryAllDeThi = queryAllDeThi.Where(x => x.TenDeThi.ToLower().Contains(keywords.ToLower()));
            }
            if (linhVucThiId.HasValue)
            {
                queryAllDeThi = queryAllDeThi.Where(x => x.LinhVucThiId == linhVucThiId);
            }
            var query = queryAllDeThi.AsEnumerable().Select(x => new DeThi
            {
                Id = x.Id,
                Guid = x.Guid,
                TenDeThi = x.TenDeThi,
                LinhVucThiId = x.LinhVucThiId,
                MoTa = x.MoTa,
                ThoiGianHieuLuc = x.ThoiGianHieuLuc,
                LaVoHanHieuLuc = x.LaVoHanHieuLuc,
                ThoiGianLamBai = x.ThoiGianLamBai,
                SoCau = x.SoCau,
                LinhVucThi = x.LinhVucThi != null ? x.LinhVucThi : null
            });
            return query.AsQueryable();
        }
    }
}