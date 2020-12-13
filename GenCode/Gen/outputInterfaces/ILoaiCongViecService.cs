using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ILoaiCongViecService
    {
        public IQueryable<LoaiCongViec> GetLoaiCongViec(string keywords);
        public Task<LoaiCongViec> GetLoaiCongViecById(int id);
        public Task CreateLoaiCongViec(LoaiCongViec loaiCongViec);
        public Task UpdateLoaiCongViec(LoaiCongViec loaiCongViec);
        public Task DeleteLoaiCongViec(int id);
    }
}