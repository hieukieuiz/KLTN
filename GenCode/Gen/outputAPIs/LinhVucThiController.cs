using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class LinhVucThiController: BaseApiController
    {
        private readonly ILinhVucThiService _linhVucThiService;

        public LinhVucThiController(ILinhVucThiService linhVucThiService)
        {
            _linhVucThiService = linhVucThiService;
        }

        [ProducesResponseType(typeof(PagedResult<LinhVucThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetLinhVucThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _linhVucThiService.GetLinhVucThi(keywords);
            var linhVucThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = linhVucThi.TotalCount;
            var result = new PagedResult<LinhVucThiDTO>(pagination, linhVucThi.Select(LinhVucThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(LinhVucThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLinhVucThiById(int id)
        {
            var linhVucThi = await _linhVucThiService.GetLinhVucThiById(id);
            var result = LinhVucThiDTO.FromEntity(linhVucThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(LinhVucThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateLinhVucThi(LinhVucThiDTO linhVucThiDTO)
        {
            var linhVucThi = linhVucThiDTO.ToEntity();
            await _linhVucThiService.CreateLinhVucThi(linhVucThi);
            return Ok(linhVucThi);
        }

        [ProducesResponseType(typeof(LinhVucThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLinhVucThi(int id, [FromBody]LinhVucThiDTO linhVucThiDTO)
        {
            var linhVucThi = linhVucThiDTO.ToEntity();
            await _linhVucThiService.UpdateLinhVucThi(linhVucThi);
            return Ok(linhVucThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinhVucThi(int id)
        {
            await _linhVucThiService.DeleteLinhVucThi(id);
            return Ok();
        }
    }
}