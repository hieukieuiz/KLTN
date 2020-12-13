using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ITruongDaiHocService
    {
        public IQueryable<TruongDaiHoc> GetTruongDaiHoc(string keywords);
        public Task<TruongDaiHoc> GetTruongDaiHocById(int id);
        public Task CreateTruongDaiHoc(TruongDaiHoc truongDaiHoc);
        public Task UpdateTruongDaiHoc(TruongDaiHoc truongDaiHoc);
        public Task DeleteTruongDaiHoc(int id);
    }
}