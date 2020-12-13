using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Features;
using CMS.Core.SharedKernel;

namespace CMS.Core.Entities
{
    public class DeThi : BaseEntity, IActivatable
    {
        public string TenDeThi { get; set; }
        public Guid Guid { get; set; }
        public int? LinhVucThiId { get; set; }
        public string MoTa { get; set; }
        public DateTime? ThoiGianHieuLuc { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool HienThiSoThuTu { get; set; }
        public bool IsActive { get; set; }//Đã xuất bản hay chưa
        public bool IsShowPublic { get; set; }
        public int? SoCau { get; set; }
        public int? ThoiGianLamBai { get; set; }
        public bool LaVoHanHieuLuc { get; set; }
        public int? PhuongThucTao { get; set; }
        public bool BaoNgayKetQua { get; set; }
        public int TrangThaiXuatBan { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        public string MetaUrl { get; set; }
        public string MetaImage { get; set; }
        public virtual IEnumerable<ChiTietDeThi> ChiTietDeThi { get; set; }
        public virtual IEnumerable<BaiThi> BaiThi { get; set; }
        public virtual IEnumerable<HienThiDeThi> HienThiDeThi { get; set; }
        public virtual IEnumerable<NguonDeThi> NguonDeThi { get; set; }
        public virtual IEnumerable<CauHinhDoKho> CauHinhDoKho { get; set; }
        public virtual LinhVucThi LinhVucThi { get; set; }
        //public virtual IEnumerable<BaiTap> BaiTap { get; set; }
    }
}
