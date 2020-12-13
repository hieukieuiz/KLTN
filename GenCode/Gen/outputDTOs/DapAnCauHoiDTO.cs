using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class DapAnCauHoiDTO
    {
        public int Id { get; set; }
        public int CauHoiId { get; set; }
        public string TenDapAn { get; set; }
        public string GiaTri { get; set; }
        public int ThuTu { get; set; }
        public CauHoiDTO CauHoi { get; set; }
        public IEnumerable<ChiTietDapAnDeThiDTO> ChiTietDapAnDeThi { get; set; }
        public static DapAnCauHoiDTO FromEntity(DapAnCauHoi item)
        {
            return new DapAnCauHoiDTO()
            {
                Id = item.Id,
                CauHoiId = item.CauHoiId,
                TenDapAn = item.TenDapAn,
                GiaTri = item.GiaTri,
                ThuTu = item.ThuTu,
                CauHoi = item.CauHoi != null? CauHoiDTO.FromEntity(item.CauHoi) : null,
                ChiTietDapAnDeThi = item.ChiTietDapAnDeThi?.Select(ChiTietDapAnDeThiDTO.FromEntity),
            };
        }
        public DapAnCauHoi ToEntity()
        {
            return new DapAnCauHoi()
            {
                Id = this.Id,
                CauHoiId = this.CauHoiId,
                TenDapAn = this.TenDapAn,
                GiaTri = this.GiaTri,
                ThuTu = this.ThuTu,
                CauHoi = this.CauHoi?.ToEntity(),
                ChiTietDapAnDeThi = this.ChiTietDapAnDeThi?.Select(x => x.ToEntity()),
            };
        }
    }
}