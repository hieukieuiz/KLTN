using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class QuaTrinhLamDuAnService: IQuaTrinhLamDuAnService
    {
        private readonly IRepository<QuaTrinhLamDuAn> _quaTrinhLamDuAnRepository;
        public QuaTrinhLamDuAnService(IRepository<QuaTrinhLamDuAn> quaTrinhLamDuAnRepository)
        {
            _quaTrinhLamDuAnRepository = quaTrinhLamDuAnRepository;
        }
        public IQueryable<QuaTrinhLamDuAn> GetQuaTrinhLamDuAn(string keywords)
        {
            var query = _quaTrinhLamDuAnRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(quaTrinhLamDuAn =>
                        quaTrinhLamDuAn.TenQuaTrinhLamDuAn.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<QuaTrinhLamDuAn> GetQuaTrinhLamDuAnById(int id)
        {
            return await _quaTrinhLamDuAnRepository.GetByIdAsync(id);
        }
        public async Task CreateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn)
        {
            await _quaTrinhLamDuAnRepository.AddAsync(quaTrinhLamDuAn);
        }
        public async Task UpdateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn)
        {
            await _quaTrinhLamDuAnRepository.UpdateAsync(quaTrinhLamDuAn);
        }
        public async Task DeleteQuaTrinhLamDuAn(int id)
        {
            var quaTrinhLamDuAn = await _quaTrinhLamDuAnRepository.GetByIdAsync(id);
            await _quaTrinhLamDuAnRepository.DeleteAsync(quaTrinhLamDuAn);
        }
    }
}