using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class BaiTestTuyenDungDTO
    {
        public int Id { get; set; }
        public string DiemPass { get; set; }
        public BaiTuyenDungDTO BaiTuyenDung { get; set; }
        public BaiThiDTO BaiThi { get; set; }
        public static BaiTestTuyenDungDTO FromEntity(BaiTestTuyenDung item)
        {
            return new BaiTestTuyenDungDTO()
            {
                Id = item.Id,
                DiemPass = item.DiemPass,
                BaiTuyenDung = item.BaiTuyenDung != null? BaiTuyenDungDTO.FromEntity(item.BaiTuyenDung) : null,
                BaiThi = item.BaiThi != null? BaiThiDTO.FromEntity(item.BaiThi) : null,
            };
        }
        public BaiTestTuyenDung ToEntity()
        {
            return new BaiTestTuyenDung()
            {
                Id = this.Id,
                DiemPass = this.DiemPass,
                BaiTuyenDung = this.BaiTuyenDung?.ToEntity(),
                BaiThi = this.BaiThi?.ToEntity(),
            };
        }
    }
}