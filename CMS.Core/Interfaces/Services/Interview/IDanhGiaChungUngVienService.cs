using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IDanhGiaChungUngVienService
    {
        IQueryable<DanhGiaChungUngVien> GetDanhGiaChungUngVien(string keywords = null);
        Task<DanhGiaChungUngVien> GetDanhGiaChungUngVienById(int id);
        Task<ServiceResult> CreateDanhGiaChungUngVien(DanhGiaChungUngVien danhGiaChungUngVien);
        Task<ServiceResult> UpdateDanhGiaChungUngVien(DanhGiaChungUngVien danhGiaChungUngVien);
        Task<ServiceResult> DeleteDanhGiaChungUngVien(int id);
    }
}
