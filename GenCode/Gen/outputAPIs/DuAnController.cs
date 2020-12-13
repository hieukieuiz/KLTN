using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class DuAnController: BaseApiController
    {
        private readonly IDuAnService _duAnService;

        public DuAnController(IDuAnService duAnService)
        {
            _duAnService = duAnService;
        }

        [ProducesResponseType(typeof(PagedResult<DuAnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetDuAn([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _duAnService.GetDuAn(keywords);
            var duAn = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = duAn.TotalCount;
            var result = new PagedResult<DuAnDTO>(pagination, duAn.Select(DuAnDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(DuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDuAnById(int id)
        {
            var duAn = await _duAnService.GetDuAnById(id);
            var result = DuAnDTO.FromEntity(duAn);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateDuAn(DuAnDTO duAnDTO)
        {
            var duAn = duAnDTO.ToEntity();
            await _duAnService.CreateDuAn(duAn);
            return Ok(duAn);
        }

        [ProducesResponseType(typeof(DuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDuAn(int id, [FromBody]DuAnDTO duAnDTO)
        {
            var duAn = duAnDTO.ToEntity();
            await _duAnService.UpdateDuAn(duAn);
            return Ok(duAn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuAn(int id)
        {
            await _duAnService.DeleteDuAn(id);
            return Ok();
        }
    }
}