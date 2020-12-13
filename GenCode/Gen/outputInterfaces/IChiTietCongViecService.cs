using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IChiTietCongViecService
    {
        public IQueryable<ChiTietCongViec> GetChiTietCongViec(string keywords);
        public Task<ChiTietCongViec> GetChiTietCongViecById(int id);
        public Task CreateChiTietCongViec(ChiTietCongViec chiTietCongViec);
        public Task UpdateChiTietCongViec(ChiTietCongViec chiTietCongViec);
        public Task DeleteChiTietCongViec(int id);
    }
}