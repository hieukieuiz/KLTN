using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class QuaTrinhLamDuAn : BaseEntity
    {
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string TenCongTy { get; set; }
        public string ViTri { get; set; }
        public string MoTaNganDuAn { get; set; }
        public string KyNang { get; set; }
        public virtual CVUngVien CVUngVien { get; set; }

    }
}
