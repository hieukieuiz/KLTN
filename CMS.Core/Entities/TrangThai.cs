using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class TrangThai:BaseEntity
    {
        public string TenTrangThai { get; set; }
        //public virtual IEnumerable<TrangThaiDuAn> TrangThaiDuAn { get; set; }
        //public virtual IEnumerable<LichSuChiTietCongViec> LichSuChiTietCongViec { get; set; }
        //public virtual IEnumerable<ChiTietCongViec> ChiTietCongViec { get; set; }
        //public virtual IEnumerable<CongViec> CongViec { get; set; }
        public virtual IEnumerable<UngVien> UngVien { get; set; }

    }
}
