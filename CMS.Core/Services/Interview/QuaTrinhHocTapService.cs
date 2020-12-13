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
    public class QuaTrinhHocTapService : IQuaTrinhHocTapService
    {
        private readonly IRepository<QuaTrinhHocTap> _quaTrinhHocTapRepository;
        //private readonly IRepository<CVUngVienService> _cVUngVienRepository;
        public QuaTrinhHocTapService(IRepository<QuaTrinhHocTap> quaTrinhHocTapRepository)
        //IRepository<CVUngVienService> cVUngVienRepository)
        {
            _quaTrinhHocTapRepository = quaTrinhHocTapRepository;
            //_cVUngVienRepository = cVUngVienRepository;
        }
        public IQueryable<QuaTrinhHocTap> GetQuaTrinhHocTap(
                                           string keywords = null, int? cVUngVienId = null)
        {
            var query = _quaTrinhHocTapRepository.TableUntracked.Include(x => x.CVUngVien)
               .Where(x => true).AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(bangCapUngVien =>
                        bangCapUngVien.NoiHocTap.Contains(keywords) ||
                        bangCapUngVien.ChuyenNganh.Contains(keywords)
                    );
            }
            if (cVUngVienId.HasValue)
            {
                query = query.Where(cvungvien => cvungvien.Id == cVUngVienId);
            }
            return query;
        }
        public async Task<QuaTrinhHocTap> GetQuaTrinhHocTapById(int id)
        {
            return await _quaTrinhHocTapRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap)
        {
            await _quaTrinhHocTapRepository.AddAsync(quaTrinhHocTap);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap)
        {
            await _quaTrinhHocTapRepository.UpdateAsync(quaTrinhHocTap);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteQuaTrinhHocTap(int id)
        {
            var quaTrinhHocTap = await _quaTrinhHocTapRepository.GetByIdAsync(id);
            await _quaTrinhHocTapRepository.DeleteAsync(quaTrinhHocTap);
            return ServiceResult.Success;
        }
    }
}
