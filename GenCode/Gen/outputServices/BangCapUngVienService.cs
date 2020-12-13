using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class BangCapUngVienService: IBangCapUngVienService
    {
        private readonly IRepository<BangCapUngVien> _bangCapUngVienRepository;
        public BangCapUngVienService(IRepository<BangCapUngVien> bangCapUngVienRepository)
        {
            _bangCapUngVienRepository = bangCapUngVienRepository;
        }
        public IQueryable<BangCapUngVien> GetBangCapUngVien(string keywords)
        {
            var query = _bangCapUngVienRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(bangCapUngVien =>
                        bangCapUngVien.TenBangCapUngVien.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<BangCapUngVien> GetBangCapUngVienById(int id)
        {
            return await _bangCapUngVienRepository.GetByIdAsync(id);
        }
        public async Task CreateBangCapUngVien(BangCapUngVien bangCapUngVien)
        {
            await _bangCapUngVienRepository.AddAsync(bangCapUngVien);
        }
        public async Task UpdateBangCapUngVien(BangCapUngVien bangCapUngVien)
        {
            await _bangCapUngVienRepository.UpdateAsync(bangCapUngVien);
        }
        public async Task DeleteBangCapUngVien(int id)
        {
            var bangCapUngVien = await _bangCapUngVienRepository.GetByIdAsync(id);
            await _bangCapUngVienRepository.DeleteAsync(bangCapUngVien);
        }
    }
}