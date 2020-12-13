using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IMucDoService
    {
        public IQueryable<MucDo> GetMucDo(string keywords);
        public Task<MucDo> GetMucDoById(int id);
        public Task CreateMucDo(MucDo mucDo);
        public Task UpdateMucDo(MucDo mucDo);
        public Task DeleteMucDo(int id);
    }
}