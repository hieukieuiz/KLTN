using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class DanhGiaChungUngVienDTO
    {
        public int Id { get; set; }
        public string DanhGiaChungCuaHvit { get; set; }
        public string Rating { get; set; }
        public UngVienDTO UngVien { get; set; }
        public static DanhGiaChungUngVienDTO FromEntity(DanhGiaChungUngVien item)
        {
            return new DanhGiaChungUngVienDTO()
            {
                Id = item.Id,
                DanhGiaChungCuaHvit = item.DanhGiaChungCuaHvit,
                Rating = item.Rating,
                UngVien = item.UngVien != null? UngVienDTO.FromEntity(item.UngVien) : null,
            };
        }
        public DanhGiaChungUngVien ToEntity()
        {
            return new DanhGiaChungUngVien()
            {
                Id = this.Id,
                DanhGiaChungCuaHvit = this.DanhGiaChungCuaHvit,
                Rating = this.Rating,
                UngVien = this.UngVien?.ToEntity(),
            };
        }
    }
}