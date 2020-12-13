using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface ICauHoiService
    {
        public IQueryable<CauHoi> GetCauHoi(string keywords,
            int? dangCauHoiId = null,
            int? khoCauHoiId = null,
            int? mucDoId = null);
        public Task<CauHoi> GetCauHoiById(int id);
        public Task<ServiceResult> CreateCauHoi(CauHoi cauHoi);
        public Task UpdateCauHoi(CauHoi cauHoi);
        public Task DeleteCauHoi(int id);
        public Task<string> GetSuggestKyHieu(int khoCauHoiId);
    }
}