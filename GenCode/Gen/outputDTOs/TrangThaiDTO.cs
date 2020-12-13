using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class TrangThaiDTO
    {
        public int Id { get; set; }
        public string TenTrangThai { get; set; }
        public IEnumerable<UngVienDTO> UngVien { get; set; }
        public static TrangThaiDTO FromEntity(TrangThai item)
        {
            return new TrangThaiDTO()
            {
                Id = item.Id,
                TenTrangThai = item.TenTrangThai,
                UngVien = item.UngVien?.Select(UngVienDTO.FromEntity),
            };
        }
        public TrangThai ToEntity()
        {
            return new TrangThai()
            {
                Id = this.Id,
                TenTrangThai = this.TenTrangThai,
                UngVien = this.UngVien?.Select(x => x.ToEntity()),
            };
        }
    }
}