using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class UngTuyenDTO
    {
        public int Id { get; set; }
        public DateTime? NgayUngTuyen { get; set; }
        public string KetQua { get; set; }
        public string DanhGiaCuaNhaTuyenDung { get; set; }
        public BaiTuyenDungDTO BaiTuyenDung { get; set; }
        public UngVienDTO UngVien { get; set; }
        public static UngTuyenDTO FromEntity(UngTuyen item)
        {
            return new UngTuyenDTO()
            {
                Id = item.Id,
                NgayUngTuyen = item.NgayUngTuyen,
                KetQua = item.KetQua,
                DanhGiaCuaNhaTuyenDung = item.DanhGiaCuaNhaTuyenDung,
                BaiTuyenDung = item.BaiTuyenDung != null? BaiTuyenDungDTO.FromEntity(item.BaiTuyenDung) : null,
                UngVien = item.UngVien != null? UngVienDTO.FromEntity(item.UngVien) : null,
            };
        }
        public UngTuyen ToEntity()
        {
            return new UngTuyen()
            {
                Id = this.Id,
                NgayUngTuyen = this.NgayUngTuyen,
                KetQua = this.KetQua,
                DanhGiaCuaNhaTuyenDung = this.DanhGiaCuaNhaTuyenDung,
                BaiTuyenDung = this.BaiTuyenDung?.ToEntity(),
                UngVien = this.UngVien?.ToEntity(),
            };
        }
    }
}