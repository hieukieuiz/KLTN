using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class CauHoi : BaseEntity
    {
        public string TenCauHoi { get; set; }
        public string KyHieu { get; set; }
        public string MoTa { get; set; }
        public string TienTo { get; set; }
        public string HauTo { get; set; }
        public int DangCauHoiId { get; set; }
        public int? KhoCauHoiId { get; set; }
        public int? MucDoId { get; set; }
        public string GiaTriDapAn { get; set; }
        public virtual DangCauHoi DangCauHoi { get; set; }
        public virtual KhoCauHoi KhoCauHoi { get; set; }
        public virtual MucDo MucDo { get; set; }
        public virtual IEnumerable<DapAnCauHoi> DapAnCauHoi { get; set; }
    }
}
