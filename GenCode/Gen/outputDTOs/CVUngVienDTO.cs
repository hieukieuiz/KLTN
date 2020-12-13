using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class CVUngVienDTO
    {
        public int Id { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MucTieuCaNhan { get; set; }
        public string SoThich { get; set; }
        public UngVienDTO UngVien { get; set; }
        public IEnumerable<QuaTrinhHocTapDTO> QuaTrinhHocTap { get; set; }
        public IEnumerable<BangCapUngVienDTO> BangCapUngVien { get; set; }
        public IEnumerable<QuaTrinhLamDuAnDTO> QuaTrinhLamDuAn { get; set; }
        public static CVUngVienDTO FromEntity(CVUngVien item)
        {
            return new CVUngVienDTO()
            {
                Id = item.Id,
                NgaySinh = item.NgaySinh,
                GioiTinh = item.GioiTinh,
                DiaChi = item.DiaChi,
                MucTieuCaNhan = item.MucTieuCaNhan,
                SoThich = item.SoThich,
                UngVien = item.UngVien != null? UngVienDTO.FromEntity(item.UngVien) : null,
                QuaTrinhHocTap = item.QuaTrinhHocTap?.Select(QuaTrinhHocTapDTO.FromEntity),
                BangCapUngVien = item.BangCapUngVien?.Select(BangCapUngVienDTO.FromEntity),
                QuaTrinhLamDuAn = item.QuaTrinhLamDuAn?.Select(QuaTrinhLamDuAnDTO.FromEntity),
            };
        }
        public CVUngVien ToEntity()
        {
            return new CVUngVien()
            {
                Id = this.Id,
                NgaySinh = this.NgaySinh,
                GioiTinh = this.GioiTinh,
                DiaChi = this.DiaChi,
                MucTieuCaNhan = this.MucTieuCaNhan,
                SoThich = this.SoThich,
                UngVien = this.UngVien?.ToEntity(),
                QuaTrinhHocTap = this.QuaTrinhHocTap?.Select(x => x.ToEntity()),
                BangCapUngVien = this.BangCapUngVien?.Select(x => x.ToEntity()),
                QuaTrinhLamDuAn = this.QuaTrinhLamDuAn?.Select(x => x.ToEntity()),
            };
        }
    }
}