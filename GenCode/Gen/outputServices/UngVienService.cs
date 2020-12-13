using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class UngVienService: IUngVienService
    {
        private readonly IRepository<UngVien> _ungVienRepository;
        public UngVienService(IRepository<UngVien> ungVienRepository)
        {
            _ungVienRepository = ungVienRepository;
        }
        public IQueryable<UngVien> GetUngVien(string keywords)
        {
            var query = _ungVienRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(ungVien =>
                        ungVien.TenUngVien.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<UngVien> GetUngVienById(int id)
        {
            return await _ungVienRepository.GetByIdAsync(id);
        }
        public async Task CreateUngVien(UngVien ungVien)
        {
            await _ungVienRepository.AddAsync(ungVien);
        }
        public async Task UpdateUngVien(UngVien ungVien)
        {
            await _ungVienRepository.UpdateAsync(ungVien);
        }
        public async Task DeleteUngVien(int id)
        {
            var ungVien = await _ungVienRepository.GetByIdAsync(id);
            await _ungVienRepository.DeleteAsync(ungVien);
        }
    }
}