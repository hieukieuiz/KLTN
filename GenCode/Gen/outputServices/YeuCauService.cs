using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class YeuCauService: IYeuCauService
    {
        private readonly IRepository<YeuCau> _yeuCauRepository;
        public YeuCauService(IRepository<YeuCau> yeuCauRepository)
        {
            _yeuCauRepository = yeuCauRepository;
        }
        public IQueryable<YeuCau> GetYeuCau(string keywords)
        {
            var query = _yeuCauRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(yeuCau =>
                        yeuCau.TenYeuCau.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<YeuCau> GetYeuCauById(int id)
        {
            return await _yeuCauRepository.GetByIdAsync(id);
        }
        public async Task CreateYeuCau(YeuCau yeuCau)
        {
            await _yeuCauRepository.AddAsync(yeuCau);
        }
        public async Task UpdateYeuCau(YeuCau yeuCau)
        {
            await _yeuCauRepository.UpdateAsync(yeuCau);
        }
        public async Task DeleteYeuCau(int id)
        {
            var yeuCau = await _yeuCauRepository.GetByIdAsync(id);
            await _yeuCauRepository.DeleteAsync(yeuCau);
        }
    }
}