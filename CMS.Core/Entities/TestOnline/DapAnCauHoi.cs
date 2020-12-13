using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.SharedKernel;

namespace CMS.Core.Entities
{
    public class DapAnCauHoi : BaseEntity
    {
        public int CauHoiId { get; set; }
        public string TenDapAn { get; set; }
        public string GiaTri { get; set; }
        public int ThuTu { get; set; }
        public virtual CauHoi CauHoi { get; set; }
        public virtual IEnumerable<ChiTietDapAnDeThi> ChiTietDapAnDeThi { get; set; }
    }
}
