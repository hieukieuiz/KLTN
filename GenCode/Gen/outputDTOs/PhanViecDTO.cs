using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class PhanViecDTO
    {
        public int Id { get; set; }
        public int? CongViecId { get; set; }
        public CongViecDTO CongViec { get; set; }
        public int? ThanhVienDuAnId { get; set; }
        public ThanhVienDuAnDTO ThanhVienDuAn { get; set; }
        public DateTime NgayPhanViec { get; set; }
        public static PhanViecDTO FromEntity(PhanViec item)
        {
            return new PhanViecDTO()
            {
                Id = item.Id,
                CongViecId = item.CongViecId,
                CongViec = item.CongViec != null? CongViecDTO.FromEntity(item.CongViec) : null,
                ThanhVienDuAnId = item.ThanhVienDuAnId,
                ThanhVienDuAn = item.ThanhVienDuAn != null? ThanhVienDuAnDTO.FromEntity(item.ThanhVienDuAn) : null,
                NgayPhanViec = item.NgayPhanViec,
            };
        }
        public PhanViec ToEntity()
        {
            return new PhanViec()
            {
                Id = this.Id,
                CongViecId = this.CongViecId,
                CongViec = this.CongViec?.ToEntity(),
                ThanhVienDuAnId = this.ThanhVienDuAnId,
                ThanhVienDuAn = this.ThanhVienDuAn?.ToEntity(),
                NgayPhanViec = this.NgayPhanViec,
            };
        }
    }
}