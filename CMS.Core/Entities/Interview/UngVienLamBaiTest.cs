using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class UngVienLamBaiTest : BaseEntity
    {
        public string KetQua { get; set; }
        public virtual BaiTestTuyenDung BaiTestTuyenDung { get; set; }
        public virtual UngVien UngVien { get; set; }
    }
}
