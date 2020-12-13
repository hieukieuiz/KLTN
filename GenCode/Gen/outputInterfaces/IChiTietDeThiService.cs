using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IChiTietDeThiService
    {
        public IQueryable<ChiTietDeThi> GetChiTietDeThi(string keywords);
        public Task<ChiTietDeThi> GetChiTietDeThiById(int id);
        public Task CreateChiTietDeThi(ChiTietDeThi chiTietDeThi);
        public Task UpdateChiTietDeThi(ChiTietDeThi chiTietDeThi);
        public Task DeleteChiTietDeThi(int id);
    }
}