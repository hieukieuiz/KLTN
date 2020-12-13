using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class YeuCau : BaseEntity
    {
        public string TenYeuCau { get; set; }
        public string GiaTriSoTu { get; set; }
        public string GiaTriSoDen { get; set; }
        public string GiaTriNoiDung { get; set; }
        public virtual BaiTuyenDung BaiTuyenDung { get; set; }
        public virtual LoaiYeuCau LoaiYeuCau { get; set; }
        //public virtual IEnumerable<YeuCau> YeuCau { get; set; }
    }
}
