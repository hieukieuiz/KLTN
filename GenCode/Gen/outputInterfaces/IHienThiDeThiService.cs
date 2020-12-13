using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IHienThiDeThiService
    {
        public IQueryable<HienThiDeThi> GetHienThiDeThi(string keywords);
        public Task<HienThiDeThi> GetHienThiDeThiById(int id);
        public Task CreateHienThiDeThi(HienThiDeThi hienThiDeThi);
        public Task UpdateHienThiDeThi(HienThiDeThi hienThiDeThi);
        public Task DeleteHienThiDeThi(int id);
    }
}