using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class CauHoiDTO
    {
        public int Id { get; set; }
        public string TenCauHoi { get; set; }
        public string KyHieu { get; set; }
        public string MoTa { get; set; }
        public string TienTo { get; set; }
        public string HauTo { get; set; }
        public int DangCauHoiId { get; set; }
        public int? KhoCauHoiId { get; set; }
        public int? MucDoId { get; set; }
        public string GiaTriDapAn { get; set; }
        public DangCauHoiDTO DangCauHoi { get; set; }
        public KhoCauHoiDTO KhoCauHoi { get; set; }
        public MucDoDTO MucDo { get; set; }
        public IEnumerable<DapAnCauHoiDTO> DapAnCauHoi { get; set; }
        public static CauHoiDTO FromEntity(CauHoi item)
        {
            return new CauHoiDTO()
            {
                Id = item.Id,
                TenCauHoi = item.TenCauHoi,
                KyHieu = item.KyHieu,
                MoTa = item.MoTa,
                TienTo = item.TienTo,
                HauTo = item.HauTo,
                DangCauHoiId = item.DangCauHoiId,
                KhoCauHoiId = item.KhoCauHoiId,
                MucDoId = item.MucDoId,
                GiaTriDapAn = item.GiaTriDapAn,
                DangCauHoi = item.DangCauHoi != null? DangCauHoiDTO.FromEntity(item.DangCauHoi) : null,
                KhoCauHoi = item.KhoCauHoi != null? KhoCauHoiDTO.FromEntity(item.KhoCauHoi) : null,
                MucDo = item.MucDo != null? MucDoDTO.FromEntity(item.MucDo) : null,
                DapAnCauHoi = item.DapAnCauHoi?.Select(DapAnCauHoiDTO.FromEntity),
            };
        }
        public CauHoi ToEntity()
        {
            return new CauHoi()
            {
                Id = this.Id,
                TenCauHoi = this.TenCauHoi,
                KyHieu = this.KyHieu,
                MoTa = this.MoTa,
                TienTo = this.TienTo,
                HauTo = this.HauTo,
                DangCauHoiId = this.DangCauHoiId,
                KhoCauHoiId = this.KhoCauHoiId,
                MucDoId = this.MucDoId,
                GiaTriDapAn = this.GiaTriDapAn,
                DangCauHoi = this.DangCauHoi?.ToEntity(),
                KhoCauHoi = this.KhoCauHoi?.ToEntity(),
                MucDo = this.MucDo?.ToEntity(),
                DapAnCauHoi = this.DapAnCauHoi?.Select(x => x.ToEntity()),
            };
        }
    }
}