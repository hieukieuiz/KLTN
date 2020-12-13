using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDangCauHoiService
    {
        public IQueryable<DangCauHoi> GetDangCauHoi(string keywords);
        public Task<DangCauHoi> GetDangCauHoiById(int id);
        public Task CreateDangCauHoi(DangCauHoi dangCauHoi);
        public Task UpdateDangCauHoi(DangCauHoi dangCauHoi);
        public Task DeleteDangCauHoi(int id);
    }
}