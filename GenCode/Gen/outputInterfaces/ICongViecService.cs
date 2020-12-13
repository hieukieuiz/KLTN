using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ICongViecService
    {
        public IQueryable<CongViec> GetCongViec(string keywords);
        public Task<CongViec> GetCongViecById(int id);
        public Task CreateCongViec(CongViec congViec);
        public Task UpdateCongViec(CongViec congViec);
        public Task DeleteCongViec(int id);
    }
}