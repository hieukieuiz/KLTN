using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class BaiTestTuyenDungService: IBaiTestTuyenDungService
    {
        private readonly IRepository<BaiTestTuyenDung> _baiTestTuyenDungRepository;
        public BaiTestTuyenDungService(IRepository<BaiTestTuyenDung> baiTestTuyenDungRepository)
        {
            _baiTestTuyenDungRepository = baiTestTuyenDungRepository;
        }
        public IQueryable<BaiTestTuyenDung> GetBaiTestTuyenDung(string keywords)
        {
            var query = _baiTestTuyenDungRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(baiTestTuyenDung =>
                        baiTestTuyenDung.TenBaiTestTuyenDung.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<BaiTestTuyenDung> GetBaiTestTuyenDungById(int id)
        {
            return await _baiTestTuyenDungRepository.GetByIdAsync(id);
        }
        public async Task CreateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung)
        {
            await _baiTestTuyenDungRepository.AddAsync(baiTestTuyenDung);
        }
        public async Task UpdateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung)
        {
            await _baiTestTuyenDungRepository.UpdateAsync(baiTestTuyenDung);
        }
        public async Task DeleteBaiTestTuyenDung(int id)
        {
            var baiTestTuyenDung = await _baiTestTuyenDungRepository.GetByIdAsync(id);
            await _baiTestTuyenDungRepository.DeleteAsync(baiTestTuyenDung);
        }
    }
}