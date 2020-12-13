using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class LichSuChiTietCongViecDTO
    {
        public int Id { get; set; }
        public int? TrangThaiId { get; set; }
        public TrangThaiDTO TrangThai { get; set; }
        public int? ChiTietCongViecId { get; set; }
        public ChiTietCongViecDTO ChiTietCongViec { get; set; }
        public int? ThanhVienDuAnId { get; set; }
        public ThanhVienDuAnDTO ThanhVienDuAn { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int? ThuTu { get; set; }
        public string<DTO> GhiChu { get; set; }
        public static LichSuChiTietCongViecDTO FromEntity(LichSuChiTietCongViec item)
        {
            return new LichSuChiTietCongViecDTO()
            {
                Id = item.Id,
                TrangThaiId = item.TrangThaiId,
                TrangThai = item.TrangThai != null? TrangThaiDTO.FromEntity(item.TrangThai) : null,
                ChiTietCongViecId = item.ChiTietCongViecId,
                ChiTietCongViec = item.ChiTietCongViec != null? ChiTietCongViecDTO.FromEntity(item.ChiTietCongViec) : null,
                ThanhVienDuAnId = item.ThanhVienDuAnId,
                ThanhVienDuAn = item.ThanhVienDuAn != null? ThanhVienDuAnDTO.FromEntity(item.ThanhVienDuAn) : null,
                NgayCapNhat = item.NgayCapNhat,
                ThuTu = item.ThuTu,
                GhiChu = item.GhiChu?.Select(DTO.FromEntity),
            };
        }
        public LichSuChiTietCongViec ToEntity()
        {
            return new LichSuChiTietCongViec()
            {
                Id = this.Id,
                TrangThaiId = this.TrangThaiId,
                TrangThai = this.TrangThai?.ToEntity(),
                ChiTietCongViecId = this.ChiTietCongViecId,
                ChiTietCongViec = this.ChiTietCongViec?.ToEntity(),
                ThanhVienDuAnId = this.ThanhVienDuAnId,
                ThanhVienDuAn = this.ThanhVienDuAn?.ToEntity(),
                NgayCapNhat = this.NgayCapNhat,
                ThuTu = this.ThuTu,
                GhiChu = this.GhiChu?.Select(x => x.ToEntity()),
            };
        }
    }
}