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
        //public IEnumerable<HocVienDTO> HocVien { get; set; }
        //public IEnumerable<NhanVienDTO> NhanVien { get; set; }
        public static TruongDaiHocDTO FromEntity(TruongDaiHoc item)
        {
            return new TruongDaiHocDTO()
            {
                Id = item.Id,
                TenTruongDaiHoc = item.TenTruongDaiHoc,
                //HocVien = item.HocVien?.Select(HocVienDTO.FromEntity),
                //NhanVien = item.NhanVien?.Select(NhanVienDTO.FromEntity),
            };
        }
        public TruongDaiHoc ToEntity()
        {
            return new TruongDaiHoc()
            {
                Id = this.Id,
                TenTruongDaiHoc = this.TenTruongDaiHoc,
                //HocVien = this.HocVien?.Select(x => x.ToEntity()),
                //NhanVien = this.NhanVien?.Select(x => x.ToEntity()),
            };
        }
    }
}