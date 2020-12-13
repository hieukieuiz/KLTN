using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class HienThiDeThiDTO
    {
        public int Id { get; set; }
        public int? KhoaHocId { get; set; }
        public int DeThiId { get; set; }
        public DeThiDTO DeThi { get; set; }
        public static HienThiDeThiDTO FromEntity(HienThiDeThi item)
        {
            return new HienThiDeThiDTO()
            {
                Id = item.Id,
                KhoaHocId = item.KhoaHocId,
                DeThiId = item.DeThiId,
                DeThi = item.DeThi != null? DeThiDTO.FromEntity(item.DeThi) : null,
            };
        }
        public HienThiDeThi ToEntity()
        {
            return new HienThiDeThi()
            {
                Id = this.Id,
                KhoaHocId = this.KhoaHocId,
                DeThiId = this.DeThiId,
                DeThi = this.DeThi?.ToEntity(),
            };
        }
    }
}