using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class MucDoService : IMucDoService
    {
        private readonly IRepository<MucDo> _mucDoRepository;
        public MucDoService(IRepository<MucDo> mucDoRepository)
        {
            _mucDoRepository = mucDoRepository;
        }
        public IQueryable<MucDo> GetMucDo(string keywords)
        {
            var query = _mucDoRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query.Where(x => x.TenMucDo.Contains(keywords));
            }
            return query;
        }

        public async Task<MucDo> GetMucDoById(int id)
        {
            return await _mucDoRepository.GetByIdAsync(id);
        }
        public async Task CreateMucDo(MucDo loaiMucDo)
        {
            await _mucDoRepository.AddAsync(loaiMucDo);
        }
        public async Task UpdateMucDo(MucDo loaiMucDo)
        {
            await _mucDoRepository.UpdateAsync(loaiMucDo);
        }
        public async Task DeleteMucDo(int id)
        {
            var khoMucDo = await _mucDoRepository.GetByIdAsync(id);
            await _mucDoRepository.DeleteAsync(khoMucDo);
        }
    }
}