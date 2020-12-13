using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface INhomKyNangService
    {
        IQueryable<NhomKyNang> GetNhomKyNang(string keywords = null);
        Task<NhomKyNang> GetNhomKyNangById(int id);
        Task<ServiceResult> CreateNhomKyNang(NhomKyNang nhomKyNang);
        Task<ServiceResult> UpdateNhomKyNang(NhomKyNang nhomKyNang);
        Task<ServiceResult> DeleteNhomKyNang(int id);
    }
}