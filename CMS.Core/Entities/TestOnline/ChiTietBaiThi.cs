using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.SharedKernel;

namespace CMS.Core.Entities
{
    public class ChiTietBaiThi : BaseEntity
    {
        public int BaiThiId { get; set; }
        public int CauHoiId { get; set; }
        public string CauTraLoi { get; set; }
        public double? DiemCham { get; set; }
        public virtual BaiThi BaiThi { get; set; }
        public virtual CauHoi CauHoi { get; set; }
    }
}
