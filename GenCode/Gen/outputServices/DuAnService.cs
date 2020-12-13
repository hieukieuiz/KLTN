using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class DuAnService: IDuAnService
    {
        private readonly IRepository<DuAn> _duAnRepository;
        public DuAnService(IRepository<DuAn> duAnRepository)
        {
            _duAnRepository = duAnRepository;
        }
        public IQueryable<DuAn> GetDuAn(string keywords)
        {
            var query = _duAnRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(duAn =>
                        duAn.TenDuAn.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DuAn> GetDuAnById(int id)
        {
            return await _duAnRepository.GetByIdAsync(id);
        }
        public async Task CreateDuAn(DuAn duAn)
        {
            await _duAnRepository.AddAsync(duAn);
        }
        public async Task UpdateDuAn(DuAn duAn)
        {
            await _duAnRepository.UpdateAsync(duAn);
        }
        public async Task DeleteDuAn(int id)
        {
            var duAn = await _duAnRepository.GetByIdAsync(id);
            await _duAnRepository.DeleteAsync(duAn);
        }
    }
}