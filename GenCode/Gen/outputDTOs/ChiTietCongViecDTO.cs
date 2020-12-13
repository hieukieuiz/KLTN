using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ChiTietCongViecDTO
    {
        public int Id { get; set; }
        public int? CongViecId { get; set; }
        public CongViecDTO CongViec { get; set; }
        public int? TrangThaiId { get; set; }
        public TrangThaiDTO TrangThai { get; set; }
        public string TenChiTietCongViec { get; set; }
        public DateTime NgayHetHan { get; set; }
        public IEnumerable<LichSuChiTietCongViecDTO> LichSuChiTietCongViec { get; set; }
        public IEnumerable<BaoCaoDTO> BaoCao { get; set; }
        public static ChiTietCongViecDTO FromEntity(ChiTietCongViec item)
        {
            return new ChiTietCongViecDTO()
            {
                Id = item.Id,
                CongViecId = item.CongViecId,
                CongViec = item.CongViec != null? CongViecDTO.FromEntity(item.CongViec) : null,
                TrangThaiId = item.TrangThaiId,
                TrangThai = item.TrangThai != null? TrangThaiDTO.FromEntity(item.TrangThai) : null,
                TenChiTietCongViec = item.TenChiTietCongViec,
                NgayHetHan = item.NgayHetHan,
                LichSuChiTietCongViec = item.LichSuChiTietCongViec?.Select(LichSuChiTietCongViecDTO.FromEntity),
                BaoCao = item.BaoCao?.Select(BaoCaoDTO.FromEntity),
            };
        }
        public ChiTietCongViec ToEntity()
        {
            return new ChiTietCongViec()
            {
                Id = this.Id,
                CongViecId = this.CongViecId,
                CongViec = this.CongViec?.ToEntity(),
                TrangThaiId = this.TrangThaiId,
                TrangThai = this.TrangThai?.ToEntity(),
                TenChiTietCongViec = this.TenChiTietCongViec,
                NgayHetHan = this.NgayHetHan,
                LichSuChiTietCongViec = this.LichSuChiTietCongViec?.Select(x => x.ToEntity()),
                BaoCao = this.BaoCao?.Select(x => x.ToEntity()),
            };
        }
    }
}