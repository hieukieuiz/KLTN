using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class TruongDaiHocDTO
    {
        public int Id { get; set; }
        public string TenTruongDaiHoc { get; set; }
        public IEnumerable<UngVienDTO> UngVien { get; set; }
        public static TruongDaiHocDTO FromEntity(TruongDaiHoc item)
        {
            return new TruongDaiHocDTO()
            {
                Id = item.Id,
                TenTruongDaiHoc = item.TenTruongDaiHoc,
                UngVien = item.UngVien?.Select(UngVienDTO.FromEntity),
            };
        }
        public TruongDaiHoc ToEntity()
        {
            return new TruongDaiHoc()
            {
                Id = this.Id,
                TenTruongDaiHoc = this.TenTruongDaiHoc,
                UngVien = this.UngVien?.Select(x => x.ToEntity()),
            };
        }
    }
}