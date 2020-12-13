using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class BaiTuyenDungService: IBaiTuyenDungService
    {
        private readonly IRepository<BaiTuyenDung> _baiTuyenDungRepository;
        public BaiTuyenDungService(IRepository<BaiTuyenDung> baiTuyenDungRepository)
        {
            _baiTuyenDungRepository = baiTuyenDungRepository;
        }
        public IQueryable<BaiTuyenDung> GetBaiTuyenDung(string keywords)
        {
            var query = _baiTuyenDungRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(baiTuyenDung =>
                        baiTuyenDung.TenBaiTuyenDung.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<BaiTuyenDung> GetBaiTuyenDungById(int id)
        {
            return await _baiTuyenDungRepository.GetByIdAsync(id);
        }
        public async Task CreateBaiTuyenDung(BaiTuyenDung baiTuyenDung)
        {
            await _baiTuyenDungRepository.AddAsync(baiTuyenDung);
        }
        public async Task UpdateBaiTuyenDung(BaiTuyenDung baiTuyenDung)
        {
            await _baiTuyenDungRepository.UpdateAsync(baiTuyenDung);
        }
        public async Task DeleteBaiTuyenDung(int id)
        {
            var baiTuyenDung = await _baiTuyenDungRepository.GetByIdAsync(id);
            await _baiTuyenDungRepository.DeleteAsync(baiTuyenDung);
        }
    }
}