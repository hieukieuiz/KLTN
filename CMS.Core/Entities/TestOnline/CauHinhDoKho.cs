using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class CauHinhDoKho : BaseEntity
    {
        public int DeThiId { get; set; }
        public int? MucDoId { get; set; }
        public int? SoLuongCauHoi { get; set; }
        public double Diem { get; set; }
        public bool DaoDapAn { get; set; }
        public virtual DeThi DeThi { get; set; }
        public virtual MucDo MucDo { get; set; }
    }
}
