using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ChiTietDeThiService: IChiTietDeThiService
    {
        private readonly IRepository<ChiTietDeThi> _chiTietDeThiRepository;
        public ChiTietDeThiService(IRepository<ChiTietDeThi> chiTietDeThiRepository)
        {
            _chiTietDeThiRepository = chiTietDeThiRepository;
        }
        public IQueryable<ChiTietDeThi> GetChiTietDeThi(string keywords)
        {
            var query = _chiTietDeThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(chiTietDeThi =>
                        chiTietDeThi.TenChiTietDeThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ChiTietDeThi> GetChiTietDeThiById(int id)
        {
            return await _chiTietDeThiRepository.GetByIdAsync(id);
        }
        public async Task CreateChiTietDeThi(ChiTietDeThi chiTietDeThi)
        {
            await _chiTietDeThiRepository.AddAsync(chiTietDeThi);
        }
        public async Task UpdateChiTietDeThi(ChiTietDeThi chiTietDeThi)
        {
            await _chiTietDeThiRepository.UpdateAsync(chiTietDeThi);
        }
        public async Task DeleteChiTietDeThi(int id)
        {
            var chiTietDeThi = await _chiTietDeThiRepository.GetByIdAsync(id);
            await _chiTietDeThiRepository.DeleteAsync(chiTietDeThi);
        }
    }
}