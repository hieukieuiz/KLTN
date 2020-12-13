using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ThanhVienDuAnService: IThanhVienDuAnService
    {
        private readonly IRepository<ThanhVienDuAn> _thanhVienDuAnRepository;
        public ThanhVienDuAnService(IRepository<ThanhVienDuAn> thanhVienDuAnRepository)
        {
            _thanhVienDuAnRepository = thanhVienDuAnRepository;
        }
        public IQueryable<ThanhVienDuAn> GetThanhVienDuAn(string keywords)
        {
            var query = _thanhVienDuAnRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(thanhVienDuAn =>
                        thanhVienDuAn.TenThanhVienDuAn.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ThanhVienDuAn> GetThanhVienDuAnById(int id)
        {
            return await _thanhVienDuAnRepository.GetByIdAsync(id);
        }
        public async Task CreateThanhVienDuAn(ThanhVienDuAn thanhVienDuAn)
        {
            await _thanhVienDuAnRepository.AddAsync(thanhVienDuAn);
        }
        public async Task UpdateThanhVienDuAn(ThanhVienDuAn thanhVienDuAn)
        {
            await _thanhVienDuAnRepository.UpdateAsync(thanhVienDuAn);
        }
        public async Task DeleteThanhVienDuAn(int id)
        {
            var thanhVienDuAn = await _thanhVienDuAnRepository.GetByIdAsync(id);
            await _thanhVienDuAnRepository.DeleteAsync(thanhVienDuAn);
        }
    }
}