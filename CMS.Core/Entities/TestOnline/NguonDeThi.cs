using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class NguonDeThi : BaseEntity
    {
        public int DeThiId { get; set; }
        public int KhoCauHoiId { get; set; }
        public virtual DeThi DeThi { get; set; }
        public virtual KhoCauHoi KhoCauHoi { get; set; }
    }
}
