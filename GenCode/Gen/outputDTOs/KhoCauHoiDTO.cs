using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class KhoCauHoiDTO
    {
        public int Id { get; set; }
        public string TenKhoCauHoi { get; set; }
        public string KyHieuKho { get; set; }
        public IEnumerable<CauHoiDTO> CauHoi { get; set; }
        public static KhoCauHoiDTO FromEntity(KhoCauHoi item)
        {
            return new KhoCauHoiDTO()
            {
                Id = item.Id,
                TenKhoCauHoi = item.TenKhoCauHoi,
                KyHieuKho = item.KyHieuKho,
                CauHoi = item.CauHoi?.Select(CauHoiDTO.FromEntity),
            };
        }
        public KhoCauHoi ToEntity()
        {
            return new KhoCauHoi()
            {
                Id = this.Id,
                TenKhoCauHoi = this.TenKhoCauHoi,
                KyHieuKho = this.KyHieuKho,
                CauHoi = this.CauHoi?.Select(x => x.ToEntity()),
            };
        }
    }
}