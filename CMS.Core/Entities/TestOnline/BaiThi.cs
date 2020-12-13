using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.SharedKernel;

namespace CMS.Core.Entities
{
    public class BaiThi : BaseEntity
    {
        public int DeThiId { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianHoanThanh{ get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayCham { get; set; }
        public double? TongDiemCham { get; set; }
        public double? TongDiemToiDa { get; set; }
        public bool DaNopBai { get; set; }
        public bool DaChamDiem { get; set; }
        public bool DaBaoKetQua { get; set; }
        public virtual DeThi DeThi { get; set; }
        //public virtual HocVien HocVien { get; set; }
        public virtual UngVien UngVien { get; set; }
        public virtual IEnumerable<ChiTietBaiThi> ChiTietBaiThi { get; set; }
        public virtual IEnumerable<BaiTestTuyenDung> BaiTestTuyenDung { get; set; }
    }
}
