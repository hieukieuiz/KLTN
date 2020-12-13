using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDuAnService
    {
        public IQueryable<DuAn> GetDuAn(string keywords);
        public Task<DuAn> GetDuAnById(int id);
        public Task CreateDuAn(DuAn duAn);
        public Task UpdateDuAn(DuAn duAn);
        public Task DeleteDuAn(int id);
    }
}