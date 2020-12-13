using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ILinhVucThiService
    {
        public IQueryable<LinhVucThi> GetLinhVucThi(string keywords);
        public Task<LinhVucThi> GetLinhVucThiById(int id);
        public Task CreateLinhVucThi(LinhVucThi loaiKhaoSat);
        public Task UpdateLinhVucThi(LinhVucThi loaiKhaoSat);
        public Task DeleteLinhVucThi(int id);
    }
}