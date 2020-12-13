using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class MucDoDTO
    {
        public int Id { get; set; }
        public string TenMucDo { get; set; }
        public IEnumerable<CauHoiDTO> CauHoi { get; set; }
        public static MucDoDTO FromEntity(MucDo item)
        {
            return new MucDoDTO()
            {
                Id = item.Id,
                TenMucDo = item.TenMucDo,
                CauHoi = item.CauHoi?.Select(CauHoiDTO.FromEntity),
            };
        }
        public MucDo ToEntity()
        {
            return new MucDo()
            {
                Id = this.Id,
                TenMucDo = this.TenMucDo,
                CauHoi = this.CauHoi?.Select(x => x.ToEntity()),
            };
        }
    }
}