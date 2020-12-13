using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDapAnCauHoiService
    {
        public IQueryable<DapAnCauHoi> GetDapAnCauHoi(string keywords);
        public Task<DapAnCauHoi> GetDapAnCauHoiById(int id);
        public Task CreateDapAnCauHoi(DapAnCauHoi dapAnCauHoi);
        public Task UpdateDapAnCauHoi(DapAnCauHoi dapAnCauHoi);
        public Task DeleteDapAnCauHoi(int id);
    }
}