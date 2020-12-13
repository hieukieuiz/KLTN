using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class PhanViecService: IPhanViecService
    {
        private readonly IRepository<PhanViec> _phanViecRepository;
        public PhanViecService(IRepository<PhanViec> phanViecRepository)
        {
            _phanViecRepository = phanViecRepository;
        }
        public IQueryable<PhanViec> GetPhanViec(string keywords)
        {
            var query = _phanViecRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(phanViec =>
                        phanViec.TenPhanViec.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<PhanViec> GetPhanViecById(int id)
        {
            return await _phanViecRepository.GetByIdAsync(id);
        }
        public async Task CreatePhanViec(PhanViec phanViec)
        {
            await _phanViecRepository.AddAsync(phanViec);
        }
        public async Task UpdatePhanViec(PhanViec phanViec)
        {
            await _phanViecRepository.UpdateAsync(phanViec);
        }
        public async Task DeletePhanViec(int id)
        {
            var phanViec = await _phanViecRepository.GetByIdAsync(id);
            await _phanViecRepository.DeleteAsync(phanViec);
        }
    }
}