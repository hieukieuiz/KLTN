using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class DeThiDTO
    {
        public int Id { get; set; }
        public string TenDeThi { get; set; }
        public Guid Guid { get; set; }
        public int? LinhVucThiId { get; set; }
        public string MoTa { get; set; }
        public DateTime? ThoiGianHieuLuc { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool HienThiSoThuTu { get; set; }
        public bool IsActive { get; set; }
        public bool IsShowPublic { get; set; }
        public int? SoCau { get; set; }
        public int? ThoiGianLamBai { get; set; }
        public bool LaVoHanHieuLuc { get; set; }
        public int? PhuongThucTao { get; set; }
        public bool BaoNgayKetQua { get; set; }
        public int TrangThaiXuatBan { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        public string MetaUrl { get; set; }
        public string MetaImage { get; set; }
        public IEnumerable<ChiTietDeThiDTO> ChiTietDeThi { get; set; }
        public IEnumerable<BaiThiDTO> BaiThi { get; set; }
        public IEnumerable<HienThiDeThiDTO> HienThiDeThi { get; set; }
        public IEnumerable<NguonDeThiDTO> NguonDeThi { get; set; }
        public IEnumerable<CauHinhDoKhoDTO> CauHinhDoKho { get; set; }
        public LinhVucThiDTO LinhVucThi { get; set; }
        public static DeThiDTO FromEntity(DeThi item)
        {
            return new DeThiDTO()
            {
                Id = item.Id,
                TenDeThi = item.TenDeThi,
                Guid = item.Guid,
                LinhVucThiId = item.LinhVucThiId,
                MoTa = item.MoTa,
                ThoiGianHieuLuc = item.ThoiGianHieuLuc,
                NgayTao = item.NgayTao,
                HienThiSoThuTu = item.HienThiSoThuTu,
                IsActive = item.IsActive,
                IsShowPublic = item.IsShowPublic,
                SoCau = item.SoCau,
                ThoiGianLamBai = item.ThoiGianLamBai,
                LaVoHanHieuLuc = item.LaVoHanHieuLuc,
                PhuongThucTao = item.PhuongThucTao,
                BaoNgayKetQua = item.BaoNgayKetQua,
                TrangThaiXuatBan = item.TrangThaiXuatBan,
                MetaTitle = item.MetaTitle,
                MetaDescription = item.MetaDescription,
                MetaRobots = item.MetaRobots,
                MetaUrl = item.MetaUrl,
                MetaImage = item.MetaImage,
                ChiTietDeThi = item.ChiTietDeThi?.Select(ChiTietDeThiDTO.FromEntity),
                BaiThi = item.BaiThi?.Select(BaiThiDTO.FromEntity),
                HienThiDeThi = item.HienThiDeThi?.Select(HienThiDeThiDTO.FromEntity),
                NguonDeThi = item.NguonDeThi?.Select(NguonDeThiDTO.FromEntity),
                CauHinhDoKho = item.CauHinhDoKho?.Select(CauHinhDoKhoDTO.FromEntity),
                LinhVucThi = item.LinhVucThi != null? LinhVucThiDTO.FromEntity(item.LinhVucThi) : null,
            };
        }
        public DeThi ToEntity()
        {
            return new DeThi()
            {
                Id = this.Id,
                TenDeThi = this.TenDeThi,
                Guid = this.Guid,
                LinhVucThiId = this.LinhVucThiId,
                MoTa = this.MoTa,
                ThoiGianHieuLuc = this.ThoiGianHieuLuc,
                NgayTao = this.NgayTao,
                HienThiSoThuTu = this.HienThiSoThuTu,
                IsActive = this.IsActive,
                IsShowPublic = this.IsShowPublic,
                SoCau = this.SoCau,
                ThoiGianLamBai = this.ThoiGianLamBai,
                LaVoHanHieuLuc = this.LaVoHanHieuLuc,
                PhuongThucTao = this.PhuongThucTao,
                BaoNgayKetQua = this.BaoNgayKetQua,
                TrangThaiXuatBan = this.TrangThaiXuatBan,
                MetaTitle = this.MetaTitle,
                MetaDescription = this.MetaDescription,
                MetaRobots = this.MetaRobots,
                MetaUrl = this.MetaUrl,
                MetaImage = this.MetaImage,
                ChiTietDeThi = this.ChiTietDeThi?.Select(x => x.ToEntity()),
                BaiThi = this.BaiThi?.Select(x => x.ToEntity()),
                HienThiDeThi = this.HienThiDeThi?.Select(x => x.ToEntity()),
                NguonDeThi = this.NguonDeThi?.Select(x => x.ToEntity()),
                CauHinhDoKho = this.CauHinhDoKho?.Select(x => x.ToEntity()),
                LinhVucThi = this.LinhVucThi?.ToEntity(),
            };
        }
    }
}