using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class KyNangService: IKyNangService
    {
        private readonly IRepository<KyNang> _kyNangRepository;
        public KyNangService(IRepository<KyNang> kyNangRepository)
        {
            _kyNangRepository = kyNangRepository;
        }
        public IQueryable<KyNang> GetKyNang(string keywords)
        {
            var query = _kyNangRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(kyNang =>
                        kyNang.TenKyNang.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<KyNang> GetKyNangById(int id)
        {
            return await _kyNangRepository.GetByIdAsync(id);
        }
        public async Task CreateKyNang(KyNang kyNang)
        {
            await _kyNangRepository.AddAsync(kyNang);
        }
        public async Task UpdateKyNang(KyNang kyNang)
        {
            await _kyNangRepository.UpdateAsync(kyNang);
        }
        public async Task DeleteKyNang(int id)
        {
            var kyNang = await _kyNangRepository.GetByIdAsync(id);
            await _kyNangRepository.DeleteAsync(kyNang);
        }
    }
}