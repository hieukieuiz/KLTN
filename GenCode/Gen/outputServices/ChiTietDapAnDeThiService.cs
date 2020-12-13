using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ChiTietDapAnDeThiService: IChiTietDapAnDeThiService
    {
        private readonly IRepository<ChiTietDapAnDeThi> _chiTietDapAnDeThiRepository;
        public ChiTietDapAnDeThiService(IRepository<ChiTietDapAnDeThi> chiTietDapAnDeThiRepository)
        {
            _chiTietDapAnDeThiRepository = chiTietDapAnDeThiRepository;
        }
        public IQueryable<ChiTietDapAnDeThi> GetChiTietDapAnDeThi(string keywords)
        {
            var query = _chiTietDapAnDeThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(chiTietDapAnDeThi =>
                        chiTietDapAnDeThi.TenChiTietDapAnDeThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ChiTietDapAnDeThi> GetChiTietDapAnDeThiById(int id)
        {
            return await _chiTietDapAnDeThiRepository.GetByIdAsync(id);
        }
        public async Task CreateChiTietDapAnDeThi(ChiTietDapAnDeThi chiTietDapAnDeThi)
        {
            await _chiTietDapAnDeThiRepository.AddAsync(chiTietDapAnDeThi);
        }
        public async Task UpdateChiTietDapAnDeThi(ChiTietDapAnDeThi chiTietDapAnDeThi)
        {
            await _chiTietDapAnDeThiRepository.UpdateAsync(chiTietDapAnDeThi);
        }
        public async Task DeleteChiTietDapAnDeThi(int id)
        {
            var chiTietDapAnDeThi = await _chiTietDapAnDeThiRepository.GetByIdAsync(id);
            await _chiTietDapAnDeThiRepository.DeleteAsync(chiTietDapAnDeThi);
        }
    }
}