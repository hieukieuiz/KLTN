using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IQuaTrinhHocTapService
    {
        public IQueryable<QuaTrinhHocTap> GetQuaTrinhHocTap(string keywords);
        public Task<QuaTrinhHocTap> GetQuaTrinhHocTapById(int id);
        public Task CreateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap);
        public Task UpdateQuaTrinhHocTap(QuaTrinhHocTap quaTrinhHocTap);
        public Task DeleteQuaTrinhHocTap(int id);
    }
}