using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ScheduleTaskService: IScheduleTaskService
    {
        private readonly IRepository<ScheduleTask> _scheduleTaskRepository;
        public ScheduleTaskService(IRepository<ScheduleTask> scheduleTaskRepository)
        {
            _scheduleTaskRepository = scheduleTaskRepository;
        }
        public IQueryable<ScheduleTask> GetScheduleTask(string keywords)
        {
            var query = _scheduleTaskRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(scheduleTask =>
                        scheduleTask.TenScheduleTask.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ScheduleTask> GetScheduleTaskById(int id)
        {
            return await _scheduleTaskRepository.GetByIdAsync(id);
        }
        public async Task CreateScheduleTask(ScheduleTask scheduleTask)
        {
            await _scheduleTaskRepository.AddAsync(scheduleTask);
        }
        public async Task UpdateScheduleTask(ScheduleTask scheduleTask)
        {
            await _scheduleTaskRepository.UpdateAsync(scheduleTask);
        }
        public async Task DeleteScheduleTask(int id)
        {
            var scheduleTask = await _scheduleTaskRepository.GetByIdAsync(id);
            await _scheduleTaskRepository.DeleteAsync(scheduleTask);
        }
    }
}