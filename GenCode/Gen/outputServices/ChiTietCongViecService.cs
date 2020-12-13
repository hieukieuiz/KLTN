using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ChiTietCongViecService: IChiTietCongViecService
    {
        private readonly IRepository<ChiTietCongViec> _chiTietCongViecRepository;
        public ChiTietCongViecService(IRepository<ChiTietCongViec> chiTietCongViecRepository)
        {
            _chiTietCongViecRepository = chiTietCongViecRepository;
        }
        public IQueryable<ChiTietCongViec> GetChiTietCongViec(string keywords)
        {
            var query = _chiTietCongViecRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(chiTietCongViec =>
                        chiTietCongViec.TenChiTietCongViec.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ChiTietCongViec> GetChiTietCongViecById(int id)
        {
            return await _chiTietCongViecRepository.GetByIdAsync(id);
        }
        public async Task CreateChiTietCongViec(ChiTietCongViec chiTietCongViec)
        {
            await _chiTietCongViecRepository.AddAsync(chiTietCongViec);
        }
        public async Task UpdateChiTietCongViec(ChiTietCongViec chiTietCongViec)
        {
            await _chiTietCongViecRepository.UpdateAsync(chiTietCongViec);
        }
        public async Task DeleteChiTietCongViec(int id)
        {
            var chiTietCongViec = await _chiTietCongViecRepository.GetByIdAsync(id);
            await _chiTietCongViecRepository.DeleteAsync(chiTietCongViec);
        }
    }
}