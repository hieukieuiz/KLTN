using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class HienThiDeThi : BaseEntity
    {
        public int? KhoaHocId { get; set; }
        public int DeThiId { get; set; }
        //public virtual KhoaHoc KhoaHoc { get; set; }
        public virtual DeThi DeThi { get; set; }
    }
}
