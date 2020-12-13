using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class LinhVucThiDTO
    {
        public int Id { get; set; }
        public string TenLinhVucThi { get; set; }
        public IEnumerable<DeThiDTO> DeThi { get; set; }
        public static LinhVucThiDTO FromEntity(LinhVucThi item)
        {
            return new LinhVucThiDTO()
            {
                Id = item.Id,
                TenLinhVucThi = item.TenLinhVucThi,
                DeThi = item.DeThi?.Select(DeThiDTO.FromEntity),
            };
        }
        public LinhVucThi ToEntity()
        {
            return new LinhVucThi()
            {
                Id = this.Id,
                TenLinhVucThi = this.TenLinhVucThi,
                DeThi = this.DeThi?.Select(x => x.ToEntity()),
            };
        }
    }
}