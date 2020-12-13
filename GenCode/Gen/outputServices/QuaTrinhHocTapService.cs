using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class QuaTrinhHocTapService: IQuaTrinhHocTapService
    {
        private readonly IRepository<QuaTrinhHocTap> _quaTrinhHocTapRepository;
        public QuaTrinhHocTapService(IRepository<QuaTrinhHocTap> quaTrinhHocTapRepository)
        {
            _quaTrinhHocTapRepository = quaTrinhHocTapRepository;
        }
        public IQueryable<QuaTrinhHocTap> GetQuaTrinhHocTap(string keywords)
        {
            var query = _quaTrinhHocTapRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(quaTrinhHocTap =>
                        quaTrinhHocTap.TenQuaTrinhHocTap.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<QuaTrinhHocTap> GetQuaTrinhHocTapById(int id)
        {
            return await _quaTrinhHocTapRepository.GetByIdAsync(id);
        }
        public async Task CreateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap)
        {
            await _quaTrinhHocTapRepository.AddAsync(quaTrinhHocTap);
        }
        public async Task UpdateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap)
        {
            await _quaTrinhHocTapRepository.UpdateAsync(quaTrinhHocTap);
        }
        public async Task DeleteQuaTrinhHocTap(int id)
        {
            var quaTrinhHocTap = await _quaTrinhHocTapRepository.GetByIdAsync(id);
            await _quaTrinhHocTapRepository.DeleteAsync(quaTrinhHocTap);
        }
    }
}