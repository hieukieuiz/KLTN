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
    public class KyNangService : IKyNangService
    {
        private readonly IRepository<KyNang> _kyNangRepository;
        //private readonly IRepository<CVUngVienService> _cVUngVienRepository;
        public KyNangService(IRepository<KyNang> kyNangRepository)
        //IRepository<CVUngVienService> cVUngVienRepository)
        {
            _kyNangRepository = kyNangRepository;
            //_cVUngVienRepository = cVUngVienRepository;
        }
        public IQueryable<KyNang> GetKyNang(
                                           string keywords = null, int? nhomKyNangId = null)
        {
            var query = _kyNangRepository.TableUntracked.Include(x => x.NhomKyNang)
               .Where(x => true).AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(kyNang =>
                        kyNang.TenKyNang.Contains(keywords)
                    );
            }
            if (nhomKyNangId.HasValue)
            {
                query = query.Where(nhomkynang => nhomkynang.Id == nhomKyNangId);
            }
            return query;
        }
        public async Task<KyNang> GetKyNangById(int id)
        {
            return await _kyNangRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateKyNang(KyNang kyNang)
        {
            await _kyNangRepository.AddAsync(kyNang);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateKyNang(KyNang kyNang)
        {
            await _kyNangRepository.UpdateAsync(kyNang);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteKyNang(int id)
        {
            var kyNang = await _kyNangRepository.GetByIdAsync(id);
            await _kyNangRepository.DeleteAsync(kyNang);
            return ServiceResult.Success;
        }
    }
}


