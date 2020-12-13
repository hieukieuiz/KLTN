using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDoanhNghiepService
    {
        public IQueryable<DoanhNghiep> GetDoanhNghiep(string keywords);
        public Task<DoanhNghiep> GetDoanhNghiepById(int id);
        public Task CreateDoanhNghiep(DoanhNghiep doanhNghiep);
        public Task UpdateDoanhNghiep(DoanhNghiep doanhNghiep);
        public Task DeleteDoanhNghiep(int id);
    }
}