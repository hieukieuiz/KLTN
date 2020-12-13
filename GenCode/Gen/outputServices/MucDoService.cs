using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class MucDoService: IMucDoService
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
                query = query
                    .Where(mucDo =>
                        mucDo.TenMucDo.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<MucDo> GetMucDoById(int id)
        {
            return await _mucDoRepository.GetByIdAsync(id);
        }
        public async Task CreateMucDo(MucDo mucDo)
        {
            await _mucDoRepository.AddAsync(mucDo);
        }
        public async Task UpdateMucDo(MucDo mucDo)
        {
            await _mucDoRepository.UpdateAsync(mucDo);
        }
        public async Task DeleteMucDo(int id)
        {
            var mucDo = await _mucDoRepository.GetByIdAsync(id);
            await _mucDoRepository.DeleteAsync(mucDo);
        }
    }
}