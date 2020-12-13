using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class LoaiYeuCauDTO
    {
        public int Id { get; set; }
        public string TenLoaiYeuCau { get; set; }
        public IEnumerable<YeuCauDTO> YeuCau { get; set; }
        public static LoaiYeuCauDTO FromEntity(LoaiYeuCau item)
        {
            return new LoaiYeuCauDTO()
            {
                Id = item.Id,
                TenLoaiYeuCau = item.TenLoaiYeuCau,
                YeuCau = item.YeuCau?.Select(YeuCauDTO.FromEntity),
            };
        }
        public LoaiYeuCau ToEntity()
        {
            return new LoaiYeuCau()
            {
                Id = this.Id,
                TenLoaiYeuCau = this.TenLoaiYeuCau,
                YeuCau = this.YeuCau?.Select(x => x.ToEntity()),
            };
        }
    }
}