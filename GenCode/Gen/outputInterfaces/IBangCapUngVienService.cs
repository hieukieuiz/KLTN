using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IBangCapUngVienService
    {
        public IQueryable<BangCapUngVien> GetBangCapUngVien(string keywords);
        public Task<BangCapUngVien> GetBangCapUngVienById(int id);
        public Task CreateBangCapUngVien(BangCapUngVien bangCapUngVien);
        public Task UpdateBangCapUngVien(BangCapUngVien bangCapUngVien);
        public Task DeleteBangCapUngVien(int id);
    }
}