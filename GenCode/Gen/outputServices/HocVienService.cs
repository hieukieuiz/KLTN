using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class HocVienService: IHocVienService
    {
        private readonly IRepository<HocVien> _hocVienRepository;
        public HocVienService(IRepository<HocVien> hocVienRepository)
        {
            _hocVienRepository = hocVienRepository;
        }
        public IQueryable<HocVien> GetHocVien(string keywords)
        {
            var query = _hocVienRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(hocVien =>
                        hocVien.TenHocVien.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<HocVien> GetHocVienById(int id)
        {
            return await _hocVienRepository.GetByIdAsync(id);
        }
        public async Task CreateHocVien(HocVien hocVien)
        {
            await _hocVienRepository.AddAsync(hocVien);
        }
        public async Task UpdateHocVien(HocVien hocVien)
        {
            await _hocVienRepository.UpdateAsync(hocVien);
        }
        public async Task DeleteHocVien(int id)
        {
            var hocVien = await _hocVienRepository.GetByIdAsync(id);
            await _hocVienRepository.DeleteAsync(hocVien);
        }
    }
}