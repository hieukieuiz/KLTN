using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class QuyenDuAnService: IQuyenDuAnService
    {
        private readonly IRepository<QuyenDuAn> _quyenDuAnRepository;
        public QuyenDuAnService(IRepository<QuyenDuAn> quyenDuAnRepository)
        {
            _quyenDuAnRepository = quyenDuAnRepository;
        }
        public IQueryable<QuyenDuAn> GetQuyenDuAn(string keywords)
        {
            var query = _quyenDuAnRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(quyenDuAn =>
                        quyenDuAn.TenQuyenDuAn.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<QuyenDuAn> GetQuyenDuAnById(int id)
        {
            return await _quyenDuAnRepository.GetByIdAsync(id);
        }
        public async Task CreateQuyenDuAn(QuyenDuAn quyenDuAn)
        {
            await _quyenDuAnRepository.AddAsync(quyenDuAn);
        }
        public async Task UpdateQuyenDuAn(QuyenDuAn quyenDuAn)
        {
            await _quyenDuAnRepository.UpdateAsync(quyenDuAn);
        }
        public async Task DeleteQuyenDuAn(int id)
        {
            var quyenDuAn = await _quyenDuAnRepository.GetByIdAsync(id);
            await _quyenDuAnRepository.DeleteAsync(quyenDuAn);
        }
    }
}