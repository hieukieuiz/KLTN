using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ScheduleTaskHistoryController: BaseApiController
    {
        private readonly IScheduleTaskHistoryService _scheduleTaskHistoryService;

        public ScheduleTaskHistoryController(IScheduleTaskHistoryService scheduleTaskHistoryService)
        {
            _scheduleTaskHistoryService = scheduleTaskHistoryService;
        }

        [ProducesResponseType(typeof(PagedResult<ScheduleTaskHistoryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetScheduleTaskHistory([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _scheduleTaskHistoryService.GetScheduleTaskHistory(keywords);
            var scheduleTaskHistory = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = scheduleTaskHistory.TotalCount;
            var result = new PagedResult<ScheduleTaskHistoryDTO>(pagination, scheduleTaskHistory.Select(ScheduleTaskHistoryDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ScheduleTaskHistoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleTaskHistoryById(int id)
        {
            var scheduleTaskHistory = await _scheduleTaskHistoryService.GetScheduleTaskHistoryById(id);
            var result = ScheduleTaskHistoryDTO.FromEntity(scheduleTaskHistory);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ScheduleTaskHistoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateScheduleTaskHistory(ScheduleTaskHistoryDTO scheduleTaskHistoryDTO)
        {
            var scheduleTaskHistory = scheduleTaskHistoryDTO.ToEntity();
            await _scheduleTaskHistoryService.CreateScheduleTaskHistory(scheduleTaskHistory);
            return Ok(scheduleTaskHistory);
        }

        [ProducesResponseType(typeof(ScheduleTaskHistoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScheduleTaskHistory(int id, [FromBody]ScheduleTaskHistoryDTO scheduleTaskHistoryDTO)
        {
            var scheduleTaskHistory = scheduleTaskHistoryDTO.ToEntity();
            await _scheduleTaskHistoryService.UpdateScheduleTaskHistory(scheduleTaskHistory);
            return Ok(scheduleTaskHistory);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleTaskHistory(int id)
        {
            await _scheduleTaskHistoryService.DeleteScheduleTaskHistory(id);
            return Ok();
        }
    }
}