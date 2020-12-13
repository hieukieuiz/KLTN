using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class TrangThaiDuAnService: ITrangThaiDuAnService
    {
        private readonly IRepository<TrangThaiDuAn> _trangThaiDuAnRepository;
        public TrangThaiDuAnService(IRepository<TrangThaiDuAn> trangThaiDuAnRepository)
        {
            _trangThaiDuAnRepository = trangThaiDuAnRepository;
        }
        public IQueryable<TrangThaiDuAn> GetTrangThaiDuAn(string keywords)
        {
            var query = _trangThaiDuAnRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(trangThaiDuAn =>
                        trangThaiDuAn.TenTrangThaiDuAn.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<TrangThaiDuAn> GetTrangThaiDuAnById(int id)
        {
            return await _trangThaiDuAnRepository.GetByIdAsync(id);
        }
        public async Task CreateTrangThaiDuAn(TrangThaiDuAn trangThaiDuAn)
        {
            await _trangThaiDuAnRepository.AddAsync(trangThaiDuAn);
        }
        public async Task UpdateTrangThaiDuAn(TrangThaiDuAn trangThaiDuAn)
        {
            await _trangThaiDuAnRepository.UpdateAsync(trangThaiDuAn);
        }
        public async Task DeleteTrangThaiDuAn(int id)
        {
            var trangThaiDuAn = await _trangThaiDuAnRepository.GetByIdAsync(id);
            await _trangThaiDuAnRepository.DeleteAsync(trangThaiDuAn);
        }
    }
}