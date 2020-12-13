using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ITrangThaiService
    {
        public IQueryable<TrangThai> GetTrangThai(string keywords);
        public Task<TrangThai> GetTrangThaiById(int id);
        public Task CreateTrangThai(TrangThai trangThai);
        public Task UpdateTrangThai(TrangThai trangThai);
        public Task DeleteTrangThai(int id);
    }
}