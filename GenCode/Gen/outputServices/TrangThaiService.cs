using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class TrangThaiService: ITrangThaiService
    {
        private readonly IRepository<TrangThai> _trangThaiRepository;
        public TrangThaiService(IRepository<TrangThai> trangThaiRepository)
        {
            _trangThaiRepository = trangThaiRepository;
        }
        public IQueryable<TrangThai> GetTrangThai(string keywords)
        {
            var query = _trangThaiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(trangThai =>
                        trangThai.TenTrangThai.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<TrangThai> GetTrangThaiById(int id)
        {
            return await _trangThaiRepository.GetByIdAsync(id);
        }
        public async Task CreateTrangThai(TrangThai trangThai)
        {
            await _trangThaiRepository.AddAsync(trangThai);
        }
        public async Task UpdateTrangThai(TrangThai trangThai)
        {
            await _trangThaiRepository.UpdateAsync(trangThai);
        }
        public async Task DeleteTrangThai(int id)
        {
            var trangThai = await _trangThaiRepository.GetByIdAsync(id);
            await _trangThaiRepository.DeleteAsync(trangThai);
        }
    }
}