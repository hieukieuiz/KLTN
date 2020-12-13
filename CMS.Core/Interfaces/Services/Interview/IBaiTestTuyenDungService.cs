using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IBaiTestTuyenDungService
    {
        IQueryable<BaiTestTuyenDung> GetBaiTestTuyenDung(string keywords = null);
        Task<BaiTestTuyenDung> GetBaiTestTuyenDungById(int id);
        Task<ServiceResult> CreateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung);
        Task<ServiceResult> UpdateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung);
        Task<ServiceResult> DeleteBaiTestTuyenDung(int id);
    }
}
