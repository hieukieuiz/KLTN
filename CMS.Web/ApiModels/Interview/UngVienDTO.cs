using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class UngVienDTO
    {
        public int Id { get; set; }
        public int? TinhThanhId { get; set; }
        public int? TrangThaiId { get; set; }
        public int? QuanHuyenId { get; set; }
        public int? XaPhuongId { get; set; }
        public int? TruongDaiHocId { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Cmtnd { get; set; }
        public string DiaChi { get; set; }
        public string LinkAnhCaNhan { get; set; }
        public string LinkAnhMatTruoc { get; set; }
        public string LinkAnhMatSau { get; set; }
        public bool? BietQuaFaceBook { get; set; }
        public bool? BietQuaWeb { get; set; }
        public bool? BietQuaGioiThieu { get; set; }
        public string TenNguoiGioiThieu { get; set; }
        public string LinkFaceBook { get; set; }
        public string LinkSkype { get; set; }
        public string LinkZalo { get; set; }
        public bool? DaDienDu { get; set; }
        public string TenKhoa { get; set; }
        public int? NamThu { get; set; }
        public TinhThanhDTO TinhThanh { get; set; }
        public TruongDaiHocDTO TruongDaiHoc { get; set; }
        public QuanHuyenDTO QuanHuyen { get; set; }
        public XaPhuongDTO XaPhuong { get; set; }
        //public IEnumerable<ThanhVienDuAnDTO> ThanhVienDuAn { get; set; }
        //public IEnumerable<CVUngVienDTO> CVUngVien { get; set; }
        public TrangThaiDTO TrangThai { get; set; }
        //public IEnumerable<DanhGiaChungUngVienDTO> DanhGiaChungUngVien { get; set; }
        //public IEnumerable<KyNangUngVienDTO> KyNangUngVien { get; set; }
        //public IEnumerable<UngTuyenDTO> UngTuyen { get; set; }
        //public IEnumerable<UngVienLamBaiTestDTO> UngVienLamBaiTest { get; set; }
        public static UngVienDTO FromEntity(UngVien item)
        {
            return new UngVienDTO()
            {
                Id = item.Id,
                TinhThanhId = item.TinhThanhId,
                TrangThaiId = item.TrangThaiId,
                QuanHuyenId = item.QuanHuyenId,
                XaPhuongId = item.XaPhuongId,
                TruongDaiHocId = item.TruongDaiHocId,
                HoTen = item.HoTen,
                NgaySinh = item.NgaySinh,
                Sdt = item.Sdt,
                Account = item.Account,
                Email = item.Email,
                Cmtnd = item.Cmtnd,
                DiaChi = item.DiaChi,
                LinkAnhCaNhan = item.LinkAnhCaNhan,
                LinkAnhMatTruoc = item.LinkAnhMatTruoc,
                LinkAnhMatSau = item.LinkAnhMatSau,
                BietQuaFaceBook = item.BietQuaFaceBook,
                BietQuaWeb = item.BietQuaWeb,
                BietQuaGioiThieu = item.BietQuaGioiThieu,
                TenNguoiGioiThieu = item.TenNguoiGioiThieu,
                LinkFaceBook = item.LinkFaceBook,
                LinkSkype = item.LinkSkype,
                LinkZalo = item.LinkZalo,
                DaDienDu = item.DaDienDu,
                TenKhoa = item.TenKhoa,
                NamThu = item.NamThu,
                TinhThanh = item.TinhThanh != null? TinhThanhDTO.FromEntity(item.TinhThanh) : null,
                TruongDaiHoc = item.TruongDaiHoc != null? TruongDaiHocDTO.FromEntity(item.TruongDaiHoc) : null,
                QuanHuyen = item.QuanHuyen != null? QuanHuyenDTO.FromEntity(item.QuanHuyen) : null,
                XaPhuong = item.XaPhuong != null? XaPhuongDTO.FromEntity(item.XaPhuong) : null,
                //ThanhVienDuAn = item.ThanhVienDuAn?.Select(ThanhVienDuAnDTO.FromEntity),
                //CVUngVien = item.CVUngVien?.Select(CVUngVienDTO.FromEntity),
                TrangThai = item.TrangThai != null? TrangThaiDTO.FromEntity(item.TrangThai) : null,
                //DanhGiaChungUngVien = item.DanhGiaChungUngVien?.Select(DanhGiaChungUngVienDTO.FromEntity),
                //KyNangUngVien = item.KyNangUngVien?.Select(KyNangUngVienDTO.FromEntity),
                //UngTuyen = item.UngTuyen?.Select(UngTuyenDTO.FromEntity),
                //UngVienLamBaiTest = item.UngVienLamBaiTest?.Select(UngVienLamBaiTestDTO.FromEntity),
            };
        }
        public UngVien ToEntity()
        {
            return new UngVien()
            {
                Id = this.Id,
                TinhThanhId = this.TinhThanhId,
                TrangThaiId = this.TrangThaiId,
                QuanHuyenId = this.QuanHuyenId,
                XaPhuongId = this.XaPhuongId,
                TruongDaiHocId = this.TruongDaiHocId,
                HoTen = this.HoTen,
                NgaySinh = this.NgaySinh,
                Sdt = this.Sdt,
                Account = this.Account,
                Email = this.Email,
                Cmtnd = this.Cmtnd,
                DiaChi = this.DiaChi,
                LinkAnhCaNhan = this.LinkAnhCaNhan,
                LinkAnhMatTruoc = this.LinkAnhMatTruoc,
                LinkAnhMatSau = this.LinkAnhMatSau,
                BietQuaFaceBook = this.BietQuaFaceBook,
                BietQuaWeb = this.BietQuaWeb,
                BietQuaGioiThieu = this.BietQuaGioiThieu,
                TenNguoiGioiThieu = this.TenNguoiGioiThieu,
                LinkFaceBook = this.LinkFaceBook,
                LinkSkype = this.LinkSkype,
                LinkZalo = this.LinkZalo,
                DaDienDu = this.DaDienDu,
                TenKhoa = this.TenKhoa,
                NamThu = this.NamThu,
                TinhThanh = this.TinhThanh?.ToEntity(),
                TruongDaiHoc = this.TruongDaiHoc?.ToEntity(),
                QuanHuyen = this.QuanHuyen?.ToEntity(),
                XaPhuong = this.XaPhuong?.ToEntity(),
                //ThanhVienDuAn = this.ThanhVienDuAn?.Select(x => x.ToEntity()),
                //CVUngVien = this.CVUngVien?.Select(x => x.ToEntity()),
                TrangThai = this.TrangThai?.ToEntity(),
                //DanhGiaChungUngVien = this.DanhGiaChungUngVien?.Select(x => x.ToEntity()),
                //KyNangUngVien = this.KyNangUngVien?.Select(x => x.ToEntity()),
                //UngTuyen = this.UngTuyen?.Select(x => x.ToEntity()),
                //UngVienLamBaiTest = this.UngVienLamBaiTest?.Select(x => x.ToEntity()),
            };
        }
    }
}