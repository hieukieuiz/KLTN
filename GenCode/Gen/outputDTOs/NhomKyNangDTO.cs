using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class NhomKyNangDTO
    {
        public int Id { get; set; }
        public string TenNhomKyNang { get; set; }
        public IEnumerable<KyNangDTO> KyNang { get; set; }
        public static NhomKyNangDTO FromEntity(NhomKyNang item)
        {
            return new NhomKyNangDTO()
            {
                Id = item.Id,
                TenNhomKyNang = item.TenNhomKyNang,
                KyNang = item.KyNang?.Select(KyNangDTO.FromEntity),
            };
        }
        public NhomKyNang ToEntity()
        {
            return new NhomKyNang()
            {
                Id = this.Id,
                TenNhomKyNang = this.TenNhomKyNang,
                KyNang = this.KyNang?.Select(x => x.ToEntity()),
            };
        }
    }
}