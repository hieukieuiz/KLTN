using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IQuaTrinhLamDuAnService
    {
        IQueryable<QuaTrinhLamDuAn> GetQuaTrinhLamDuAn(string keywords = null, int? cVUngVienId = null);
        Task<QuaTrinhLamDuAn> GetQuaTrinhLamDuAnById(int id);
        Task<ServiceResult> CreateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn);
        Task<ServiceResult> UpdateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn);
        Task<ServiceResult> DeleteQuaTrinhLamDuAn(int id);
    }
}