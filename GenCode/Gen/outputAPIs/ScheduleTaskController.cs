using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ScheduleTaskController: BaseApiController
    {
        private readonly IScheduleTaskService _scheduleTaskService;

        public ScheduleTaskController(IScheduleTaskService scheduleTaskService)
        {
            _scheduleTaskService = scheduleTaskService;
        }

        [ProducesResponseType(typeof(PagedResult<ScheduleTaskDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetScheduleTask([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _scheduleTaskService.GetScheduleTask(keywords);
            var scheduleTask = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = scheduleTask.TotalCount;
            var result = new PagedResult<ScheduleTaskDTO>(pagination, scheduleTask.Select(ScheduleTaskDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ScheduleTaskDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleTaskById(int id)
        {
            var scheduleTask = await _scheduleTaskService.GetScheduleTaskById(id);
            var result = ScheduleTaskDTO.FromEntity(scheduleTask);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ScheduleTaskDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateScheduleTask(ScheduleTaskDTO scheduleTaskDTO)
        {
            var scheduleTask = scheduleTaskDTO.ToEntity();
            await _scheduleTaskService.CreateScheduleTask(scheduleTask);
            return Ok(scheduleTask);
        }

        [ProducesResponseType(typeof(ScheduleTaskDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScheduleTask(int id, [FromBody]ScheduleTaskDTO scheduleTaskDTO)
        {
            var scheduleTask = scheduleTaskDTO.ToEntity();
            await _scheduleTaskService.UpdateScheduleTask(scheduleTask);
            return Ok(scheduleTask);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleTask(int id)
        {
            await _scheduleTaskService.DeleteScheduleTask(id);
            return Ok();
        }
    }
}