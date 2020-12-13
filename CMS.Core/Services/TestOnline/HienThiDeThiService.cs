using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CMS.Core.Services
{
    public class HienThiDeThiService : IHienThiDeThiService
    {
        private readonly IRepository<HienThiDeThi> _hienThiDeThiRepository;
        public HienThiDeThiService(IRepository<HienThiDeThi> hienThiDeThiRepository)
        {
            _hienThiDeThiRepository = hienThiDeThiRepository;
        }
        //public IQueryable<HienThiDeThi> GetHienThiDeThi(string keywords,int? khoaHocId, int? deThiId)
        //{
        //    var query = _hienThiDeThiRepository.TableUntracked.Where(x => x.KhoaHocId == khoaHocId).AsNoTracking();
        //    return query;
        //}

        //public async Task<HienThiDeThi> GetHienThiDeThiById(int id)
        //{
        //    return await _hienThiDeThiRepository.GetByIdAsync(id);
        //}
        public async Task CreateHienThiDeThi(HienThiDeThi hienThiDeThi)
        {
            await _hienThiDeThiRepository.AddAsync(hienThiDeThi);
        }
        public async Task UpdateHienThiDeThi(HienThiDeThi hienThiDeThi)
        {
            await _hienThiDeThiRepository.UpdateAsync(hienThiDeThi);
        }
        public async Task DeleteHienThiDeThi(int id)
        {
            var hienThiDeThi = await _hienThiDeThiRepository.GetByIdAsync(id);
            await _hienThiDeThiRepository.DeleteAsync(hienThiDeThi);
        }

        public async Task CreateDsHienThiDeThi(int[] khoaHocId, int deThiId)
        {
            for(int i = 0;i < khoaHocId.Length; i++)
            {
                HienThiDeThi hienThiDeThi = new HienThiDeThi() { DeThiId = deThiId, KhoaHocId = khoaHocId[i] };
                await _hienThiDeThiRepository.AddAsync(hienThiDeThi);
            }
        }
    }
}