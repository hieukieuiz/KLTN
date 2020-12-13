using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class LoaiCongViecService: ILoaiCongViecService
    {
        private readonly IRepository<LoaiCongViec> _loaiCongViecRepository;
        public LoaiCongViecService(IRepository<LoaiCongViec> loaiCongViecRepository)
        {
            _loaiCongViecRepository = loaiCongViecRepository;
        }
        public IQueryable<LoaiCongViec> GetLoaiCongViec(string keywords)
        {
            var query = _loaiCongViecRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(loaiCongViec =>
                        loaiCongViec.TenLoaiCongViec.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<LoaiCongViec> GetLoaiCongViecById(int id)
        {
            return await _loaiCongViecRepository.GetByIdAsync(id);
        }
        public async Task CreateLoaiCongViec(LoaiCongViec loaiCongViec)
        {
            await _loaiCongViecRepository.AddAsync(loaiCongViec);
        }
        public async Task UpdateLoaiCongViec(LoaiCongViec loaiCongViec)
        {
            await _loaiCongViecRepository.UpdateAsync(loaiCongViec);
        }
        public async Task DeleteLoaiCongViec(int id)
        {
            var loaiCongViec = await _loaiCongViecRepository.GetByIdAsync(id);
            await _loaiCongViecRepository.DeleteAsync(loaiCongViec);
        }
    }
}