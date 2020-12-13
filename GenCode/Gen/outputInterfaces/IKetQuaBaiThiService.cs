using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IKetQuaBaiThiService
    {
        public IQueryable<KetQuaBaiThi> GetKetQuaBaiThi(string keywords);
        public Task<KetQuaBaiThi> GetKetQuaBaiThiById(int id);
        public Task CreateKetQuaBaiThi(KetQuaBaiThi ketQuaBaiThi);
        public Task UpdateKetQuaBaiThi(KetQuaBaiThi ketQuaBaiThi);
        public Task DeleteKetQuaBaiThi(int id);
    }
}