using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IBaiTuyenDungService
    {
        IQueryable<BaiTuyenDung> GetBaiTuyenDung(string keywords = null/*, int? doanhNghiepId = null*/);
        Task<BaiTuyenDung> GetBaiTuyenDungById(int id);
        Task<ServiceResult> CreateBaiTuyenDung(BaiTuyenDung baiTuyenDung);
        Task<ServiceResult> UpdateBaiTuyenDung(BaiTuyenDung baiTuyenDung);
        Task<ServiceResult> DeleteBaiTuyenDung(int id);
    }
}
