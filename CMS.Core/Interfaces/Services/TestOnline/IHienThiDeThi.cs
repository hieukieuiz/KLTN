using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IHienThiDeThiService
    {
        //public IQueryable<HienThiDeThi> GetHienThiDeThi(string keywords, int? khoaHocId, int? deThiId);
        //public Task<HienThiDeThi> GetHienThiDeThiById(int id);
        public Task CreateHienThiDeThi(HienThiDeThi hienThiDeThi);
        public Task CreateDsHienThiDeThi(int[] khoaHocId, int deThiId);
        public Task UpdateHienThiDeThi(HienThiDeThi hienThiDeThi);
        public Task DeleteHienThiDeThi(int id);
    }
}