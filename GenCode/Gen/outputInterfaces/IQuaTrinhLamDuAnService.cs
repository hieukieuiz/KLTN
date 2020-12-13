using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IQuaTrinhLamDuAnService
    {
        public IQueryable<QuaTrinhLamDuAn> GetQuaTrinhLamDuAn(string keywords);
        public Task<QuaTrinhLamDuAn> GetQuaTrinhLamDuAnById(int id);
        public Task CreateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn);
        public Task UpdateQuaTrinhLamDuAn(QuaTrinhLamDuAn quaTrinhLamDuAn);
        public Task DeleteQuaTrinhLamDuAn(int id);
    }
}