using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class ScheduleTaskHistoryService: IScheduleTaskHistoryService
    {
        private readonly IRepository<ScheduleTaskHistory> _scheduleTaskHistoryRepository;
        public ScheduleTaskHistoryService(IRepository<ScheduleTaskHistory> scheduleTaskHistoryRepository)
        {
            _scheduleTaskHistoryRepository = scheduleTaskHistoryRepository;
        }
        public IQueryable<ScheduleTaskHistory> GetScheduleTaskHistory(string keywords)
        {
            var query = _scheduleTaskHistoryRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(scheduleTaskHistory =>
                        scheduleTaskHistory.TenScheduleTaskHistory.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<ScheduleTaskHistory> GetScheduleTaskHistoryById(int id)
        {
            return await _scheduleTaskHistoryRepository.GetByIdAsync(id);
        }
        public async Task CreateScheduleTaskHistory(ScheduleTaskHistory scheduleTaskHistory)
        {
            await _scheduleTaskHistoryRepository.AddAsync(scheduleTaskHistory);
        }
        public async Task UpdateScheduleTaskHistory(ScheduleTaskHistory scheduleTaskHistory)
        {
            await _scheduleTaskHistoryRepository.UpdateAsync(scheduleTaskHistory);
        }
        public async Task DeleteScheduleTaskHistory(int id)
        {
            var scheduleTaskHistory = await _scheduleTaskHistoryRepository.GetByIdAsync(id);
            await _scheduleTaskHistoryRepository.DeleteAsync(scheduleTaskHistory);
        }
    }
}