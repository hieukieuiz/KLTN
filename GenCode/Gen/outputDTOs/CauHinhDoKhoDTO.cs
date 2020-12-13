using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class CauHinhDoKhoDTO
    {
        public int Id { get; set; }
        public int DeThiId { get; set; }
        public int? MucDoId { get; set; }
        public int? SoLuongCauHoi { get; set; }
        public double Diem { get; set; }
        public bool DaoDapAn { get; set; }
        public DeThiDTO DeThi { get; set; }
        public MucDoDTO MucDo { get; set; }
        public static CauHinhDoKhoDTO FromEntity(CauHinhDoKho item)
        {
            return new CauHinhDoKhoDTO()
            {
                Id = item.Id,
                DeThiId = item.DeThiId,
                MucDoId = item.MucDoId,
                SoLuongCauHoi = item.SoLuongCauHoi,
                Diem = item.Diem,
                DaoDapAn = item.DaoDapAn,
                DeThi = item.DeThi != null? DeThiDTO.FromEntity(item.DeThi) : null,
                MucDo = item.MucDo != null? MucDoDTO.FromEntity(item.MucDo) : null,
            };
        }
        public CauHinhDoKho ToEntity()
        {
            return new CauHinhDoKho()
            {
                Id = this.Id,
                DeThiId = this.DeThiId,
                MucDoId = this.MucDoId,
                SoLuongCauHoi = this.SoLuongCauHoi,
                Diem = this.Diem,
                DaoDapAn = this.DaoDapAn,
                DeThi = this.DeThi?.ToEntity(),
                MucDo = this.MucDo?.ToEntity(),
            };
        }
    }
}