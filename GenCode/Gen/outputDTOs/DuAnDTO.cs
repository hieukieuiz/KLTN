using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class DuAnDTO
    {
        public int Id { get; set; }
        public string TenDuAn { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianHetHan { get; set; }
        public string<DTO> MoTa { get; set; }
        public IEnumerable<TrangThaiDuAnDTO> TrangThaiDuAn { get; set; }
        public IEnumerable<QuyenDuAnDTO> QuyenDuAn { get; set; }
        public IEnumerable<CongViecDTO> CongViec { get; set; }
        public static DuAnDTO FromEntity(DuAn item)
        {
            return new DuAnDTO()
            {
                Id = item.Id,
                TenDuAn = item.TenDuAn,
                ThoiGianTao = item.ThoiGianTao,
                ThoiGianCapNhat = item.ThoiGianCapNhat,
                ThoiGianHetHan = item.ThoiGianHetHan,
                MoTa = item.MoTa?.Select(DTO.FromEntity),
                TrangThaiDuAn = item.TrangThaiDuAn?.Select(TrangThaiDuAnDTO.FromEntity),
                QuyenDuAn = item.QuyenDuAn?.Select(QuyenDuAnDTO.FromEntity),
                CongViec = item.CongViec?.Select(CongViecDTO.FromEntity),
            };
        }
        public DuAn ToEntity()
        {
            return new DuAn()
            {
                Id = this.Id,
                TenDuAn = this.TenDuAn,
                ThoiGianTao = this.ThoiGianTao,
                ThoiGianCapNhat = this.ThoiGianCapNhat,
                ThoiGianHetHan = this.ThoiGianHetHan,
                MoTa = this.MoTa?.Select(x => x.ToEntity()),
                TrangThaiDuAn = this.TrangThaiDuAn?.Select(x => x.ToEntity()),
                QuyenDuAn = this.QuyenDuAn?.Select(x => x.ToEntity()),
                CongViec = this.CongViec?.Select(x => x.ToEntity()),
            };
        }
    }
}