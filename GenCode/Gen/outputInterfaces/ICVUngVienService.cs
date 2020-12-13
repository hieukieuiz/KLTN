using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ICVUngVienService
    {
        public IQueryable<CVUngVien> GetCVUngVien(string keywords);
        public Task<CVUngVien> GetCVUngVienById(int id);
        public Task CreateCVUngVien(CVUngVien cvUngVien);
        public Task UpdateCVUngVien(CVUngVien cvUngVien);
        public Task DeleteCVUngVien(int id);
    }
}