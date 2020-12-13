using CMS.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ScheduleTaskHistoryDTO
    {
        public int Id { get; set; }
        public int ScheduleTaskId { get; set; }
        public bool IsRunning { get; set; }
        public string MachineName { get; set; }
        public DateTime StartedOnUtc { get; set; }
        public DateTime? FinishedOnUtc { get; set; }
        public DateTime? SucceededOnUtc { get; set; }
        public string Error { get; set; }
        public int? ProgressPercent { get; set; }
        public string ProgressMessage { get; set; }
        public ScheduleTaskDTO ScheduleTask { get; set; }
        public static ScheduleTaskHistoryDTO FromEntity(ScheduleTaskHistory item)
        {
            return new ScheduleTaskHistoryDTO()
            {
                Id = item.Id,
                ScheduleTaskId = item.ScheduleTaskId,
                IsRunning = item.IsRunning,
                MachineName = item.MachineName,
                StartedOnUtc = item.StartedOnUtc,
                FinishedOnUtc = item.FinishedOnUtc,
                SucceededOnUtc = item.SucceededOnUtc,
                Error = item.Error,
                ProgressPercent = item.ProgressPercent,
                ProgressMessage = item.ProgressMessage,
                ScheduleTask = item.ScheduleTask != null? ScheduleTaskDTO.FromEntity(item.ScheduleTask) : null,
            };
        }
        public ScheduleTaskHistory ToEntity()
        {
            return new ScheduleTaskHistory()
            {
                Id = this.Id,
                ScheduleTaskId = this.ScheduleTaskId,
                IsRunning = this.IsRunning,
                MachineName = this.MachineName,
                StartedOnUtc = this.StartedOnUtc,
                FinishedOnUtc = this.FinishedOnUtc,
                SucceededOnUtc = this.SucceededOnUtc,
                Error = this.Error,
                ProgressPercent = this.ProgressPercent,
                ProgressMessage = this.ProgressMessage,
                ScheduleTask = this.ScheduleTask?.ToEntity(),
            };
        }
    }
}