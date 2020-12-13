using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class DanhGiaChungUngVienService: IDanhGiaChungUngVienService
    {
        private readonly IRepository<DanhGiaChungUngVien> _danhGiaChungUngVienRepository;
        public DanhGiaChungUngVienService(IRepository<DanhGiaChungUngVien> danhGiaChungUngVienRepository)
        {
            _danhGiaChungUngVienRepository = danhGiaChungUngVienRepository;
        }
        public IQueryable<DanhGiaChungUngVien> GetDanhGiaChungUngVien(string keywords)
        {
            var query = _danhGiaChungUngVienRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(danhGiaChungUngVien =>
                        danhGiaChungUngVien.TenDanhGiaChungUngVien.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DanhGiaChungUngVien> GetDanhGiaChungUngVienById(int id)
        {
            return await _danhGiaChungUngVienRepository.GetByIdAsync(id);
        }
        public async Task CreateDanhGiaChungUngVien(DanhGiaChungUngVien danhGiaChungUngVien)
        {
            await _danhGiaChungUngVienRepository.AddAsync(danhGiaChungUngVien);
        }
        public async Task UpdateDanhGiaChungUngVien(DanhGiaChungUngVien danhGiaChungUngVien)
        {
            await _danhGiaChungUngVienRepository.UpdateAsync(danhGiaChungUngVien);
        }
        public async Task DeleteDanhGiaChungUngVien(int id)
        {
            var danhGiaChungUngVien = await _danhGiaChungUngVienRepository.GetByIdAsync(id);
            await _danhGiaChungUngVienRepository.DeleteAsync(danhGiaChungUngVien);
        }
    }
}