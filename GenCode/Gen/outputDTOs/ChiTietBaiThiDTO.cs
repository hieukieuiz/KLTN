using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ChiTietBaiThiDTO
    {
        public int Id { get; set; }
        public int BaiThiId { get; set; }
        public int CauHoiId { get; set; }
        public string CauTraLoi { get; set; }
        public double? DiemCham { get; set; }
        public BaiThiDTO BaiThi { get; set; }
        public CauHoiDTO CauHoi { get; set; }
        public static ChiTietBaiThiDTO FromEntity(ChiTietBaiThi item)
        {
            return new ChiTietBaiThiDTO()
            {
                Id = item.Id,
                BaiThiId = item.BaiThiId,
                CauHoiId = item.CauHoiId,
                CauTraLoi = item.CauTraLoi,
                DiemCham = item.DiemCham,
                BaiThi = item.BaiThi != null? BaiThiDTO.FromEntity(item.BaiThi) : null,
                CauHoi = item.CauHoi != null? CauHoiDTO.FromEntity(item.CauHoi) : null,
            };
        }
        public ChiTietBaiThi ToEntity()
        {
            return new ChiTietBaiThi()
            {
                Id = this.Id,
                BaiThiId = this.BaiThiId,
                CauHoiId = this.CauHoiId,
                CauTraLoi = this.CauTraLoi,
                DiemCham = this.DiemCham,
                BaiThi = this.BaiThi?.ToEntity(),
                CauHoi = this.CauHoi?.ToEntity(),
            };
        }
    }
}