using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IUngVienService
    {
        public IQueryable<UngVien> GetUngVien(string keywords);
        public Task<UngVien> GetUngVienById(int id);
        public Task CreateUngVien(UngVien ungVien);
        public Task UpdateUngVien(UngVien ungVien);
        public Task DeleteUngVien(int id);
    }
}