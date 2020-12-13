using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ICauHoiService
    {
        public IQueryable<CauHoi> GetCauHoi(string keywords);
        public Task<CauHoi> GetCauHoiById(int id);
        public Task CreateCauHoi(CauHoi cauHoi);
        public Task UpdateCauHoi(CauHoi cauHoi);
        public Task DeleteCauHoi(int id);
    }
}