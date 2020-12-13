using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class NguonDeThiService: INguonDeThiService
    {
        private readonly IRepository<NguonDeThi> _nguonDeThiRepository;
        public NguonDeThiService(IRepository<NguonDeThi> nguonDeThiRepository)
        {
            _nguonDeThiRepository = nguonDeThiRepository;
        }
        public IQueryable<NguonDeThi> GetNguonDeThi(string keywords)
        {
            var query = _nguonDeThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(nguonDeThi =>
                        nguonDeThi.TenNguonDeThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<NguonDeThi> GetNguonDeThiById(int id)
        {
            return await _nguonDeThiRepository.GetByIdAsync(id);
        }
        public async Task CreateNguonDeThi(NguonDeThi nguonDeThi)
        {
            await _nguonDeThiRepository.AddAsync(nguonDeThi);
        }
        public async Task UpdateNguonDeThi(NguonDeThi nguonDeThi)
        {
            await _nguonDeThiRepository.UpdateAsync(nguonDeThi);
        }
        public async Task DeleteNguonDeThi(int id)
        {
            var nguonDeThi = await _nguonDeThiRepository.GetByIdAsync(id);
            await _nguonDeThiRepository.DeleteAsync(nguonDeThi);
        }
    }
}