using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class KhoCauHoi : BaseEntity
    {
        public string TenKhoCauHoi { get; set; }
        public string KyHieuKho { get; set; }
        public virtual IEnumerable<CauHoi> CauHoi { get; set; }
    }
}
