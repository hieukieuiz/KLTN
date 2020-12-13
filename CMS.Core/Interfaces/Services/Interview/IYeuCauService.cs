using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IYeuCauService
    {
        IQueryable<YeuCau> GetYeuCau(string keywords = null);
        Task<YeuCau> GetYeuCauById(int id);
        Task<ServiceResult> CreateYeuCau(YeuCau yeuCau);
        Task<ServiceResult> UpdateYeuCau(YeuCau yeuCau);
        Task<ServiceResult> DeleteYeuCau(int id);
    }
}