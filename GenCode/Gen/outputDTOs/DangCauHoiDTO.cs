using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class DangCauHoiDTO
    {
        public int Id { get; set; }
        public string TenDangCauHoi { get; set; }
        public static DangCauHoiDTO FromEntity(DangCauHoi item)
        {
            return new DangCauHoiDTO()
            {
                Id = item.Id,
                TenDangCauHoi = item.TenDangCauHoi,
            };
        }
        public DangCauHoi ToEntity()
        {
            return new DangCauHoi()
            {
                Id = this.Id,
                TenDangCauHoi = this.TenDangCauHoi,
            };
        }
    }
}