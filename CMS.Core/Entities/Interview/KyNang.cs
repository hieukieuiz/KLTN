using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class KyNang : BaseEntity
    {
        public string TenKyNang { get; set; }
        public virtual NhomKyNang NhomKyNang { get; set; }
        public virtual IEnumerable<KyNangUngVien> KyNangUngVien { get; set; }
    }
}
