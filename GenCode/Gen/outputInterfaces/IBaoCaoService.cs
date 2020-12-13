using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IBaoCaoService
    {
        public IQueryable<BaoCao> GetBaoCao(string keywords);
        public Task<BaoCao> GetBaoCaoById(int id);
        public Task CreateBaoCao(BaoCao baoCao);
        public Task UpdateBaoCao(BaoCao baoCao);
        public Task DeleteBaoCao(int id);
    }
}