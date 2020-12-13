using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Web.ApiModels
{
    public class TrangThaiDTO
    {
        public int Id { get; set; }
        public string TenTrangThai { get; set; }
        //public IEnumerable<CongViecDTO> CongViec { get; set; }
        public static TrangThaiDTO FromEntity(TrangThai item)
        {
            return new TrangThaiDTO()
            {
                Id = item.Id,
                TenTrangThai=item.TenTrangThai,
                //CongViec=item.CongViec?.Select(x=>CongViecDTO.FromEntity(x)),
            };
        }
        public TrangThai ToEntity()
        {
            return new TrangThai()
            {
                Id = this.Id,
                TenTrangThai=this.TenTrangThai
            };
        }
    }
}
