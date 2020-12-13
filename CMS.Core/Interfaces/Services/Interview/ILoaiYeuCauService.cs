using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface ILoaiYeuCauService
    {
        IQueryable<LoaiYeuCau> GetLoaiYeuCau(string keywords = null);
        Task<LoaiYeuCau> GetLoaiYeuCauById(int id);
        Task<ServiceResult> CreateLoaiYeuCau(LoaiYeuCau loaiYeuCau);
        Task<ServiceResult> UpdateLoaiYeuCau(LoaiYeuCau loaiYeuCau);
        Task<ServiceResult> DeleteLoaiYeuCau(int id);
    }
}