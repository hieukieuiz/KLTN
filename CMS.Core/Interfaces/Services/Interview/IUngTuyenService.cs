using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IUngTuyenService
    {
        IQueryable<UngTuyen> GetUngTuyen(string keywords = null);
        Task<UngTuyen> GetUngTuyenById(int id);
        Task<ServiceResult> CreateUngTuyen(UngTuyen ungTuyen);
        Task<ServiceResult> UpdateUngTuyen(UngTuyen ungTuyen);
        Task<ServiceResult> DeleteUngTuyen(int id);
    }
}