using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IUngVienLamBaiTestService
    {
        IQueryable<UngVienLamBaiTest> GetUngVienLamBaiTest(string keywords = null);
        Task<UngVienLamBaiTest> GetUngVienLamBaiTestById(int id);
        Task<ServiceResult> CreateUngVienLamBaiTest(UngVienLamBaiTest ungVienLamBaiTest);
        Task<ServiceResult> UpdateUngVienLamBaiTest(UngVienLamBaiTest ungVienLamBaiTest);
        Task<ServiceResult> DeleteUngVienLamBaiTest(int id);
    }
}