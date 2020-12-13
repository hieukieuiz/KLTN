using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class UngVienLamBaiTestDTO
    {
        public int Id { get; set; }
        public string KetQua { get; set; }
        public BaiTestTuyenDungDTO BaiTestTuyenDung { get; set; }
        public UngVienDTO UngVien { get; set; }
        public static UngVienLamBaiTestDTO FromEntity(UngVienLamBaiTest item)
        {
            return new UngVienLamBaiTestDTO()
            {
                Id = item.Id,
                KetQua = item.KetQua,
                BaiTestTuyenDung = item.BaiTestTuyenDung != null? BaiTestTuyenDungDTO.FromEntity(item.BaiTestTuyenDung) : null,
                UngVien = item.UngVien != null? UngVienDTO.FromEntity(item.UngVien) : null,
            };
        }
        public UngVienLamBaiTest ToEntity()
        {
            return new UngVienLamBaiTest()
            {
                Id = this.Id,
                KetQua = this.KetQua,
                BaiTestTuyenDung = this.BaiTestTuyenDung?.ToEntity(),
                UngVien = this.UngVien?.ToEntity(),
            };
        }
    }
}