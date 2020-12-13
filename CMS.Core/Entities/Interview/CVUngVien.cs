using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class CVUngVien : BaseEntity
    {
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MucTieuCaNhan { get; set; }
        public string SoThich { get; set; }
        public virtual UngVien UngVien { get; set; }
        //public virtual IEnumerable<TrangThaiDuAn> TrangThaiDuAn { get; set; }
        //public virtual IEnumerable<LichSuChiTietCongViec> LichSuChiTietCongViec { get; set; }
        //public virtual IEnumerable<ChiTietCongViec> ChiTietCongViec { get; set; }
        //public virtual IEnumerable<CongViec> CongViec { get; set; }
        public virtual IEnumerable<QuaTrinhHocTap> QuaTrinhHocTap { get; set; }
        public virtual IEnumerable<BangCapUngVien> BangCapUngVien { get; set; }
        public virtual IEnumerable<QuaTrinhLamDuAn> QuaTrinhLamDuAn { get; set; }
    }
}
