using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ILichSuChiTietCongViecService
    {
        public IQueryable<LichSuChiTietCongViec> GetLichSuChiTietCongViec(string keywords);
        public Task<LichSuChiTietCongViec> GetLichSuChiTietCongViecById(int id);
        public Task CreateLichSuChiTietCongViec(LichSuChiTietCongViec lichSuChiTietCongViec);
        public Task UpdateLichSuChiTietCongViec(LichSuChiTietCongViec lichSuChiTietCongViec);
        public Task DeleteLichSuChiTietCongViec(int id);
    }
}