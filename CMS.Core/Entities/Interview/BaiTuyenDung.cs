using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class BaiTuyenDung : BaseEntity
    {
        public string TieuDe { get; set; }
        public int DoanhNghiepId { get; set; }
        public string AnhDaiDien { get; set; }
        [MaxLength(20)]
        public string KyHieu { get; set; }
        public string LinkAnhMinhHoa { get; set; }
        public bool HienThi { get; set; }
        public string GioiThieu { get; set; }
        public string NgayDang { get; set; }
        public string SoLuongTuyen { get; set; }
        public string ThanhPho { get; set; }
        public string MucLuong { get; set; }
        public string KinhNghiem { get; set; }
        //public string SoLuong { get; set; }
        public string GioiTinh { get; set; }
        public string TrinhDo { get; set; }
        public string TinhChatCongViec { get; set; }
        public string HinhThuc { get; set; }
        public string ThoiGianThuViec { get; set; }
        public string NganhNghe { get; set; }
        public string MoTa { get; set; }
        public string QuyenLoi { get; set; }

        public virtual DoanhNghiep DoanhNghiep { get; set; }
        public virtual IEnumerable<UngTuyen> UngTuyen { get; set; }
        public virtual IEnumerable<YeuCau> YeuCau { get; set; }
    }
}
