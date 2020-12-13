using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IKyNangUngVienService
    {
        public IQueryable<KyNangUngVien> GetKyNangUngVien(string keywords);
        public Task<KyNangUngVien> GetKyNangUngVienById(int id);
        public Task CreateKyNangUngVien(KyNangUngVien kyNangUngVien);
        public Task UpdateKyNangUngVien(KyNangUngVien kyNangUngVien);
        public Task DeleteKyNangUngVien(int id);
    }
}