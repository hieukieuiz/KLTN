using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IHocVienService
    {
        public IQueryable<HocVien> GetHocVien(string keywords);
        public Task<HocVien> GetHocVienById(int id);
        public Task CreateHocVien(HocVien hocVien);
        public Task UpdateHocVien(HocVien hocVien);
        public Task DeleteHocVien(int id);
    }
}