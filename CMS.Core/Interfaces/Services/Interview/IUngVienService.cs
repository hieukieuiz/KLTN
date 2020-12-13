using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IUngVienService
    {
        IQueryable<UngVien> GetUngVien(string keywords = null, int? trangThaiId = null, int? tinhThanhId = null);
        Task<UngVien> GetUngVienById(int id);
        Task<ServiceResult> CreateUngVien(UngVien ungVien);
        Task<ServiceResult> UpdateUngVien(UngVien ungVien);
        Task<ServiceResult> DeleteUngVien(int id);
        Task<ServiceResult> UpdateThongTinUngVien(UngVien ungVien);
    }
}