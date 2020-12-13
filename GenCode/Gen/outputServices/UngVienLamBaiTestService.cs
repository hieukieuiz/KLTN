using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class UngVienLamBaiTestService: IUngVienLamBaiTestService
    {
        private readonly IRepository<UngVienLamBaiTest> _ungVienLamBaiTestRepository;
        public UngVienLamBaiTestService(IRepository<UngVienLamBaiTest> ungVienLamBaiTestRepository)
        {
            _ungVienLamBaiTestRepository = ungVienLamBaiTestRepository;
        }
        public IQueryable<UngVienLamBaiTest> GetUngVienLamBaiTest(string keywords)
        {
            var query = _ungVienLamBaiTestRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(ungVienLamBaiTest =>
                        ungVienLamBaiTest.TenUngVienLamBaiTest.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<UngVienLamBaiTest> GetUngVienLamBaiTestById(int id)
        {
            return await _ungVienLamBaiTestRepository.GetByIdAsync(id);
        }
        public async Task CreateUngVienLamBaiTest(UngVienLamBaiTest ungVienLamBaiTest)
        {
            await _ungVienLamBaiTestRepository.AddAsync(ungVienLamBaiTest);
        }
        public async Task UpdateUngVienLamBaiTest(UngVienLamBaiTest ungVienLamBaiTest)
        {
            await _ungVienLamBaiTestRepository.UpdateAsync(ungVienLamBaiTest);
        }
        public async Task DeleteUngVienLamBaiTest(int id)
        {
            var ungVienLamBaiTest = await _ungVienLamBaiTestRepository.GetByIdAsync(id);
            await _ungVienLamBaiTestRepository.DeleteAsync(ungVienLamBaiTest);
        }
    }
}