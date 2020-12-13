using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IPhanViecService
    {
        public IQueryable<PhanViec> GetPhanViec(string keywords);
        public Task<PhanViec> GetPhanViecById(int id);
        public Task CreatePhanViec(PhanViec phanViec);
        public Task UpdatePhanViec(PhanViec phanViec);
        public Task DeletePhanViec(int id);
    }
}