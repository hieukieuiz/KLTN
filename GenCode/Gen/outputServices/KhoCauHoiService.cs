using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class KhoCauHoiService: IKhoCauHoiService
    {
        private readonly IRepository<KhoCauHoi> _khoCauHoiRepository;
        public KhoCauHoiService(IRepository<KhoCauHoi> khoCauHoiRepository)
        {
            _khoCauHoiRepository = khoCauHoiRepository;
        }
        public IQueryable<KhoCauHoi> GetKhoCauHoi(string keywords)
        {
            var query = _khoCauHoiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(khoCauHoi =>
                        khoCauHoi.TenKhoCauHoi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<KhoCauHoi> GetKhoCauHoiById(int id)
        {
            return await _khoCauHoiRepository.GetByIdAsync(id);
        }
        public async Task CreateKhoCauHoi(KhoCauHoi khoCauHoi)
        {
            await _khoCauHoiRepository.AddAsync(khoCauHoi);
        }
        public async Task UpdateKhoCauHoi(KhoCauHoi khoCauHoi)
        {
            await _khoCauHoiRepository.UpdateAsync(khoCauHoi);
        }
        public async Task DeleteKhoCauHoi(int id)
        {
            var khoCauHoi = await _khoCauHoiRepository.GetByIdAsync(id);
            await _khoCauHoiRepository.DeleteAsync(khoCauHoi);
        }
    }
}