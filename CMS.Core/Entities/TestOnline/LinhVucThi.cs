using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.SharedKernel;

namespace CMS.Core.Entities
{
    public class LinhVucThi : BaseEntity
    {
        public string TenLinhVucThi { get; set; }
        public virtual IEnumerable<DeThi> DeThi { get; set; }
    }
}
