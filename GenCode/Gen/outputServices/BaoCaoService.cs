using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class BaoCaoService: IBaoCaoService
    {
        private readonly IRepository<BaoCao> _baoCaoRepository;
        public BaoCaoService(IRepository<BaoCao> baoCaoRepository)
        {
            _baoCaoRepository = baoCaoRepository;
        }
        public IQueryable<BaoCao> GetBaoCao(string keywords)
        {
            var query = _baoCaoRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(baoCao =>
                        baoCao.TenBaoCao.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<BaoCao> GetBaoCaoById(int id)
        {
            return await _baoCaoRepository.GetByIdAsync(id);
        }
        public async Task CreateBaoCao(BaoCao baoCao)
        {
            await _baoCaoRepository.AddAsync(baoCao);
        }
        public async Task UpdateBaoCao(BaoCao baoCao)
        {
            await _baoCaoRepository.UpdateAsync(baoCao);
        }
        public async Task DeleteBaoCao(int id)
        {
            var baoCao = await _baoCaoRepository.GetByIdAsync(id);
            await _baoCaoRepository.DeleteAsync(baoCao);
        }
    }
}