using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class TrangThaiDuAnDTO
    {
        public int Id { get; set; }
        public int? DuAnId { get; set; }
        public DuAnDTO DuAn { get; set; }
        public int? TrangThaiId { get; set; }
        public TrangThaiDTO TrangThai { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public static TrangThaiDuAnDTO FromEntity(TrangThaiDuAn item)
        {
            return new TrangThaiDuAnDTO()
            {
                Id = item.Id,
                DuAnId = item.DuAnId,
                DuAn = item.DuAn != null? DuAnDTO.FromEntity(item.DuAn) : null,
                TrangThaiId = item.TrangThaiId,
                TrangThai = item.TrangThai != null? TrangThaiDTO.FromEntity(item.TrangThai) : null,
                ThoiGianTao = item.ThoiGianTao,
            };
        }
        public TrangThaiDuAn ToEntity()
        {
            return new TrangThaiDuAn()
            {
                Id = this.Id,
                DuAnId = this.DuAnId,
                DuAn = this.DuAn?.ToEntity(),
                TrangThaiId = this.TrangThaiId,
                TrangThai = this.TrangThai?.ToEntity(),
                ThoiGianTao = this.ThoiGianTao,
            };
        }
    }
}