using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class QuanHuyenDTO
    {
        public int Id { get; set; }
        public int TinhThanhId { get; set; }
        public string TenQuanHuyen { get; set; }
        public TinhThanhDTO TinhThanh { get; set; }
        public IEnumerable<XaPhuongDTO> XaPhuong { get; set; }
        public IEnumerable<UngVienDTO> UngVien { get; set; }
        public static QuanHuyenDTO FromEntity(QuanHuyen item)
        {
            return new QuanHuyenDTO()
            {
                Id = item.Id,
                TinhThanhId = item.TinhThanhId,
                TenQuanHuyen = item.TenQuanHuyen,
                TinhThanh = item.TinhThanh != null? TinhThanhDTO.FromEntity(item.TinhThanh) : null,
                XaPhuong = item.XaPhuong?.Select(XaPhuongDTO.FromEntity),
                UngVien = item.UngVien?.Select(UngVienDTO.FromEntity),
            };
        }
        public QuanHuyen ToEntity()
        {
            return new QuanHuyen()
            {
                Id = this.Id,
                TinhThanhId = this.TinhThanhId,
                TenQuanHuyen = this.TenQuanHuyen,
                TinhThanh = this.TinhThanh?.ToEntity(),
                XaPhuong = this.XaPhuong?.Select(x => x.ToEntity()),
                UngVien = this.UngVien?.Select(x => x.ToEntity()),
            };
        }
    }
}