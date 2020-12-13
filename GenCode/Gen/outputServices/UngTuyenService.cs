using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class UngTuyenService: IUngTuyenService
    {
        private readonly IRepository<UngTuyen> _ungTuyenRepository;
        public UngTuyenService(IRepository<UngTuyen> ungTuyenRepository)
        {
            _ungTuyenRepository = ungTuyenRepository;
        }
        public IQueryable<UngTuyen> GetUngTuyen(string keywords)
        {
            var query = _ungTuyenRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(ungTuyen =>
                        ungTuyen.TenUngTuyen.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<UngTuyen> GetUngTuyenById(int id)
        {
            return await _ungTuyenRepository.GetByIdAsync(id);
        }
        public async Task CreateUngTuyen(UngTuyen ungTuyen)
        {
            await _ungTuyenRepository.AddAsync(ungTuyen);
        }
        public async Task UpdateUngTuyen(UngTuyen ungTuyen)
        {
            await _ungTuyenRepository.UpdateAsync(ungTuyen);
        }
        public async Task DeleteUngTuyen(int id)
        {
            var ungTuyen = await _ungTuyenRepository.GetByIdAsync(id);
            await _ungTuyenRepository.DeleteAsync(ungTuyen);
        }
    }
}