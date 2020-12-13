using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ChiTietDeThiDTO
    {
        public int Id { get; set; }
        public int DeThiId { get; set; }
        public int CauHoiId { get; set; }
        public bool BatBuocTraLoi { get; set; }
        public int ThuTu { get; set; }
        public bool? HienThiSoThuTu { get; set; }
        public int? PhuThuocVaoCauHoiId { get; set; }
        public string GiaTriPhuThuoc { get; set; }
        public double DiemToiDa { get; set; }
        public bool DaoDapAn { get; set; }
        public DeThiDTO DeThi { get; set; }
        public CauHoiDTO CauHoi { get; set; }
        public IEnumerable<ChiTietDapAnDeThiDTO> ChiTietDapAnDeThi { get; set; }
        public static ChiTietDeThiDTO FromEntity(ChiTietDeThi item)
        {
            return new ChiTietDeThiDTO()
            {
                Id = item.Id,
                DeThiId = item.DeThiId,
                CauHoiId = item.CauHoiId,
                BatBuocTraLoi = item.BatBuocTraLoi,
                ThuTu = item.ThuTu,
                HienThiSoThuTu = item.HienThiSoThuTu,
                PhuThuocVaoCauHoiId = item.PhuThuocVaoCauHoiId,
                GiaTriPhuThuoc = item.GiaTriPhuThuoc,
                DiemToiDa = item.DiemToiDa,
                DaoDapAn = item.DaoDapAn,
                DeThi = item.DeThi != null? DeThiDTO.FromEntity(item.DeThi) : null,
                CauHoi = item.CauHoi != null? CauHoiDTO.FromEntity(item.CauHoi) : null,
                ChiTietDapAnDeThi = item.ChiTietDapAnDeThi?.Select(ChiTietDapAnDeThiDTO.FromEntity),
            };
        }
        public ChiTietDeThi ToEntity()
        {
            return new ChiTietDeThi()
            {
                Id = this.Id,
                DeThiId = this.DeThiId,
                CauHoiId = this.CauHoiId,
                BatBuocTraLoi = this.BatBuocTraLoi,
                ThuTu = this.ThuTu,
                HienThiSoThuTu = this.HienThiSoThuTu,
                PhuThuocVaoCauHoiId = this.PhuThuocVaoCauHoiId,
                GiaTriPhuThuoc = this.GiaTriPhuThuoc,
                DiemToiDa = this.DiemToiDa,
                DaoDapAn = this.DaoDapAn,
                DeThi = this.DeThi?.ToEntity(),
                CauHoi = this.CauHoi?.ToEntity(),
                ChiTietDapAnDeThi = this.ChiTietDapAnDeThi?.Select(x => x.ToEntity()),
            };
        }
    }
}