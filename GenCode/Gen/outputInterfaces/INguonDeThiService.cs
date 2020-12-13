using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface INguonDeThiService
    {
        public IQueryable<NguonDeThi> GetNguonDeThi(string keywords);
        public Task<NguonDeThi> GetNguonDeThiById(int id);
        public Task CreateNguonDeThi(NguonDeThi nguonDeThi);
        public Task UpdateNguonDeThi(NguonDeThi nguonDeThi);
        public Task DeleteNguonDeThi(int id);
    }
}