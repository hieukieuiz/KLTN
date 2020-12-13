using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class KetQuaBaiThiService: IKetQuaBaiThiService
    {
        private readonly IRepository<KetQuaBaiThi> _ketQuaBaiThiRepository;
        public KetQuaBaiThiService(IRepository<KetQuaBaiThi> ketQuaBaiThiRepository)
        {
            _ketQuaBaiThiRepository = ketQuaBaiThiRepository;
        }
        public IQueryable<KetQuaBaiThi> GetKetQuaBaiThi(string keywords)
        {
            var query = _ketQuaBaiThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(ketQuaBaiThi =>
                        ketQuaBaiThi.TenKetQuaBaiThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<KetQuaBaiThi> GetKetQuaBaiThiById(int id)
        {
            return await _ketQuaBaiThiRepository.GetByIdAsync(id);
        }
        public async Task CreateKetQuaBaiThi(KetQuaBaiThi ketQuaBaiThi)
        {
            await _ketQuaBaiThiRepository.AddAsync(ketQuaBaiThi);
        }
        public async Task UpdateKetQuaBaiThi(KetQuaBaiThi ketQuaBaiThi)
        {
            await _ketQuaBaiThiRepository.UpdateAsync(ketQuaBaiThi);
        }
        public async Task DeleteKetQuaBaiThi(int id)
        {
            var ketQuaBaiThi = await _ketQuaBaiThiRepository.GetByIdAsync(id);
            await _ketQuaBaiThiRepository.DeleteAsync(ketQuaBaiThi);
        }
    }
}