using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Web.ApiModels
{
    public class BaiTestTuyenDungDTO
    {
        public int Id { get; set; }
        public string DiemPass { get; set; }
        public virtual IEnumerable<BaiTuyenDungDTO> BaiTuyenDung { get; set; }
        public static BaiTestTuyenDungDTO FromEntity(BaiTestTuyenDung item)
        {
            return new BaiTestTuyenDungDTO()
            {
                Id = item.Id,
                DiemPass = item.DiemPass,
                //BaiTuyenDung = item.BaiTuyenDung?.Select(x => BaiTuyenDungDTO.FromEntity(x))
            };
        }
        public BaiTestTuyenDung ToEntity()
        {
            return new BaiTestTuyenDung()
            {
                Id = this.Id,
                DiemPass = this.DiemPass,
            };
        }

    }
}
