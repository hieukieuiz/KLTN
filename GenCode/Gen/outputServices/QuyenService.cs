using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class QuyenService: IQuyenService
    {
        private readonly IRepository<Quyen> _quyenRepository;
        public QuyenService(IRepository<Quyen> quyenRepository)
        {
            _quyenRepository = quyenRepository;
        }
        public IQueryable<Quyen> GetQuyen(string keywords)
        {
            var query = _quyenRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(quyen =>
                        quyen.TenQuyen.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<Quyen> GetQuyenById(int id)
        {
            return await _quyenRepository.GetByIdAsync(id);
        }
        public async Task CreateQuyen(Quyen quyen)
        {
            await _quyenRepository.AddAsync(quyen);
        }
        public async Task UpdateQuyen(Quyen quyen)
        {
            await _quyenRepository.UpdateAsync(quyen);
        }
        public async Task DeleteQuyen(int id)
        {
            var quyen = await _quyenRepository.GetByIdAsync(id);
            await _quyenRepository.DeleteAsync(quyen);
        }
    }
}