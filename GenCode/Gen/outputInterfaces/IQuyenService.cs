using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IQuyenService
    {
        public IQueryable<Quyen> GetQuyen(string keywords);
        public Task<Quyen> GetQuyenById(int id);
        public Task CreateQuyen(Quyen quyen);
        public Task UpdateQuyen(Quyen quyen);
        public Task DeleteQuyen(int id);
    }
}