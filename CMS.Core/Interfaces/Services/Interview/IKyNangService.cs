using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IKyNangService
    {
        IQueryable<KyNang> GetKyNang(string keywords = null, int? nhomKyNangId = null);
        Task<KyNang> GetKyNangById(int id);
        Task<ServiceResult> CreateKyNang(KyNang kyNang);
        Task<ServiceResult> UpdateKyNang(KyNang kyNang); 
        Task<ServiceResult> DeleteKyNang(int id);
    }
}

