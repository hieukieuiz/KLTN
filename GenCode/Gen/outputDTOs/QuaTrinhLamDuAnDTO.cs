using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class QuaTrinhLamDuAnDTO
    {
        public int Id { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string TenCongTy { get; set; }
        public string ViTri { get; set; }
        public string MoTaNganDuAn { get; set; }
        public string KyNang { get; set; }
        public CVUngVienDTO CVUngVien { get; set; }
        public static QuaTrinhLamDuAnDTO FromEntity(QuaTrinhLamDuAn item)
        {
            return new QuaTrinhLamDuAnDTO()
            {
                Id = item.Id,
                ThoiGianBatDau = item.ThoiGianBatDau,
                ThoiGianKetThuc = item.ThoiGianKetThuc,
                TenCongTy = item.TenCongTy,
                ViTri = item.ViTri,
                MoTaNganDuAn = item.MoTaNganDuAn,
                KyNang = item.KyNang,
                CVUngVien = item.CVUngVien != null? CVUngVienDTO.FromEntity(item.CVUngVien) : null,
            };
        }
        public QuaTrinhLamDuAn ToEntity()
        {
            return new QuaTrinhLamDuAn()
            {
                Id = this.Id,
                ThoiGianBatDau = this.ThoiGianBatDau,
                ThoiGianKetThuc = this.ThoiGianKetThuc,
                TenCongTy = this.TenCongTy,
                ViTri = this.ViTri,
                MoTaNganDuAn = this.MoTaNganDuAn,
                KyNang = this.KyNang,
                CVUngVien = this.CVUngVien?.ToEntity(),
            };
        }
    }
}