using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IKyNangService
    {
        public IQueryable<KyNang> GetKyNang(string keywords);
        public Task<KyNang> GetKyNangById(int id);
        public Task CreateKyNang(KyNang kyNang);
        public Task UpdateKyNang(KyNang kyNang);
        public Task DeleteKyNang(int id);
    }
}