using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class CongViecDTO
    {
        public int Id { get; set; }
        public string TenCongViec { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }
        public double TyLeHoanThanh { get; set; }
        public string<DTO> MoTaCongViec { get; set; }
        public string DoUuTien { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public bool IsActive { get; set; }
        public int? DuAnId { get; set; }
        public DuAnDTO DuAn { get; set; }
        public int? TrangThaiId { get; set; }
        public TrangThaiDTO TrangThai { get; set; }
        public int? LoaiCongViecId { get; set; }
        public LoaiCongViecDTO LoaiCongViec { get; set; }
        public int? ThanhVienDuAnId { get; set; }
        public ThanhVienDuAnDTO ThanhVienDuAn { get; set; }
        public IEnumerable<PhanViecDTO> PhanViec { get; set; }
        public IEnumerable<ChiTietCongViecDTO> ChiTietCongViec { get; set; }
        public static CongViecDTO FromEntity(CongViec item)
        {
            return new CongViecDTO()
            {
                Id = item.Id,
                TenCongViec = item.TenCongViec,
                NgayTao = item.NgayTao,
                NgayHetHan = item.NgayHetHan,
                TyLeHoanThanh = item.TyLeHoanThanh,
                MoTaCongViec = item.MoTaCongViec?.Select(DTO.FromEntity),
                DoUuTien = item.DoUuTien,
                NgayHoanThanh = item.NgayHoanThanh,
                NgayCapNhat = item.NgayCapNhat,
                IsActive = item.IsActive,
                DuAnId = item.DuAnId,
                DuAn = item.DuAn != null? DuAnDTO.FromEntity(item.DuAn) : null,
                TrangThaiId = item.TrangThaiId,
                TrangThai = item.TrangThai != null? TrangThaiDTO.FromEntity(item.TrangThai) : null,
                LoaiCongViecId = item.LoaiCongViecId,
                LoaiCongViec = item.LoaiCongViec != null? LoaiCongViecDTO.FromEntity(item.LoaiCongViec) : null,
                ThanhVienDuAnId = item.ThanhVienDuAnId,
                ThanhVienDuAn = item.ThanhVienDuAn != null? ThanhVienDuAnDTO.FromEntity(item.ThanhVienDuAn) : null,
                PhanViec = item.PhanViec?.Select(PhanViecDTO.FromEntity),
                ChiTietCongViec = item.ChiTietCongViec?.Select(ChiTietCongViecDTO.FromEntity),
            };
        }
        public CongViec ToEntity()
        {
            return new CongViec()
            {
                Id = this.Id,
                TenCongViec = this.TenCongViec,
                NgayTao = this.NgayTao,
                NgayHetHan = this.NgayHetHan,
                TyLeHoanThanh = this.TyLeHoanThanh,
                MoTaCongViec = this.MoTaCongViec?.Select(x => x.ToEntity()),
                DoUuTien = this.DoUuTien,
                NgayHoanThanh = this.NgayHoanThanh,
                NgayCapNhat = this.NgayCapNhat,
                IsActive = this.IsActive,
                DuAnId = this.DuAnId,
                DuAn = this.DuAn?.ToEntity(),
                TrangThaiId = this.TrangThaiId,
                TrangThai = this.TrangThai?.ToEntity(),
                LoaiCongViecId = this.LoaiCongViecId,
                LoaiCongViec = this.LoaiCongViec?.ToEntity(),
                ThanhVienDuAnId = this.ThanhVienDuAnId,
                ThanhVienDuAn = this.ThanhVienDuAn?.ToEntity(),
                PhanViec = this.PhanViec?.Select(x => x.ToEntity()),
                ChiTietCongViec = this.ChiTietCongViec?.Select(x => x.ToEntity()),
            };
        }
    }
}