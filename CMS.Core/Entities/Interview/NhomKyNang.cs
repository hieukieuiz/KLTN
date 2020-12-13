using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class NhomKyNang : BaseEntity
    {
        public string TenNhomKyNang { get; set; }
        public virtual IEnumerable<KyNang> KyNang { get; set; }
    }
}
