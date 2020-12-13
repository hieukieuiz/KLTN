using CMS.Core.Features;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
    public class UngVien : BaseEntity
    {
        public int? TinhThanhId { get; set; }
        public int? TrangThaiId { get; set; }
        public int? QuanHuyenId { get; set; }
        public int? XaPhuongId { get; set; }
        public int? TruongDaiHocId { get; set; }
        public string HoTen { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? NgaySinh { get; set; }

        public string Sdt { get; set; }

        [MaxLength(150)]
        public string Account { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }
        public string Cmtnd { get; set; }
        public string DiaChi { get; set; }
        public string LinkAnhCaNhan { get; set; }
        public string LinkAnhMatTruoc { get; set; }
        public string LinkAnhMatSau { get; set; }
        public bool? BietQuaFaceBook { get; set; }
        public bool? BietQuaWeb { get; set; }
        public bool? BietQuaGioiThieu { get; set; }
        [MaxLength(150)]
        public string TenNguoiGioiThieu { get; set; }
        public string LinkFaceBook { get; set; }
        [MaxLength(200)]
        public string LinkSkype { get; set; }
        [MaxLength(200)]
        public string LinkZalo { get; set; }
        public bool? DaDienDu { get; set; }
        public string TenKhoa { get; set; }
        public int? NamThu { get; set; }
        public virtual TinhThanh TinhThanh { get; set; }
        public virtual TruongDaiHoc TruongDaiHoc { get; set; }
        public virtual QuanHuyen QuanHuyen { get; set; }
        public virtual XaPhuong XaPhuong { get; set; }
        //public virtual IEnumerable<ThanhVienDuAn> ThanhVienDuAn { get; set; }
        public virtual IEnumerable<CVUngVien> CVUngVien { get; set; }
        public virtual TrangThai TrangThai { get; set; }
        public virtual IEnumerable<DanhGiaChungUngVien> DanhGiaChungUngVien { get; set; }
        public virtual IEnumerable<KyNangUngVien> KyNangUngVien { get; set; }
        public virtual IEnumerable<UngTuyen> UngTuyen { get; set; }
        public virtual IEnumerable<UngVienLamBaiTest> UngVienLamBaiTest { get; set; }
    }
}
