using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class DeThiController: BaseApiController
    {
        private readonly IDeThiService _deThiService;

        public DeThiController(IDeThiService deThiService)
        {
            _deThiService = deThiService;
        }

        [ProducesResponseType(typeof(PagedResult<DeThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetDeThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _deThiService.GetDeThi(keywords);
            var deThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = deThi.TotalCount;
            var result = new PagedResult<DeThiDTO>(pagination, deThi.Select(DeThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(DeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeThiById(int id)
        {
            var deThi = await _deThiService.GetDeThiById(id);
            var result = DeThiDTO.FromEntity(deThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateDeThi(DeThiDTO deThiDTO)
        {
            var deThi = deThiDTO.ToEntity();
            await _deThiService.CreateDeThi(deThi);
            return Ok(deThi);
        }

        [ProducesResponseType(typeof(DeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeThi(int id, [FromBody]DeThiDTO deThiDTO)
        {
            var deThi = deThiDTO.ToEntity();
            await _deThiService.UpdateDeThi(deThi);
            return Ok(deThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeThi(int id)
        {
            await _deThiService.DeleteDeThi(id);
            return Ok();
        }
    }
}