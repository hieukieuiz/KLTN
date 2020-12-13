using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IChiTietDapAnDeThiService
    {
        public IQueryable<ChiTietDapAnDeThi> GetChiTietDapAnDeThi(string keywords);
        public Task<ChiTietDapAnDeThi> GetChiTietDapAnDeThiById(int id);
        public Task CreateChiTietDapAnDeThi(ChiTietDapAnDeThi chiTietDapAnDeThi);
        public Task UpdateChiTietDapAnDeThi(ChiTietDapAnDeThi chiTietDapAnDeThi);
        public Task DeleteChiTietDapAnDeThi(int id);
    }
}