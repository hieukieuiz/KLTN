using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.SharedKernel;

namespace CMS.Core.Entities
{
    public class KetQuaBaiThi :BaseEntity
    {
        public int BaiThiId { get; set; }
        [Column(TypeName ="date")]
        public DateTime NgayCham { get; set; }
        public double? TongDiemCham { get; set; }
        public double? TongDiemToiDa { get; set; }
        public virtual BaiThi BaiThi { get; set; }
    }
}
