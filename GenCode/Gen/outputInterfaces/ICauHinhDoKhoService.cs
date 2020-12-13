using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ICauHinhDoKhoService
    {
        public IQueryable<CauHinhDoKho> GetCauHinhDoKho(string keywords);
        public Task<CauHinhDoKho> GetCauHinhDoKhoById(int id);
        public Task CreateCauHinhDoKho(CauHinhDoKho cauHinhDoKho);
        public Task UpdateCauHinhDoKho(CauHinhDoKho cauHinhDoKho);
        public Task DeleteCauHinhDoKho(int id);
    }
}