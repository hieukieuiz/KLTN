using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class TruongDaiHocService: ITruongDaiHocService
    {
        private readonly IRepository<TruongDaiHoc> _truongDaiHocRepository;
        public TruongDaiHocService(IRepository<TruongDaiHoc> truongDaiHocRepository)
        {
            _truongDaiHocRepository = truongDaiHocRepository;
        }
        public IQueryable<TruongDaiHoc> GetTruongDaiHoc(string keywords)
        {
            var query = _truongDaiHocRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(truongDaiHoc =>
                        truongDaiHoc.TenTruongDaiHoc.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<TruongDaiHoc> GetTruongDaiHocById(int id)
        {
            return await _truongDaiHocRepository.GetByIdAsync(id);
        }
        public async Task CreateTruongDaiHoc(TruongDaiHoc truongDaiHoc)
        {
            await _truongDaiHocRepository.AddAsync(truongDaiHoc);
        }
        public async Task UpdateTruongDaiHoc(TruongDaiHoc truongDaiHoc)
        {
            await _truongDaiHocRepository.UpdateAsync(truongDaiHoc);
        }
        public async Task DeleteTruongDaiHoc(int id)
        {
            var truongDaiHoc = await _truongDaiHocRepository.GetByIdAsync(id);
            await _truongDaiHocRepository.DeleteAsync(truongDaiHoc);
        }
    }
}