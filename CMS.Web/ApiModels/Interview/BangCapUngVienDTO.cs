using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class BangCapUngVienDTO
    {
        public int Id { get; set; }
        public DateTime? NgayCap { get; set; }
        public string TenBang { get; set; }
        public CVUngVienDTO CVUngVien { get; set; }
        public static BangCapUngVienDTO FromEntity(BangCapUngVien item)
        {
            return new BangCapUngVienDTO()
            {
                Id = item.Id,
                NgayCap = item.NgayCap,
                TenBang = item.TenBang,
                CVUngVien = item.CVUngVien != null? CVUngVienDTO.FromEntity(item.CVUngVien) : null,
            };
        }
        public BangCapUngVien ToEntity()
        {
            return new BangCapUngVien()
            {
                Id = this.Id,
                NgayCap = this.NgayCap,
                TenBang = this.TenBang,
                CVUngVien = this.CVUngVien?.ToEntity(),
            };
        }
    }
}