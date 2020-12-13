using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class KyNangDTO
    {
        public int Id { get; set; }
        public string TenKyNang { get; set; }
        public NhomKyNangDTO NhomKyNang { get; set; }
        public IEnumerable<KyNangUngVienDTO> KyNangUngVien { get; set; }
        public static KyNangDTO FromEntity(KyNang item)
        {
            return new KyNangDTO()
            {
                Id = item.Id,
                TenKyNang = item.TenKyNang,
                NhomKyNang = item.NhomKyNang != null? NhomKyNangDTO.FromEntity(item.NhomKyNang) : null,
                KyNangUngVien = item.KyNangUngVien?.Select(KyNangUngVienDTO.FromEntity),
            };
        }
        public KyNang ToEntity()
        {
            return new KyNang()
            {
                Id = this.Id,
                TenKyNang = this.TenKyNang,
                NhomKyNang = this.NhomKyNang?.ToEntity(),
                KyNangUngVien = this.KyNangUngVien?.Select(x => x.ToEntity()),
            };
        }
    }
}