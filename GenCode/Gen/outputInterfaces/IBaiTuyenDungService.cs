using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IBaiTuyenDungService
    {
        public IQueryable<BaiTuyenDung> GetBaiTuyenDung(string keywords);
        public Task<BaiTuyenDung> GetBaiTuyenDungById(int id);
        public Task CreateBaiTuyenDung(BaiTuyenDung baiTuyenDung);
        public Task UpdateBaiTuyenDung(BaiTuyenDung baiTuyenDung);
        public Task DeleteBaiTuyenDung(int id);
    }
}