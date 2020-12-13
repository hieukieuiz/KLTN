using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class XaPhuongDTO
    {
        public int Id { get; set; }
        public int QuanHuyenId { get; set; }
        public string TenXaPhuong { get; set; }
        public QuanHuyenDTO QuanHuyen { get; set; }
        public IEnumerable<UngVienDTO> UngVien { get; set; }
        public static XaPhuongDTO FromEntity(XaPhuong item)
        {
            return new XaPhuongDTO()
            {
                Id = item.Id,
                QuanHuyenId = item.QuanHuyenId,
                TenXaPhuong = item.TenXaPhuong,
                QuanHuyen = item.QuanHuyen != null? QuanHuyenDTO.FromEntity(item.QuanHuyen) : null,
                UngVien = item.UngVien?.Select(UngVienDTO.FromEntity),
            };
        }
        public XaPhuong ToEntity()
        {
            return new XaPhuong()
            {
                Id = this.Id,
                QuanHuyenId = this.QuanHuyenId,
                TenXaPhuong = this.TenXaPhuong,
                QuanHuyen = this.QuanHuyen?.ToEntity(),
                UngVien = this.UngVien?.Select(x => x.ToEntity()),
            };
        }
    }
}