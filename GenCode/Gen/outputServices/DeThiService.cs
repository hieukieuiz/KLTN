using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class DeThiService: IDeThiService
    {
        private readonly IRepository<DeThi> _deThiRepository;
        public DeThiService(IRepository<DeThi> deThiRepository)
        {
            _deThiRepository = deThiRepository;
        }
        public IQueryable<DeThi> GetDeThi(string keywords)
        {
            var query = _deThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(deThi =>
                        deThi.TenDeThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DeThi> GetDeThiById(int id)
        {
            return await _deThiRepository.GetByIdAsync(id);
        }
        public async Task CreateDeThi(DeThi deThi)
        {
            await _deThiRepository.AddAsync(deThi);
        }
        public async Task UpdateDeThi(DeThi deThi)
        {
            await _deThiRepository.UpdateAsync(deThi);
        }
        public async Task DeleteDeThi(int id)
        {
            var deThi = await _deThiRepository.GetByIdAsync(id);
            await _deThiRepository.DeleteAsync(deThi);
        }
    }
}