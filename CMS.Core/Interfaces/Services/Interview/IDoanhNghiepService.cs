using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IDoanhNghiepService
    {
        IQueryable<DoanhNghiep> GetDoanhNghiep(string keywords = null);
        Task<DoanhNghiep> GetDoanhNghiepById(int id);
        Task<ServiceResult> CreateDoanhNghiep(DoanhNghiep doanhNghiep);
        Task<ServiceResult> UpdateDoanhNghiep(DoanhNghiep doanhNghiep);
        Task<ServiceResult> DeleteDoanhNghiep(int id);
        IQueryable<BaiTuyenDung> GetDanhSachBaiTuyenDung(/*int doanhNghiepId*/);
    }
}
