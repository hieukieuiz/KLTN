using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CMS.Core.Services
{
    public class ChiTietDeThiService : IChiTietDeThiService
    {
        private readonly IRepository<ChiTietDeThi> _chiTietDeThiRepository;
        public ChiTietDeThiService(IRepository<ChiTietDeThi> chiTietDeThiRepository)
        {
            _chiTietDeThiRepository = chiTietDeThiRepository;
        }
        public IQueryable<ChiTietDeThi> GetChiTietDeThi(int deThiId)
        {
            var query = _chiTietDeThiRepository.TableUntracked
                .Include(x => x.CauHoi)
                .ThenInclude(x => x.DangCauHoi)
                .Include(x => x.CauHoi)
                .ThenInclude(x => x.KhoCauHoi)
                .Include(x => x.CauHoi)
                .ThenInclude(x => x.MucDo)
                .Where(x => x.DeThiId == deThiId).AsNoTracking();

            return query;
        }

        public async Task<ChiTietDeThi> GetChiTietDeThiById(int id)
        {
            return await _chiTietDeThiRepository.GetByIdAsync(id);
        }
        public async Task CreateChiTietDeThi(ChiTietDeThi cauHoiKhaoSat)
        {
            await _chiTietDeThiRepository.AddAsync(cauHoiKhaoSat);
        }
        public async Task UpdateChiTietDeThi(ChiTietDeThi cauHoiKhaoSat)
        {
            await _chiTietDeThiRepository.UpdateAsync(cauHoiKhaoSat);
        }
        public async Task DeleteChiTietDeThi(int id)
        {
            var cauHoiKhaoSat = await _chiTietDeThiRepository.GetByIdAsync(id);
            await _chiTietDeThiRepository.DeleteAsync(cauHoiKhaoSat);
        }
    }
}