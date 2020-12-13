using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IDanhGiaChungUngVienService
    {
        public IQueryable<DanhGiaChungUngVien> GetDanhGiaChungUngVien(string keywords);
        public Task<DanhGiaChungUngVien> GetDanhGiaChungUngVienById(int id);
        public Task CreateDanhGiaChungUngVien(DanhGiaChungUngVien danhGiaChungUngVien);
        public Task UpdateDanhGiaChungUngVien(DanhGiaChungUngVien danhGiaChungUngVien);
        public Task DeleteDanhGiaChungUngVien(int id);
    }
}