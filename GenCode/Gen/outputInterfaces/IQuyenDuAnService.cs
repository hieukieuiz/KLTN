using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IQuyenDuAnService
    {
        public IQueryable<QuyenDuAn> GetQuyenDuAn(string keywords);
        public Task<QuyenDuAn> GetQuyenDuAnById(int id);
        public Task CreateQuyenDuAn(QuyenDuAn quyenDuAn);
        public Task UpdateQuyenDuAn(QuyenDuAn quyenDuAn);
        public Task DeleteQuyenDuAn(int id);
    }
}