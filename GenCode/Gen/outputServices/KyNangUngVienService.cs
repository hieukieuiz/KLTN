using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class KyNangUngVienService: IKyNangUngVienService
    {
        private readonly IRepository<KyNangUngVien> _kyNangUngVienRepository;
        public KyNangUngVienService(IRepository<KyNangUngVien> kyNangUngVienRepository)
        {
            _kyNangUngVienRepository = kyNangUngVienRepository;
        }
        public IQueryable<KyNangUngVien> GetKyNangUngVien(string keywords)
        {
            var query = _kyNangUngVienRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(kyNangUngVien =>
                        kyNangUngVien.TenKyNangUngVien.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<KyNangUngVien> GetKyNangUngVienById(int id)
        {
            return await _kyNangUngVienRepository.GetByIdAsync(id);
        }
        public async Task CreateKyNangUngVien(KyNangUngVien kyNangUngVien)
        {
            await _kyNangUngVienRepository.AddAsync(kyNangUngVien);
        }
        public async Task UpdateKyNangUngVien(KyNangUngVien kyNangUngVien)
        {
            await _kyNangUngVienRepository.UpdateAsync(kyNangUngVien);
        }
        public async Task DeleteKyNangUngVien(int id)
        {
            var kyNangUngVien = await _kyNangUngVienRepository.GetByIdAsync(id);
            await _kyNangUngVienRepository.DeleteAsync(kyNangUngVien);
        }
    }
}