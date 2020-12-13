using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IThanhVienDuAnService
    {
        public IQueryable<ThanhVienDuAn> GetThanhVienDuAn(string keywords);
        public Task<ThanhVienDuAn> GetThanhVienDuAnById(int id);
        public Task CreateThanhVienDuAn(ThanhVienDuAn thanhVienDuAn);
        public Task UpdateThanhVienDuAn(ThanhVienDuAn thanhVienDuAn);
        public Task DeleteThanhVienDuAn(int id);
    }
}