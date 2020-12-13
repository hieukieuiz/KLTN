using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class BaiThiDTO
    {
        public int Id { get; set; }
        public int DeThiId { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianHoanThanh { get; set; }
        public DateTime? NgayCham { get; set; }
        public double? TongDiemCham { get; set; }
        public double? TongDiemToiDa { get; set; }
        public bool DaNopBai { get; set; }
        public bool DaChamDiem { get; set; }
        public bool DaBaoKetQua { get; set; }
        public DeThiDTO DeThi { get; set; }
        public UngVienDTO UngVien { get; set; }
        public IEnumerable<ChiTietBaiThiDTO> ChiTietBaiThi { get; set; }
        public IEnumerable<BaiTestTuyenDungDTO> BaiTestTuyenDung { get; set; }
        public static BaiThiDTO FromEntity(BaiThi item)
        {
            return new BaiThiDTO()
            {
                Id = item.Id,
                DeThiId = item.DeThiId,
                TaiKhoan = item.TaiKhoan,
                ThoiGianTao = item.ThoiGianTao,
                ThoiGianHoanThanh = item.ThoiGianHoanThanh,
                NgayCham = item.NgayCham,
                TongDiemCham = item.TongDiemCham,
                TongDiemToiDa = item.TongDiemToiDa,
                DaNopBai = item.DaNopBai,
                DaChamDiem = item.DaChamDiem,
                DaBaoKetQua = item.DaBaoKetQua,
                DeThi = item.DeThi != null? DeThiDTO.FromEntity(item.DeThi) : null,
                UngVien = item.UngVien != null? UngVienDTO.FromEntity(item.UngVien) : null,
                ChiTietBaiThi = item.ChiTietBaiThi?.Select(ChiTietBaiThiDTO.FromEntity),
                BaiTestTuyenDung = item.BaiTestTuyenDung?.Select(BaiTestTuyenDungDTO.FromEntity),
            };
        }
        public BaiThi ToEntity()
        {
            return new BaiThi()
            {
                Id = this.Id,
                DeThiId = this.DeThiId,
                TaiKhoan = this.TaiKhoan,
                ThoiGianTao = this.ThoiGianTao,
                ThoiGianHoanThanh = this.ThoiGianHoanThanh,
                NgayCham = this.NgayCham,
                TongDiemCham = this.TongDiemCham,
                TongDiemToiDa = this.TongDiemToiDa,
                DaNopBai = this.DaNopBai,
                DaChamDiem = this.DaChamDiem,
                DaBaoKetQua = this.DaBaoKetQua,
                DeThi = this.DeThi?.ToEntity(),
                UngVien = this.UngVien?.ToEntity(),
                ChiTietBaiThi = this.ChiTietBaiThi?.Select(x => x.ToEntity()),
                BaiTestTuyenDung = this.BaiTestTuyenDung?.Select(x => x.ToEntity()),
            };
        }
    }
}