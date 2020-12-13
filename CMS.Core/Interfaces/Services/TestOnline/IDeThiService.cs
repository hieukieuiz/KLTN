using CMS.Core.Entities;
using System;
using CMS.Core.Enums;
using CMS.Core.SharedKernel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDeThiService
    {
        public IQueryable<DeThi> GetDeThi(string keywords,
            DateTime? tuNgayTao,
            DateTime? denNgayTao,
            int? linhVucThiId = null,
            int? tuSOBaiNop = null,
            int? denSoBaiNop = null,
            bool? daXuatBan = null);
        public Task<DeThi> GetChiTietDeThi(int id);
        public Task<DeThi> GetDeThiById(int id);
        public Task<DeThi> GetDeThiByMetaUrl(string metaUrl);
        public Task<DeThi> GetThongTinCaiDatDeThiById(int id);
        public Task<ServiceResult> CreateDeThi(DeThi deThi);
        public Task<ServiceResult> LuuNhapDeThi(DeThi deThi);
        public Task<ServiceResult> UpdateDeThi(DeThi deThi);
        public Task DeleteDeThi(int id);
        public Task DeleteChiTietDeThi(int deThiId);
        public Task<int> GetThoiGianLamBai(int deThiId, string taiKhoan);
        public Task<ServiceResult> UpdateCauTraLoi(int deThiId, string taiKhoan, ChiTietBaiThi cauTraLoi);
        public Task<ServiceResult> NopBaiThi(int deThiId, string taiKhoan, ChiTietBaiThi cauTraLoi);
        public Task<BaiThi> GetKetQuaBaiThi(int deThiId, string taiKhoan);
        public Task<ServiceResult> ChamDiemBaiThiTuDong(int deThiId, string taiKhoan);
        public Task<TrangThaiDeThi> CheckTrangThaiDeThi(int deThiId, string taiKhoan);
        public TrangThaiDeThi CheckTrangThaiDeThiHocVien(int deThiId, string taiKhoan);
        public Task<bool> CheckBaoKetQua(int deThiId, string taiKhoan);
        public Task UpdateDiemCham(ChiTietBaiThi chiTietBaiThi);
        public Task BaoDiemManual(BaiThi baiThi);
        public IQueryable<DeThi> GetDanhSachDeThiHocVien(string keywords, string taiKhoan, int? linhVucThiId = null);
    }
}