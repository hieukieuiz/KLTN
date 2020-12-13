using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class XaPhuongDTO
    {
        public int Id { get; set; }
        public string TenXaPhuong { get; set; }
        public QuanHuyenDTO QuanHuyen { get; set; }
        public static XaPhuongDTO FromEntity(XaPhuong item)
        {
            return new XaPhuongDTO()
            {
                Id = item.Id,
                TenXaPhuong = item.TenXaPhuong,
                QuanHuyen = item.QuanHuyen != null ? QuanHuyenDTO.FromEntity(item.QuanHuyen) : null,
            };
        }
        public XaPhuong ToEntity()
        {
            return new XaPhuong() 
            {
                Id = this.Id,
                TenXaPhuong = this.TenXaPhuong,
                QuanHuyen = this.QuanHuyen?.ToEntity(),
            };
        }
    }
}