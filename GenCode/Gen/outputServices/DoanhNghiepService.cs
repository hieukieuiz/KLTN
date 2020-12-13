using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class DoanhNghiepService: IDoanhNghiepService
    {
        private readonly IRepository<DoanhNghiep> _doanhNghiepRepository;
        public DoanhNghiepService(IRepository<DoanhNghiep> doanhNghiepRepository)
        {
            _doanhNghiepRepository = doanhNghiepRepository;
        }
        public IQueryable<DoanhNghiep> GetDoanhNghiep(string keywords)
        {
            var query = _doanhNghiepRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(doanhNghiep =>
                        doanhNghiep.TenDoanhNghiep.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DoanhNghiep> GetDoanhNghiepById(int id)
        {
            return await _doanhNghiepRepository.GetByIdAsync(id);
        }
        public async Task CreateDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            await _doanhNghiepRepository.AddAsync(doanhNghiep);
        }
        public async Task UpdateDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            await _doanhNghiepRepository.UpdateAsync(doanhNghiep);
        }
        public async Task DeleteDoanhNghiep(int id)
        {
            var doanhNghiep = await _doanhNghiepRepository.GetByIdAsync(id);
            await _doanhNghiepRepository.DeleteAsync(doanhNghiep);
        }
    }
}