using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class MucDo :BaseEntity
    {
        public string TenMucDo { get; set; }
        public virtual IEnumerable<CauHoi> CauHoi { get; set; }
    }
}
