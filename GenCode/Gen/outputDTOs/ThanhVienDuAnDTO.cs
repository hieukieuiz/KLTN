using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ThanhVienDuAnDTO
    {
        public int Id { get; set; }
        public int? HocVienId { get; set; }
        public HocVienDTO HocVien { get; set; }
        public int? QuyenDuAnId { get; set; }
        public DateTime? NgayThamGia { get; set; }
        public string GhiChu { get; set; }
        public QuyenDuAnDTO QuyenDuAn { get; set; }
        public IEnumerable<PhanViecDTO> PhanViec { get; set; }
        public IEnumerable<LichSuChiTietCongViecDTO> LichSuChiTietCongViec { get; set; }
        public IEnumerable<BaoCaoDTO> BaoCao { get; set; }
        public IEnumerable<CongViecDTO> CongViec { get; set; }
        public static ThanhVienDuAnDTO FromEntity(ThanhVienDuAn item)
        {
            return new ThanhVienDuAnDTO()
            {
                Id = item.Id,
                HocVienId = item.HocVienId,
                HocVien = item.HocVien != null? HocVienDTO.FromEntity(item.HocVien) : null,
                QuyenDuAnId = item.QuyenDuAnId,
                NgayThamGia = item.NgayThamGia,
                GhiChu = item.GhiChu,
                QuyenDuAn = item.QuyenDuAn != null? QuyenDuAnDTO.FromEntity(item.QuyenDuAn) : null,
                PhanViec = item.PhanViec?.Select(PhanViecDTO.FromEntity),
                LichSuChiTietCongViec = item.LichSuChiTietCongViec?.Select(LichSuChiTietCongViecDTO.FromEntity),
                BaoCao = item.BaoCao?.Select(BaoCaoDTO.FromEntity),
                CongViec = item.CongViec?.Select(CongViecDTO.FromEntity),
            };
        }
        public ThanhVienDuAn ToEntity()
        {
            return new ThanhVienDuAn()
            {
                Id = this.Id,
                HocVienId = this.HocVienId,
                HocVien = this.HocVien?.ToEntity(),
                QuyenDuAnId = this.QuyenDuAnId,
                NgayThamGia = this.NgayThamGia,
                GhiChu = this.GhiChu,
                QuyenDuAn = this.QuyenDuAn?.ToEntity(),
                PhanViec = this.PhanViec?.Select(x => x.ToEntity()),
                LichSuChiTietCongViec = this.LichSuChiTietCongViec?.Select(x => x.ToEntity()),
                BaoCao = this.BaoCao?.Select(x => x.ToEntity()),
                CongViec = this.CongViec?.Select(x => x.ToEntity()),
            };
        }
    }
}