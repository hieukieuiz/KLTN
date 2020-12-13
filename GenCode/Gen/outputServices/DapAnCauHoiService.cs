using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class DapAnCauHoiService: IDapAnCauHoiService
    {
        private readonly IRepository<DapAnCauHoi> _dapAnCauHoiRepository;
        public DapAnCauHoiService(IRepository<DapAnCauHoi> dapAnCauHoiRepository)
        {
            _dapAnCauHoiRepository = dapAnCauHoiRepository;
        }
        public IQueryable<DapAnCauHoi> GetDapAnCauHoi(string keywords)
        {
            var query = _dapAnCauHoiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(dapAnCauHoi =>
                        dapAnCauHoi.TenDapAnCauHoi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DapAnCauHoi> GetDapAnCauHoiById(int id)
        {
            return await _dapAnCauHoiRepository.GetByIdAsync(id);
        }
        public async Task CreateDapAnCauHoi(DapAnCauHoi dapAnCauHoi)
        {
            await _dapAnCauHoiRepository.AddAsync(dapAnCauHoi);
        }
        public async Task UpdateDapAnCauHoi(DapAnCauHoi dapAnCauHoi)
        {
            await _dapAnCauHoiRepository.UpdateAsync(dapAnCauHoi);
        }
        public async Task DeleteDapAnCauHoi(int id)
        {
            var dapAnCauHoi = await _dapAnCauHoiRepository.GetByIdAsync(id);
            await _dapAnCauHoiRepository.DeleteAsync(dapAnCauHoi);
        }
    }
}