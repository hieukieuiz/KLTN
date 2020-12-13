using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IQuaTrinhHocTapService
    {
        IQueryable<QuaTrinhHocTap> GetQuaTrinhHocTap(string keywords = null, int? cVUngVienId = null);
        Task<QuaTrinhHocTap> GetQuaTrinhHocTapById(int id);
        Task<ServiceResult> CreateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap);
        Task<ServiceResult> UpdateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap);
        Task<ServiceResult> DeleteQuaTrinhHocTap(int id);
    }
}