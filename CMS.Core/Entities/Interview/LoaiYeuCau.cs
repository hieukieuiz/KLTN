using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class LoaiYeuCau : BaseEntity
    {
        public string TenLoaiYeuCau { get; set; }
        public virtual IEnumerable<YeuCau> YeuCau { get; set; }
    }
}