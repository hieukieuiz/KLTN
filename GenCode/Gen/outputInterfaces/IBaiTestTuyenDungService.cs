using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IBaiTestTuyenDungService
    {
        public IQueryable<BaiTestTuyenDung> GetBaiTestTuyenDung(string keywords);
        public Task<BaiTestTuyenDung> GetBaiTestTuyenDungById(int id);
        public Task CreateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung);
        public Task UpdateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung);
        public Task DeleteBaiTestTuyenDung(int id);
    }
}