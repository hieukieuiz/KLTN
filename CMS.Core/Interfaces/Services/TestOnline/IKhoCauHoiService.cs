using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IKhoCauHoiService
    {
        public IQueryable<KhoCauHoi> GetKhoCauHoi(string keywords);
        public Task<KhoCauHoi> GetKhoCauHoiById(int id);
        public Task CreateKhoCauHoi(KhoCauHoi khoCauHoi);
        public Task UpdateKhoCauHoi(KhoCauHoi khoCauHoi);
        public Task DeleteKhoCauHoi(int id);
    }
}