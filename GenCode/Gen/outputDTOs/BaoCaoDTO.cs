using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class BaoCaoDTO
    {
        public int Id { get; set; }
        public int? ChiTietCongViecId { get; set; }
        public ChiTietCongViecDTO ChiTietCongViec { get; set; }
        public int? ThanhVienDuAnId { get; set; }
        public ThanhVienDuAnDTO ThanhVienDuAn { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public static BaoCaoDTO FromEntity(BaoCao item)
        {
            return new BaoCaoDTO()
            {
                Id = item.Id,
                ChiTietCongViecId = item.ChiTietCongViecId,
                ChiTietCongViec = item.ChiTietCongViec != null? ChiTietCongViecDTO.FromEntity(item.ChiTietCongViec) : null,
                ThanhVienDuAnId = item.ThanhVienDuAnId,
                ThanhVienDuAn = item.ThanhVienDuAn != null? ThanhVienDuAnDTO.FromEntity(item.ThanhVienDuAn) : null,
                NoiDung = item.NoiDung,
                ThoiGianTao = item.ThoiGianTao,
            };
        }
        public BaoCao ToEntity()
        {
            return new BaoCao()
            {
                Id = this.Id,
                ChiTietCongViecId = this.ChiTietCongViecId,
                ChiTietCongViec = this.ChiTietCongViec?.ToEntity(),
                ThanhVienDuAnId = this.ThanhVienDuAnId,
                ThanhVienDuAn = this.ThanhVienDuAn?.ToEntity(),
                NoiDung = this.NoiDung,
                ThoiGianTao = this.ThoiGianTao,
            };
        }
    }
}