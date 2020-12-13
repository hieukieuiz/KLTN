using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class KyNangUngVien : BaseEntity
    {
        public string TuDanhGia { get; set; }
        public string TuRating { get; set; }
        public string HvitDanhGia { get; set; }
        public string HvitRating { get; set; }
        public virtual KyNang KyNang { get; set; }
        public virtual UngVien UngVien { get; set; }
    }
}