using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class LinhVucThiService: ILinhVucThiService
    {
        private readonly IRepository<LinhVucThi> _linhVucThiRepository;
        public LinhVucThiService(IRepository<LinhVucThi> linhVucThiRepository)
        {
            _linhVucThiRepository = linhVucThiRepository;
        }
        public IQueryable<LinhVucThi> GetLinhVucThi(string keywords)
        {
            var query = _linhVucThiRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(x =>
                        x.TenLinhVucThi.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<LinhVucThi> GetLinhVucThiById(int id)
        {
            return await _linhVucThiRepository.GetByIdAsync(id);
        }
        public async Task CreateLinhVucThi(LinhVucThi loaiKhaoSat)
        {
            await _linhVucThiRepository.AddAsync(loaiKhaoSat);
        }
        public async Task UpdateLinhVucThi(LinhVucThi loaiKhaoSat)
        {
            await _linhVucThiRepository.UpdateAsync(loaiKhaoSat);
        }
        public async Task DeleteLinhVucThi(int id)
        {
            var linhVucThi = await _linhVucThiRepository.GetByIdAsync(id);
            await _linhVucThiRepository.DeleteAsync(linhVucThi);
        }
    }
}