using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class BaiTestTuyenDung : BaseEntity
    {
        public string DiemPass { get; set; }
        public virtual BaiTuyenDung BaiTuyenDung { get; set; }
        public virtual BaiThi BaiThi { get; set; }
    }
}
