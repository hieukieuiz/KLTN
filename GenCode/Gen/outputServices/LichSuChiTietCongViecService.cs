using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class LichSuChiTietCongViecService: ILichSuChiTietCongViecService
    {
        private readonly IRepository<LichSuChiTietCongViec> _lichSuChiTietCongViecRepository;
        public LichSuChiTietCongViecService(IRepository<LichSuChiTietCongViec> lichSuChiTietCongViecRepository)
        {
            _lichSuChiTietCongViecRepository = lichSuChiTietCongViecRepository;
        }
        public IQueryable<LichSuChiTietCongViec> GetLichSuChiTietCongViec(string keywords)
        {
            var query = _lichSuChiTietCongViecRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(lichSuChiTietCongViec =>
                        lichSuChiTietCongViec.TenLichSuChiTietCongViec.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<LichSuChiTietCongViec> GetLichSuChiTietCongViecById(int id)
        {
            return await _lichSuChiTietCongViecRepository.GetByIdAsync(id);
        }
        public async Task CreateLichSuChiTietCongViec(LichSuChiTietCongViec lichSuChiTietCongViec)
        {
            await _lichSuChiTietCongViecRepository.AddAsync(lichSuChiTietCongViec);
        }
        public async Task UpdateLichSuChiTietCongViec(LichSuChiTietCongViec lichSuChiTietCongViec)
        {
            await _lichSuChiTietCongViecRepository.UpdateAsync(lichSuChiTietCongViec);
        }
        public async Task DeleteLichSuChiTietCongViec(int id)
        {
            var lichSuChiTietCongViec = await _lichSuChiTietCongViecRepository.GetByIdAsync(id);
            await _lichSuChiTietCongViecRepository.DeleteAsync(lichSuChiTietCongViec);
        }
    }
}