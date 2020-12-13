using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class CauHoiService: ICauHoiService
    {
        private readonly IRepository<CauHoi> _cauHoiRepository;
        public CauHoiService(IRepository<CauHoi> cauHoiRepository)
        {
            _cauHoiRepository = cauHoiRepository;
        }
        public IQueryable<CauHoi> GetCauHoi(string keywords)
        {
            var query = _cauHoiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(cauHoi =>
                        cauHoi.TenCauHoi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<CauHoi> GetCauHoiById(int id)
        {
            return await _cauHoiRepository.GetByIdAsync(id);
        }
        public async Task CreateCauHoi(CauHoi cauHoi)
        {
            await _cauHoiRepository.AddAsync(cauHoi);
        }
        public async Task UpdateCauHoi(CauHoi cauHoi)
        {
            await _cauHoiRepository.UpdateAsync(cauHoi);
        }
        public async Task DeleteCauHoi(int id)
        {
            var cauHoi = await _cauHoiRepository.GetByIdAsync(id);
            await _cauHoiRepository.DeleteAsync(cauHoi);
        }
    }
}