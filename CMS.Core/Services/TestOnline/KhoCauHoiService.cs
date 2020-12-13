using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class KhoCauHoiService : IKhoCauHoiService
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
                query = query.Where(x => x.TenKhoCauHoi.Contains(keywords));
            }
            return query;
        }

        public async Task<KhoCauHoi> GetKhoCauHoiById(int id)
        {
            return await _khoCauHoiRepository.GetByIdAsync(id);
        }
        public async Task CreateKhoCauHoi(KhoCauHoi loaiCauHoi)
        {
            await _khoCauHoiRepository.AddAsync(loaiCauHoi);
        }
        public async Task UpdateKhoCauHoi(KhoCauHoi loaiCauHoi)
        {
            await _khoCauHoiRepository.UpdateAsync(loaiCauHoi);
        }
        public async Task DeleteKhoCauHoi(int id)
        {
            var khoCauHoi = await _khoCauHoiRepository.GetByIdAsync(id);
            await _khoCauHoiRepository.DeleteAsync(khoCauHoi);
        }
    }
}