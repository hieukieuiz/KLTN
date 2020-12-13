using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class DanhGiaChungUngVien : BaseEntity
    {
        public string DanhGiaChungCuaHvit { get; set; }
        public string Rating { get; set; }
        public virtual UngVien UngVien { get; set; }

    }
}