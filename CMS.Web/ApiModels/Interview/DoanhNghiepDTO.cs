using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class DoanhNghiepDTO
    {
        public int Id { get; set; }
        public DateTime? NgayUngTuyen { get; set; }
        public string TenDoanhNghiep { get; set; }
        public string LogoDoanhNghiep { get; set; }
        public string Account { get; set; }
        public string SĐT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string GioiThieu { get; set; }
        public IEnumerable<BaiTuyenDungDTO> BaiTuyenDung { get; set; }
        public static DoanhNghiepDTO FromEntity(DoanhNghiep item)
        {
            return new DoanhNghiepDTO()
            {
                Id = item.Id,
                NgayUngTuyen = item.NgayUngTuyen,
                TenDoanhNghiep = item.TenDoanhNghiep,
                LogoDoanhNghiep = item.LogoDoanhNghiep,
                Account = item.Account,
                SĐT = item.SĐT,
                Email = item.Email,
                DiaChi = item.DiaChi,
                GioiThieu = item.GioiThieu,
                BaiTuyenDung = item.BaiTuyenDung?.Select(BaiTuyenDungDTO.FromEntity),
            };
        }
        public DoanhNghiep ToEntity()
        {
            return new DoanhNghiep()
            {
                Id = this.Id,
                NgayUngTuyen = this.NgayUngTuyen,
                TenDoanhNghiep = this.TenDoanhNghiep,
                LogoDoanhNghiep = this.LogoDoanhNghiep,
                Account = this.Account,
                SĐT = this.SĐT,
                Email = this.Email,
                DiaChi = this.DiaChi,
                GioiThieu = this.GioiThieu,
                BaiTuyenDung = this.BaiTuyenDung?.Select(x => x.ToEntity()),
            };
        }
    }
}