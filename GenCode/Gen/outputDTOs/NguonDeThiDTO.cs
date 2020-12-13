using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class NguonDeThiDTO
    {
        public int Id { get; set; }
        public int DeThiId { get; set; }
        public int KhoCauHoiId { get; set; }
        public DeThiDTO DeThi { get; set; }
        public KhoCauHoiDTO KhoCauHoi { get; set; }
        public static NguonDeThiDTO FromEntity(NguonDeThi item)
        {
            return new NguonDeThiDTO()
            {
                Id = item.Id,
                DeThiId = item.DeThiId,
                KhoCauHoiId = item.KhoCauHoiId,
                DeThi = item.DeThi != null? DeThiDTO.FromEntity(item.DeThi) : null,
                KhoCauHoi = item.KhoCauHoi != null? KhoCauHoiDTO.FromEntity(item.KhoCauHoi) : null,
            };
        }
        public NguonDeThi ToEntity()
        {
            return new NguonDeThi()
            {
                Id = this.Id,
                DeThiId = this.DeThiId,
                KhoCauHoiId = this.KhoCauHoiId,
                DeThi = this.DeThi?.ToEntity(),
                KhoCauHoi = this.KhoCauHoi?.ToEntity(),
            };
        }
    }
}