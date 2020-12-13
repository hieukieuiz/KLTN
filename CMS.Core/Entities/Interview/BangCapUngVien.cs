using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class BangCapUngVien : BaseEntity
    {
        public DateTime? NgayCap { get; set; }
        public string TenBang { get; set; }
        public virtual CVUngVien CVUngVien { get; set; }

    }
}

