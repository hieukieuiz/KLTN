using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class UngTuyen : BaseEntity
    {
        public DateTime? NgayUngTuyen { get; set; }
        public string KetQua { get; set; }
        public string DanhGiaCuaNhaTuyenDung { get; set; }
        public virtual BaiTuyenDung BaiTuyenDung { get; set; }
        public virtual UngVien UngVien { get; set; }
    }
}
