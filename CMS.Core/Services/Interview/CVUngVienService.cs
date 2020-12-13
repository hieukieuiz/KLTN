using CMS.Core.Entities;
using CMS.Core.Extensions;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services.Interview;
using CMS.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Interview
{
    public class CVUngVienService : ICVUngVienService
    {
        private readonly IRepository<CVUngVien> _cVUngVienRepository;
        private readonly IRepository<QuaTrinhHocTap> _quaTrinhHocTapRepository;
        private readonly IRepository<BangCapUngVien> _bangCapUngVienRepository;
        private readonly IRepository<QuaTrinhLamDuAn> _quaTrinhLamDuAnRepository;
        public CVUngVienService(IRepository<CVUngVien> cVUngVienRepository,
                             IRepository<QuaTrinhHocTap> quaTrinhHocTapRepository,
                             IRepository<BangCapUngVien> bangCapUngVienRepository,
                             IRepository<QuaTrinhLamDuAn> quaTrinhLamDuAnRepository)
        {
            _cVUngVienRepository = cVUngVienRepository;
            _quaTrinhHocTapRepository = quaTrinhHocTapRepository;
            _bangCapUngVienRepository = bangCapUngVienRepository;
            _quaTrinhLamDuAnRepository = quaTrinhLamDuAnRepository;
        }
        public IQueryable<CVUngVien> GetCVUngVien(
                                           string keywords)
        {
            var query = _cVUngVienRepository.TableUntracked
                                         .AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(cVUngVien =>
                        cVUngVien.DiaChi.Contains(keywords)
                    );
            }
            return query;
        }
        public async Task<CVUngVien> GetCVUngVienById(int id)
        {
            return await _cVUngVienRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateCVUngVien(CVUngVien cVUngVien)
        {
            await _cVUngVienRepository.AddAsync(cVUngVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateCVUngVien(CVUngVien cVUngVien)
        {
            await _cVUngVienRepository.UpdateAsync(cVUngVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteCVUngVien(int id)
        {
            var cVUngVien = await _cVUngVienRepository.GetByIdAsync(id);
            await _cVUngVienRepository.DeleteAsync(cVUngVien);
            return ServiceResult.Success;
        }
    }
}

