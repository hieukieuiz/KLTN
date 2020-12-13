using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IYeuCauService
    {
        public IQueryable<YeuCau> GetYeuCau(string keywords);
        public Task<YeuCau> GetYeuCauById(int id);
        public Task CreateYeuCau(YeuCau yeuCau);
        public Task UpdateYeuCau(YeuCau yeuCau);
        public Task DeleteYeuCau(int id);
    }
}