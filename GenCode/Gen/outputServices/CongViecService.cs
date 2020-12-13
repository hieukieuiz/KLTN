using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class CongViecService: ICongViecService
    {
        private readonly IRepository<CongViec> _congViecRepository;
        public CongViecService(IRepository<CongViec> congViecRepository)
        {
            _congViecRepository = congViecRepository;
        }
        public IQueryable<CongViec> GetCongViec(string keywords)
        {
            var query = _congViecRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(congViec =>
                        congViec.TenCongViec.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<CongViec> GetCongViecById(int id)
        {
            return await _congViecRepository.GetByIdAsync(id);
        }
        public async Task CreateCongViec(CongViec congViec)
        {
            await _congViecRepository.AddAsync(congViec);
        }
        public async Task UpdateCongViec(CongViec congViec)
        {
            await _congViecRepository.UpdateAsync(congViec);
        }
        public async Task DeleteCongViec(int id)
        {
            var congViec = await _congViecRepository.GetByIdAsync(id);
            await _congViecRepository.DeleteAsync(congViec);
        }
    }
}