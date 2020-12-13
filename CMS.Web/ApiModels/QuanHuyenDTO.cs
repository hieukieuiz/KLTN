using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class QuanHuyenDTO
    {
        public int Id { get; set; }
        public string TenQuanHuyen { get; set; }
        public IEnumerable<XaPhuongDTO> XaPhuong { get; set; }
        public TinhThanhDTO TinhThanh { get; set; }
        public static QuanHuyenDTO FromEntity(QuanHuyen item)
        {
            return new QuanHuyenDTO()
            {
                Id = item.Id,
                TenQuanHuyen = item.TenQuanHuyen,
                XaPhuong = item.XaPhuong?.Select(XaPhuongDTO.FromEntity),
                TinhThanh = item.TinhThanh != null ? TinhThanhDTO.FromEntity(item.TinhThanh) : null,
            };
        }
        public QuanHuyen ToEntity() 
        {
            return new QuanHuyen()
            {
                Id = this.Id,
                TenQuanHuyen = this.TenQuanHuyen,
                XaPhuong = this.XaPhuong?.Select(x => x.ToEntity()),
                TinhThanh = this.TinhThanh?.ToEntity(),
            };
        }
    }
}