using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class CauHinhDoKhoService: ICauHinhDoKhoService
    {
        private readonly IRepository<CauHinhDoKho> _cauHinhDoKhoRepository;
        public CauHinhDoKhoService(IRepository<CauHinhDoKho> cauHinhDoKhoRepository)
        {
            _cauHinhDoKhoRepository = cauHinhDoKhoRepository;
        }
        public IQueryable<CauHinhDoKho> GetCauHinhDoKho(string keywords)
        {
            var query = _cauHinhDoKhoRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(cauHinhDoKho =>
                        cauHinhDoKho.TenCauHinhDoKho.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<CauHinhDoKho> GetCauHinhDoKhoById(int id)
        {
            return await _cauHinhDoKhoRepository.GetByIdAsync(id);
        }
        public async Task CreateCauHinhDoKho(CauHinhDoKho cauHinhDoKho)
        {
            await _cauHinhDoKhoRepository.AddAsync(cauHinhDoKho);
        }
        public async Task UpdateCauHinhDoKho(CauHinhDoKho cauHinhDoKho)
        {
            await _cauHinhDoKhoRepository.UpdateAsync(cauHinhDoKho);
        }
        public async Task DeleteCauHinhDoKho(int id)
        {
            var cauHinhDoKho = await _cauHinhDoKhoRepository.GetByIdAsync(id);
            await _cauHinhDoKhoRepository.DeleteAsync(cauHinhDoKho);
        }
    }
}