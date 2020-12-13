using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class QuaTrinhHocTapDTO
    {
        public int Id { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string NoiHocTap { get; set; }
        public string ChuyenNganh { get; set; }
        public CVUngVienDTO CVUngVien { get; set; }
        public static QuaTrinhHocTapDTO FromEntity(QuaTrinhHocTap item)
        {
            return new QuaTrinhHocTapDTO()
            {
                Id = item.Id,
                ThoiGianBatDau = item.ThoiGianBatDau,
                ThoiGianKetThuc = item.ThoiGianKetThuc,
                NoiHocTap = item.NoiHocTap,
                ChuyenNganh = item.ChuyenNganh,
                CVUngVien = item.CVUngVien != null? CVUngVienDTO.FromEntity(item.CVUngVien) : null,
            };
        }
        public QuaTrinhHocTap ToEntity()
        {
            return new QuaTrinhHocTap()
            {
                Id = this.Id,
                ThoiGianBatDau = this.ThoiGianBatDau,
                ThoiGianKetThuc = this.ThoiGianKetThuc,
                NoiHocTap = this.NoiHocTap,
                ChuyenNganh = this.ChuyenNganh,
                CVUngVien = this.CVUngVien?.ToEntity(),
            };
        }
    }
}