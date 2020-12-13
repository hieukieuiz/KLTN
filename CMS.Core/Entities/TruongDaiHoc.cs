using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class TruongDaiHoc : BaseEntity
    {
        [MaxLength(200)]
        public string TenTruongDaiHoc { get; set; }
        //public virtual IEnumerable<HocVien> HocVien { get; set; }
        public virtual IEnumerable<UngVien> UngVien { get; set; }

    }
}
