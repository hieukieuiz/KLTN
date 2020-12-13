using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IBaiThiService
    {
        public IQueryable<BaiThi> GetBaiThi(string keywords);
        public Task<BaiThi> GetBaiThiById(int id);
        public Task CreateBaiThi(BaiThi baiThi);
        public Task UpdateBaiThi(BaiThi baiThi);
        public Task DeleteBaiThi(int id);
    }
}