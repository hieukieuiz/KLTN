using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class QuyenDTO
    {
        public int Id { get; set; }
        public string TenQuyen { get; set; }
        public IEnumerable<QuyenDuAnDTO> QuyenDuAn { get; set; }
        public static QuyenDTO FromEntity(Quyen item)
        {
            return new QuyenDTO()
            {
                Id = item.Id,
                TenQuyen = item.TenQuyen,
                QuyenDuAn = item.QuyenDuAn?.Select(QuyenDuAnDTO.FromEntity),
            };
        }
        public Quyen ToEntity()
        {
            return new Quyen()
            {
                Id = this.Id,
                TenQuyen = this.TenQuyen,
                QuyenDuAn = this.QuyenDuAn?.Select(x => x.ToEntity()),
            };
        }
    }
}