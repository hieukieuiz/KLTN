using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class DoanhNghiep : BaseEntity
    {
        public DateTime? NgayUngTuyen { get; set; }
        public string TenDoanhNghiep { get; set; }
        public string LogoDoanhNghiep { get; set; }
        public string Account { get; set; }
        public string SĐT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string GioiThieu { get; set; }
        public virtual IEnumerable<BaiTuyenDung> BaiTuyenDung { get; set; }
    }
}