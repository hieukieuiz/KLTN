using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class TinhThanhDTO
    {
        public int Id { get; set; }
        public string TenTinhThanh { get; set; }
        public IEnumerable<UngVienDTO> UngVien { get; set; }
        public static TinhThanhDTO FromEntity(TinhThanh item)
        {
            return new TinhThanhDTO()
            {
                Id = item.Id,
                TenTinhThanh = item.TenTinhThanh,
                UngVien = item.UngVien?.Select(UngVienDTO.FromEntity),
            };
        }
        public TinhThanh ToEntity()
        {
            return new TinhThanh()
            {
                Id = this.Id,
                TenTinhThanh = this.TenTinhThanh,
                UngVien = this.UngVien?.Select(x => x.ToEntity()),
            };
        }
    }
}