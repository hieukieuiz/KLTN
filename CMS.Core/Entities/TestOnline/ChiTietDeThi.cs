using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class ChiTietDeThi : BaseEntity
    {
        public int DeThiId { get; set; }
        public int CauHoiId { get; set; }
        public bool BatBuocTraLoi { get; set; }
        public int ThuTu { get; set; }
        public bool? HienThiSoThuTu { get; set; }
        public int? PhuThuocVaoCauHoiId { get; set; }
        public string GiaTriPhuThuoc { get; set; }
        public double DiemToiDa { get; set; }
        public bool DaoDapAn { get; set; }
        public virtual DeThi DeThi { get; set; }
        public virtual CauHoi CauHoi { get; set; }
        public virtual IEnumerable<ChiTietDapAnDeThi> ChiTietDapAnDeThi { get; set; }
    }
}
