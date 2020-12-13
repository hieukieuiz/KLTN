using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class LoaiYeuCauService: ILoaiYeuCauService
    {
        private readonly IRepository<LoaiYeuCau> _loaiYeuCauRepository;
        public LoaiYeuCauService(IRepository<LoaiYeuCau> loaiYeuCauRepository)
        {
            _loaiYeuCauRepository = loaiYeuCauRepository;
        }
        public IQueryable<LoaiYeuCau> GetLoaiYeuCau(string keywords)
        {
            var query = _loaiYeuCauRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(loaiYeuCau =>
                        loaiYeuCau.TenLoaiYeuCau.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<LoaiYeuCau> GetLoaiYeuCauById(int id)
        {
            return await _loaiYeuCauRepository.GetByIdAsync(id);
        }
        public async Task CreateLoaiYeuCau(LoaiYeuCau loaiYeuCau)
        {
            await _loaiYeuCauRepository.AddAsync(loaiYeuCau);
        }
        public async Task UpdateLoaiYeuCau(LoaiYeuCau loaiYeuCau)
        {
            await _loaiYeuCauRepository.UpdateAsync(loaiYeuCau);
        }
        public async Task DeleteLoaiYeuCau(int id)
        {
            var loaiYeuCau = await _loaiYeuCauRepository.GetByIdAsync(id);
            await _loaiYeuCauRepository.DeleteAsync(loaiYeuCau);
        }
    }
}