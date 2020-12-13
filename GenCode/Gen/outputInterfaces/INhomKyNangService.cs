using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface INhomKyNangService
    {
        public IQueryable<NhomKyNang> GetNhomKyNang(string keywords);
        public Task<NhomKyNang> GetNhomKyNangById(int id);
        public Task CreateNhomKyNang(NhomKyNang nhomKyNang);
        public Task UpdateNhomKyNang(NhomKyNang nhomKyNang);
        public Task DeleteNhomKyNang(int id);
    }
}