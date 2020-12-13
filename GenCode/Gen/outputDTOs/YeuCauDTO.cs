using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class YeuCauDTO
    {
        public int Id { get; set; }
        public string TenYeuCau { get; set; }
        public string GiaTriSoTu { get; set; }
        public string GiaTriSoDen { get; set; }
        public string GiaTriNoiDung { get; set; }
        public BaiTuyenDungDTO BaiTuyenDung { get; set; }
        public LoaiYeuCauDTO LoaiYeuCau { get; set; }
        public static YeuCauDTO FromEntity(YeuCau item)
        {
            return new YeuCauDTO()
            {
                Id = item.Id,
                TenYeuCau = item.TenYeuCau,
                GiaTriSoTu = item.GiaTriSoTu,
                GiaTriSoDen = item.GiaTriSoDen,
                GiaTriNoiDung = item.GiaTriNoiDung,
                BaiTuyenDung = item.BaiTuyenDung != null? BaiTuyenDungDTO.FromEntity(item.BaiTuyenDung) : null,
                LoaiYeuCau = item.LoaiYeuCau != null? LoaiYeuCauDTO.FromEntity(item.LoaiYeuCau) : null,
            };
        }
        public YeuCau ToEntity()
        {
            return new YeuCau()
            {
                Id = this.Id,
                TenYeuCau = this.TenYeuCau,
                GiaTriSoTu = this.GiaTriSoTu,
                GiaTriSoDen = this.GiaTriSoDen,
                GiaTriNoiDung = this.GiaTriNoiDung,
                BaiTuyenDung = this.BaiTuyenDung?.ToEntity(),
                LoaiYeuCau = this.LoaiYeuCau?.ToEntity(),
            };
        }
    }
}