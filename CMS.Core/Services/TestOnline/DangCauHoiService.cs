using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class DangCauHoiService: IDangCauHoiService
    {
        private readonly IRepository<DangCauHoi> _dangCauHoiRepository;
        public DangCauHoiService(IRepository<DangCauHoi> dangCauHoiRepository)
        {
            _dangCauHoiRepository = dangCauHoiRepository;
        }
        public IQueryable<DangCauHoi> GetDangCauHoi(string keywords)
        {
            var query = _dangCauHoiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(dangCauHoi =>
                        dangCauHoi.TenDangCauHoi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DangCauHoi> GetDangCauHoiById(int id)
        {
            return await _dangCauHoiRepository.GetByIdAsync(id);
        }
        public async Task CreateDangCauHoi(DangCauHoi dangCauHoi)
        {
            await _dangCauHoiRepository.AddAsync(dangCauHoi);
        }
        public async Task UpdateDangCauHoi(DangCauHoi dangCauHoi)
        {
            await _dangCauHoiRepository.UpdateAsync(dangCauHoi);
        }
        public async Task DeleteDangCauHoi(int id)
        {
            var dangCauHoi = await _dangCauHoiRepository.GetByIdAsync(id);
            await _dangCauHoiRepository.DeleteAsync(dangCauHoi);
        }
    }
}