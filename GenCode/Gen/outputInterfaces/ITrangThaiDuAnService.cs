using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ITrangThaiDuAnService
    {
        public IQueryable<TrangThaiDuAn> GetTrangThaiDuAn(string keywords);
        public Task<TrangThaiDuAn> GetTrangThaiDuAnById(int id);
        public Task CreateTrangThaiDuAn(TrangThaiDuAn trangThaiDuAn);
        public Task UpdateTrangThaiDuAn(TrangThaiDuAn trangThaiDuAn);
        public Task DeleteTrangThaiDuAn(int id);
    }
}