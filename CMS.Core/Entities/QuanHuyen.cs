using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class QuanHuyen : BaseEntity
    {

        public int TinhThanhId { get; set; }
        [MaxLength(100)]
        public string TenQuanHuyen { get; set; }
        public virtual TinhThanh TinhThanh { get; set; }
        public virtual IEnumerable<XaPhuong> XaPhuong { get; set; }
        //public virtual IEnumerable<HocVien> HocVien { get; set; }
        public virtual IEnumerable<UngVien> UngVien { get; set; }


    }
}
