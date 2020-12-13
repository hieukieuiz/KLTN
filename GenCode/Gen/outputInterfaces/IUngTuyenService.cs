using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IUngTuyenService
    {
        public IQueryable<UngTuyen> GetUngTuyen(string keywords);
        public Task<UngTuyen> GetUngTuyenById(int id);
        public Task CreateUngTuyen(UngTuyen ungTuyen);
        public Task UpdateUngTuyen(UngTuyen ungTuyen);
        public Task DeleteUngTuyen(int id);
    }
}