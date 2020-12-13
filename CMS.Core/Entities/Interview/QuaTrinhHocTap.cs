using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class QuaTrinhHocTap : BaseEntity
    {
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string NoiHocTap { get; set; }
        public string ChuyenNganh { get; set; }
        public virtual CVUngVien CVUngVien { get; set; }

    }
}
