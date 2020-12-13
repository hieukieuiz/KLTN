using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ChiTietDapAnDeThiDTO
    {
        public int Id { get; set; }
        public int ChiTietDeThiId { get; set; }
        public int DapAnCauHoiId { get; set; }
        public int ThuTuMoi { get; set; }
        public ChiTietDeThiDTO ChiTietDeThi { get; set; }
        public DapAnCauHoiDTO DapAnCauHoi { get; set; }
        public static ChiTietDapAnDeThiDTO FromEntity(ChiTietDapAnDeThi item)
        {
            return new ChiTietDapAnDeThiDTO()
            {
                Id = item.Id,
                ChiTietDeThiId = item.ChiTietDeThiId,
                DapAnCauHoiId = item.DapAnCauHoiId,
                ThuTuMoi = item.ThuTuMoi,
                ChiTietDeThi = item.ChiTietDeThi != null? ChiTietDeThiDTO.FromEntity(item.ChiTietDeThi) : null,
                DapAnCauHoi = item.DapAnCauHoi != null? DapAnCauHoiDTO.FromEntity(item.DapAnCauHoi) : null,
            };
        }
        public ChiTietDapAnDeThi ToEntity()
        {
            return new ChiTietDapAnDeThi()
            {
                Id = this.Id,
                ChiTietDeThiId = this.ChiTietDeThiId,
                DapAnCauHoiId = this.DapAnCauHoiId,
                ThuTuMoi = this.ThuTuMoi,
                ChiTietDeThi = this.ChiTietDeThi?.ToEntity(),
                DapAnCauHoi = this.DapAnCauHoi?.ToEntity(),
            };
        }
    }
}