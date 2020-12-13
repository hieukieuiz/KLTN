using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ChiTietBaiThiService: IChiTietBaiThiService
    {
        private readonly IRepository<ChiTietBaiThi> _chiTietBaiThiRepository;
        public ChiTietBaiThiService(IRepository<ChiTietBaiThi> chiTietBaiThiRepository)
        {
            _chiTietBaiThiRepository = chiTietBaiThiRepository;
        }
        public IQueryable<ChiTietBaiThi> GetChiTietBaiThi(string keywords)
        {
            var query = _chiTietBaiThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(chiTietBaiThi =>
                        chiTietBaiThi.TenChiTietBaiThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ChiTietBaiThi> GetChiTietBaiThiById(int id)
        {
            return await _chiTietBaiThiRepository.GetByIdAsync(id);
        }
        public async Task CreateChiTietBaiThi(ChiTietBaiThi chiTietBaiThi)
        {
            await _chiTietBaiThiRepository.AddAsync(chiTietBaiThi);
        }
        public async Task UpdateChiTietBaiThi(ChiTietBaiThi chiTietBaiThi)
        {
            await _chiTietBaiThiRepository.UpdateAsync(chiTietBaiThi);
        }
        public async Task DeleteChiTietBaiThi(int id)
        {
            var chiTietBaiThi = await _chiTietBaiThiRepository.GetByIdAsync(id);
            await _chiTietBaiThiRepository.DeleteAsync(chiTietBaiThi);
        }
    }
}