using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class LoaiCongViecDTO
    {
        public int Id { get; set; }
        public string TenLoaiCongViec { get; set; }
        public IEnumerable<CongViecDTO> CongViec { get; set; }
        public static LoaiCongViecDTO FromEntity(LoaiCongViec item)
        {
            return new LoaiCongViecDTO()
            {
                Id = item.Id,
                TenLoaiCongViec = item.TenLoaiCongViec,
                CongViec = item.CongViec?.Select(CongViecDTO.FromEntity),
            };
        }
        public LoaiCongViec ToEntity()
        {
            return new LoaiCongViec()
            {
                Id = this.Id,
                TenLoaiCongViec = this.TenLoaiCongViec,
                CongViec = this.CongViec?.Select(x => x.ToEntity()),
            };
        }
    }
}