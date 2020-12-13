using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class KetQuaBaiThiDTO
    {
        public int Id { get; set; }
        public int BaiThiId { get; set; }
        public DateTime NgayCham { get; set; }
        public double? TongDiemCham { get; set; }
        public double? TongDiemToiDa { get; set; }
        public BaiThiDTO BaiThi { get; set; }
        public static KetQuaBaiThiDTO FromEntity(KetQuaBaiThi item)
        {
            return new KetQuaBaiThiDTO()
            {
                Id = item.Id,
                BaiThiId = item.BaiThiId,
                NgayCham = item.NgayCham,
                TongDiemCham = item.TongDiemCham,
                TongDiemToiDa = item.TongDiemToiDa,
                BaiThi = item.BaiThi != null? BaiThiDTO.FromEntity(item.BaiThi) : null,
            };
        }
        public KetQuaBaiThi ToEntity()
        {
            return new KetQuaBaiThi()
            {
                Id = this.Id,
                BaiThiId = this.BaiThiId,
                NgayCham = this.NgayCham,
                TongDiemCham = this.TongDiemCham,
                TongDiemToiDa = this.TongDiemToiDa,
                BaiThi = this.BaiThi?.ToEntity(),
            };
        }
    }
}