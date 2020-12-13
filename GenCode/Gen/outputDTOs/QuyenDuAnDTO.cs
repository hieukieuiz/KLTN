using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class QuyenDuAnDTO
    {
        public int Id { get; set; }
        public int DuAnId { get; set; }
        public DuAnDTO DuAn { get; set; }
        public int? QuyenId { get; set; }
        public QuyenDTO Quyen { get; set; }
        public IEnumerable<ThanhVienDuAnDTO> ThanhVienDuAn { get; set; }
        public static QuyenDuAnDTO FromEntity(QuyenDuAn item)
        {
            return new QuyenDuAnDTO()
            {
                Id = item.Id,
                DuAnId = item.DuAnId,
                DuAn = item.DuAn != null? DuAnDTO.FromEntity(item.DuAn) : null,
                QuyenId = item.QuyenId,
                Quyen = item.Quyen != null? QuyenDTO.FromEntity(item.Quyen) : null,
                ThanhVienDuAn = item.ThanhVienDuAn?.Select(ThanhVienDuAnDTO.FromEntity),
            };
        }
        public QuyenDuAn ToEntity()
        {
            return new QuyenDuAn()
            {
                Id = this.Id,
                DuAnId = this.DuAnId,
                DuAn = this.DuAn?.ToEntity(),
                QuyenId = this.QuyenId,
                Quyen = this.Quyen?.ToEntity(),
                ThanhVienDuAn = this.ThanhVienDuAn?.Select(x => x.ToEntity()),
            };
        }
    }
}