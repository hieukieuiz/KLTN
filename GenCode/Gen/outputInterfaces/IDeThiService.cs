using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDeThiService
    {
        public IQueryable<DeThi> GetDeThi(string keywords);
        public Task<DeThi> GetDeThiById(int id);
        public Task CreateDeThi(DeThi deThi);
        public Task UpdateDeThi(DeThi deThi);
        public Task DeleteDeThi(int id);
    }
}