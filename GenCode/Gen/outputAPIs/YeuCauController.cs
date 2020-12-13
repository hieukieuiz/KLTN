using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class YeuCauController: BaseApiController
    {
        private readonly IYeuCauService _yeuCauService;

        public YeuCauController(IYeuCauService yeuCauService)
        {
            _yeuCauService = yeuCauService;
        }

        [ProducesResponseType(typeof(PagedResult<YeuCauDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetYeuCau([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _yeuCauService.GetYeuCau(keywords);
            var yeuCau = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = yeuCau.TotalCount;
            var result = new PagedResult<YeuCauDTO>(pagination, yeuCau.Select(YeuCauDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(YeuCauDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYeuCauById(int id)
        {
            var yeuCau = await _yeuCauService.GetYeuCauById(id);
            var result = YeuCauDTO.FromEntity(yeuCau);
            return Ok(result);
        }

        [ProducesResponseType(typeof(YeuCauDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateYeuCau(YeuCauDTO yeuCauDTO)
        {
            var yeuCau = yeuCauDTO.ToEntity();
            await _yeuCauService.CreateYeuCau(yeuCau);
            return Ok(yeuCau);
        }

        [ProducesResponseType(typeof(YeuCauDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYeuCau(int id, [FromBody]YeuCauDTO yeuCauDTO)
        {
            var yeuCau = yeuCauDTO.ToEntity();
            await _yeuCauService.UpdateYeuCau(yeuCau);
            return Ok(yeuCau);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYeuCau(int id)
        {
            await _yeuCauService.DeleteYeuCau(id);
            return Ok();
        }
    }
}