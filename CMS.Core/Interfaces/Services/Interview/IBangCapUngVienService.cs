using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.Interview
{
    public interface IBangCapUngVienService
    {
        IQueryable<BangCapUngVien> GetBangCapUngVien(string keywords = null, int? cVUngVienId = null);
        Task<BangCapUngVien> GetBangCapUngVienById(int id);
        Task<ServiceResult> CreateBangCapUngVien(BangCapUngVien bangCapUngVien);
        Task<ServiceResult> UpdateBangCapUngVien(BangCapUngVien bangCapUngVien);
        Task<ServiceResult> DeleteBangCapUngVien(int id);
    }
}
