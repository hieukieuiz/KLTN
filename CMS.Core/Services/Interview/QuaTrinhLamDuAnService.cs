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
    public class QuaTrinhLamDuAnService : IQuaTrinhLamDuAnService
    {
        private readonly IRepository<QuaTrinhLamDuAn> _quaTrinhLamDuAnRepository;
        //private readonly IRepository<CVUngVienService> _cVUngVienRepository;
        public QuaTrinhLamDuAnService(IRepository<QuaTrinhLamDuAn> quaTrinhLamDuAnRepository)
        //IRepository<CVUngVienService> cVUngVienRepository)
        {
            _quaTrinhLamDuAnRepository = quaTrinhLamDuAnRepository;
            //_cVUngVienRepository = cVUngVienRepository;
        }
        public IQueryable<QuaTrinhLamDuAn> GetQuaTrinhLamDuAn(
                                           string keywords = null, int? cVUngVienId = null)
        {
            var query = _quaTrinhLamDuAnRepository.TableUntracked.Include(x => x.CVUngVien)
               .Where(x => true).AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(quaTrinhLamDuAn =>
                        quaTrinhLamDuAn.TenCongTy.Contains(keywords) ||
                        quaTrinhLamDuAn.ViTri.Contains(keywords)
                    );
            }
            if (cVUngVienId.HasValue)
            {
                query = query.Where(cvungvien => cvungvien.Id == cVUngVienId);
            }
            return query;
        }
        public async Task<QuaTrinhLamDuAn> GetQuaTrinhLamDuAnById(int id)
        {
            return await _quaTrinhLamDuAnRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn)
        {
            await _quaTrinhLamDuAnRepository.AddAsync(quaTrinhLamDuAn);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn)
        {
            await _quaTrinhLamDuAnRepository.UpdateAsync(quaTrinhLamDuAn);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteQuaTrinhLamDuAn(int id)
        {
            var quaTrinhLamDuAn = await _quaTrinhLamDuAnRepository.GetByIdAsync(id);
            await _quaTrinhLamDuAnRepository.DeleteAsync(quaTrinhLamDuAn);
            return ServiceResult.Success;
        }
    }
}

