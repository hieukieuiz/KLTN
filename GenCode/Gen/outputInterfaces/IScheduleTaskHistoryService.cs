using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IScheduleTaskHistoryService
    {
        public IQueryable<ScheduleTaskHistory> GetScheduleTaskHistory(string keywords);
        public Task<ScheduleTaskHistory> GetScheduleTaskHistoryById(int id);
        public Task CreateScheduleTaskHistory(ScheduleTaskHistory scheduleTaskHistory);
        public Task UpdateScheduleTaskHistory(ScheduleTaskHistory scheduleTaskHistory);
        public Task DeleteScheduleTaskHistory(int id);
    }
}