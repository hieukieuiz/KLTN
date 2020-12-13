using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class NhomKyNangService: INhomKyNangService
    {
        private readonly IRepository<NhomKyNang> _nhomKyNangRepository;
        public NhomKyNangService(IRepository<NhomKyNang> nhomKyNangRepository)
        {
            _nhomKyNangRepository = nhomKyNangRepository;
        }
        public IQueryable<NhomKyNang> GetNhomKyNang(string keywords)
        {
            var query = _nhomKyNangRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(nhomKyNang =>
                        nhomKyNang.TenNhomKyNang.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<NhomKyNang> GetNhomKyNangById(int id)
        {
            return await _nhomKyNangRepository.GetByIdAsync(id);
        }
        public async Task CreateNhomKyNang(NhomKyNang nhomKyNang)
        {
            await _nhomKyNangRepository.AddAsync(nhomKyNang);
        }
        public async Task UpdateNhomKyNang(NhomKyNang nhomKyNang)
        {
            await _nhomKyNangRepository.UpdateAsync(nhomKyNang);
        }
        public async Task DeleteNhomKyNang(int id)
        {
            var nhomKyNang = await _nhomKyNangRepository.GetByIdAsync(id);
            await _nhomKyNangRepository.DeleteAsync(nhomKyNang);
        }
    }
}