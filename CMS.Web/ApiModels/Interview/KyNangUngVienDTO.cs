using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class KyNangUngVienDTO
    {
        public int Id { get; set; }
        public string TuDanhGia { get; set; }
        public string TuRating { get; set; }
        public string HvitDanhGia { get; set; }
        public string HvitRating { get; set; }
        public KyNangDTO KyNang { get; set; }
        public UngVienDTO UngVien { get; set; }
        public static KyNangUngVienDTO FromEntity(KyNangUngVien item)
        {
            return new KyNangUngVienDTO()
            {
                Id = item.Id,
                TuDanhGia = item.TuDanhGia,
                TuRating = item.TuRating,
                HvitDanhGia = item.HvitDanhGia,
                HvitRating = item.HvitRating,
                KyNang = item.KyNang != null? KyNangDTO.FromEntity(item.KyNang) : null,
                UngVien = item.UngVien != null? UngVienDTO.FromEntity(item.UngVien) : null,
            };
        }
        public KyNangUngVien ToEntity()
        {
            return new KyNangUngVien()
            {
                Id = this.Id,
                TuDanhGia = this.TuDanhGia,
                TuRating = this.TuRating,
                HvitDanhGia = this.HvitDanhGia,
                HvitRating = this.HvitRating,
                KyNang = this.KyNang?.ToEntity(),
                UngVien = this.UngVien?.ToEntity(),
            };
        }
    }
}