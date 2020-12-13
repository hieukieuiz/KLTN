using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface IScheduleTaskService
    {
        public IQueryable<ScheduleTask> GetScheduleTask(string keywords);
        public Task<ScheduleTask> GetScheduleTaskById(int id);
        public Task CreateScheduleTask(ScheduleTask scheduleTask);
        public Task UpdateScheduleTask(ScheduleTask scheduleTask);
        public Task DeleteScheduleTask(int id);
    }
}