using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IChiTietBaiThiService
    {
        public IQueryable<ChiTietBaiThi> GetChiTietBaiThi(string keywords);
        public Task<ChiTietBaiThi> GetChiTietBaiThiById(int id);
        public Task CreateChiTietBaiThi(ChiTietBaiThi chiTietBaiThi);
        public Task UpdateChiTietBaiThi(ChiTietBaiThi chiTietBaiThi);
        public Task DeleteChiTietBaiThi(int id);
    }
}