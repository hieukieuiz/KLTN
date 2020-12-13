using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IUngVienLamBaiTestService
    {
        public IQueryable<UngVienLamBaiTest> GetUngVienLamBaiTest(string keywords);
        public Task<UngVienLamBaiTest> GetUngVienLamBaiTestById(int id);
        public Task CreateUngVienLamBaiTest(UngVienLamBaiTest ungVienLamBaiTest);
        public Task UpdateUngVienLamBaiTest(UngVienLamBaiTest ungVienLamBaiTest);
        public Task DeleteUngVienLamBaiTest(int id);
    }
}