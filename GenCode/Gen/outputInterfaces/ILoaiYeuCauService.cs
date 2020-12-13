using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ILoaiYeuCauService
    {
        public IQueryable<LoaiYeuCau> GetLoaiYeuCau(string keywords);
        public Task<LoaiYeuCau> GetLoaiYeuCauById(int id);
        public Task CreateLoaiYeuCau(LoaiYeuCau loaiYeuCau);
        public Task UpdateLoaiYeuCau(LoaiYeuCau loaiYeuCau);
        public Task DeleteLoaiYeuCau(int id);
    }
}