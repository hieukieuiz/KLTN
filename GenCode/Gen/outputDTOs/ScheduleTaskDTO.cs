using CMS.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class ScheduleTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string CronExpression { get; set; }
        public string Type { get; set; }
        public bool Enabled { get; set; }
        public bool StopOnError { get; set; }
        public DateTime? NextRunUtc { get; set; }
        public bool IsHidden { get; set; }
        public bool RunPerMachine { get; set; }
        public bool IsPending { get; set; }
        public ScheduleTaskHistoryDTO LastHistoryEntry { get; set; }
        public ICollection<ScheduleTaskHistoryDTO> ScheduleTaskHistory { get; set; }
        public static ScheduleTaskDTO FromEntity(ScheduleTask item)
        {
            return new ScheduleTaskDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Alias = item.Alias,
                CronExpression = item.CronExpression,
                Type = item.Type,
                Enabled = item.Enabled,
                StopOnError = item.StopOnError,
                NextRunUtc = item.NextRunUtc,
                IsHidden = item.IsHidden,
                RunPerMachine = item.RunPerMachine,
                
                LastHistoryEntry = item.LastHistoryEntry != null? ScheduleTaskHistoryDTO.FromEntity(item.LastHistoryEntry) : null,
                
            };
        }
        public ScheduleTask ToEntity()
        {
            return new ScheduleTask()
            {
                Id = this.Id,
                Name = this.Name,
                Alias = this.Alias,
                CronExpression = this.CronExpression,
                Type = this.Type,
                Enabled = this.Enabled,
                StopOnError = this.StopOnError,
                NextRunUtc = this.NextRunUtc,
                IsHidden = this.IsHidden,
                RunPerMachine = this.RunPerMachine,
                
                LastHistoryEntry = this.LastHistoryEntry?.ToEntity(),
                
            };
        }
    }
}