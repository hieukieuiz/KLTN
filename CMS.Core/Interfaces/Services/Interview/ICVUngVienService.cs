using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface ICVUngVienService
    {
        IQueryable<CVUngVien> GetCVUngVien(string keywords = null);
        Task<CVUngVien> GetCVUngVienById(int id);
        Task<ServiceResult> CreateCVUngVien(CVUngVien cVUngVien);
        Task<ServiceResult> UpdateCVUngVien(CVUngVien cVUngVien);
        Task<ServiceResult> DeleteCVUngVien(int id);
    }
}
