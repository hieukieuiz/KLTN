using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class CVUngVienService: ICVUngVienService
    {
        private readonly IRepository<CVUngVien> _cvUngVienRepository;
        public CVUngVienService(IRepository<CVUngVien> cvUngVienRepository)
        {
            _cvUngVienRepository = cvUngVienRepository;
        }
        public IQueryable<CVUngVien> GetCVUngVien(string keywords)
        {
            var query = _cvUngVienRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(cvUngVien =>
                        cvUngVien.TenCVUngVien.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<CVUngVien> GetCVUngVienById(int id)
        {
            return await _cvUngVienRepository.GetByIdAsync(id);
        }
        public async Task CreateCVUngVien(CVUngVien cvUngVien)
        {
            await _cvUngVienRepository.AddAsync(cvUngVien);
        }
        public async Task UpdateCVUngVien(CVUngVien cvUngVien)
        {
            await _cvUngVienRepository.UpdateAsync(cvUngVien);
        }
        public async Task DeleteCVUngVien(int id)
        {
            var cvUngVien = await _cvUngVienRepository.GetByIdAsync(id);
            await _cvUngVienRepository.DeleteAsync(cvUngVien);
        }
    }
}