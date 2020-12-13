using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class BaiThiService: IBaiThiService
    {
        private readonly IRepository<BaiThi> _baiThiRepository;
        public BaiThiService(IRepository<BaiThi> baiThiRepository)
        {
            _baiThiRepository = baiThiRepository;
        }
        public IQueryable<BaiThi> GetBaiThi(string keywords)
        {
            var query = _baiThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(baiThi =>
                        baiThi.TenBaiThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<BaiThi> GetBaiThiById(int id)
        {
            return await _baiThiRepository.GetByIdAsync(id);
        }
        public async Task CreateBaiThi(BaiThi baiThi)
        {
            await _baiThiRepository.AddAsync(baiThi);
        }
        public async Task UpdateBaiThi(BaiThi baiThi)
        {
            await _baiThiRepository.UpdateAsync(baiThi);
        }
        public async Task DeleteBaiThi(int id)
        {
            var baiThi = await _baiThiRepository.GetByIdAsync(id);
            await _baiThiRepository.DeleteAsync(baiThi);
        }
    }
}