using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class ChiTietDapAnDeThi : BaseEntity
    {
        public int ChiTietDeThiId { get; set; }
        public int DapAnCauHoiId { get; set; }
        public int ThuTuMoi { get; set; }
        public virtual ChiTietDeThi ChiTietDeThi { get; set; }
        public virtual DapAnCauHoi DapAnCauHoi { get; set; }
    }
}
