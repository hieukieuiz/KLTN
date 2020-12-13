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
    public class BangCapUngVienService : IBangCapUngVienService
    {
        private readonly IRepository<BangCapUngVien> _bangCapUngVienRepository;
        //private readonly IRepository<CVUngVienService> _cVUngVienRepository;
        public BangCapUngVienService(IRepository<BangCapUngVien> bangCapUngVienRepository)
                             //IRepository<CVUngVienService> cVUngVienRepository)
        {
            _bangCapUngVienRepository = bangCapUngVienRepository;
            //_cVUngVienRepository = cVUngVienRepository;
        }
        public IQueryable<BangCapUngVien> GetBangCapUngVien(
                                           string keywords = null, int? cVUngVienId = null)
        {
            var query = _bangCapUngVienRepository.TableUntracked.Include(x => x.CVUngVien)
               .Where(x => true).AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(bangCapUngVien =>
                        bangCapUngVien.TenBang.Contains(keywords)
                    );
            }
            if (cVUngVienId.HasValue)
            {
                query = query.Where(cvungvien => cvungvien.Id == cVUngVienId);
            }
            return query;
        }
        public async Task<BangCapUngVien> GetBangCapUngVienById(int id)
        {
            return await _bangCapUngVienRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateBangCapUngVien(BangCapUngVien bangCapUngVien)
        {
            await _bangCapUngVienRepository.AddAsync(bangCapUngVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateBangCapUngVien(BangCapUngVien bangCapUngVien)
        {
            await _bangCapUngVienRepository.UpdateAsync(bangCapUngVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteBangCapUngVien(int id)
        {
            var bangCapUngVien = await _bangCapUngVienRepository.GetByIdAsync(id);
            await _bangCapUngVienRepository.DeleteAsync(bangCapUngVien);
            return ServiceResult.Success;
        }
    }
}