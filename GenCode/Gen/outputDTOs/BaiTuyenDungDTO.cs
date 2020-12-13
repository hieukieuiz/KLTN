using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class BaiTuyenDungDTO
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public int DoanhNghiepId { get; set; }
        public string AnhDaiDien { get; set; }
        public string KyHieu { get; set; }
        public string LinkAnhMinhHoa { get; set; }
        public bool HienThi { get; set; }
        public string GioiThieu { get; set; }
        public string NgayDang { get; set; }
        public string SoLuongTuyen { get; set; }
        public string ThanhPho { get; set; }
        public string MucLuong { get; set; }
        public string KinhNghiem { get; set; }
        public string GioiTinh { get; set; }
        public string TrinhDo { get; set; }
        public string TinhChatCongViec { get; set; }
        public string HinhThuc { get; set; }
        public string ThoiGianThuViec { get; set; }
        public string NganhNghe { get; set; }
        public string MoTa { get; set; }
        public string QuyenLoi { get; set; }
        public DoanhNghiepDTO DoanhNghiep { get; set; }
        public IEnumerable<UngTuyenDTO> UngTuyen { get; set; }
        public IEnumerable<YeuCauDTO> YeuCau { get; set; }
        public static BaiTuyenDungDTO FromEntity(BaiTuyenDung item)
        {
            return new BaiTuyenDungDTO()
            {
                Id = item.Id,
                TieuDe = item.TieuDe,
                DoanhNghiepId = item.DoanhNghiepId,
                AnhDaiDien = item.AnhDaiDien,
                KyHieu = item.KyHieu,
                LinkAnhMinhHoa = item.LinkAnhMinhHoa,
                HienThi = item.HienThi,
                GioiThieu = item.GioiThieu,
                NgayDang = item.NgayDang,
                SoLuongTuyen = item.SoLuongTuyen,
                ThanhPho = item.ThanhPho,
                MucLuong = item.MucLuong,
                KinhNghiem = item.KinhNghiem,
                GioiTinh = item.GioiTinh,
                TrinhDo = item.TrinhDo,
                TinhChatCongViec = item.TinhChatCongViec,
                HinhThuc = item.HinhThuc,
                ThoiGianThuViec = item.ThoiGianThuViec,
                NganhNghe = item.NganhNghe,
                MoTa = item.MoTa,
                QuyenLoi = item.QuyenLoi,
                DoanhNghiep = item.DoanhNghiep != null? DoanhNghiepDTO.FromEntity(item.DoanhNghiep) : null,
                UngTuyen = item.UngTuyen?.Select(UngTuyenDTO.FromEntity),
                YeuCau = item.YeuCau?.Select(YeuCauDTO.FromEntity),
            };
        }
        public BaiTuyenDung ToEntity()
        {
            return new BaiTuyenDung()
            {
                Id = this.Id,
                TieuDe = this.TieuDe,
                DoanhNghiepId = this.DoanhNghiepId,
                AnhDaiDien = this.AnhDaiDien,
                KyHieu = this.KyHieu,
                LinkAnhMinhHoa = this.LinkAnhMinhHoa,
                HienThi = this.HienThi,
                GioiThieu = this.GioiThieu,
                NgayDang = this.NgayDang,
                SoLuongTuyen = this.SoLuongTuyen,
                ThanhPho = this.ThanhPho,
                MucLuong = this.MucLuong,
                KinhNghiem = this.KinhNghiem,
                GioiTinh = this.GioiTinh,
                TrinhDo = this.TrinhDo,
                TinhChatCongViec = this.TinhChatCongViec,
                HinhThuc = this.HinhThuc,
                ThoiGianThuViec = this.ThoiGianThuViec,
                NganhNghe = this.NganhNghe,
                MoTa = this.MoTa,
                QuyenLoi = this.QuyenLoi,
                DoanhNghiep = this.DoanhNghiep?.ToEntity(),
                UngTuyen = this.UngTuyen?.Select(x => x.ToEntity()),
                YeuCau = this.YeuCau?.Select(x => x.ToEntity()),
            };
        }
    }
}