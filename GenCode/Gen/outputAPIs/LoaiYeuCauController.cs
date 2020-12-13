using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class LoaiYeuCauController: BaseApiController
    {
        private readonly ILoaiYeuCauService _loaiYeuCauService;

        public LoaiYeuCauController(ILoaiYeuCauService loaiYeuCauService)
        {
            _loaiYeuCauService = loaiYeuCauService;
        }

        [ProducesResponseType(typeof(PagedResult<LoaiYeuCauDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetLoaiYeuCau([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _loaiYeuCauService.GetLoaiYeuCau(keywords);
            var loaiYeuCau = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = loaiYeuCau.TotalCount;
            var result = new PagedResult<LoaiYeuCauDTO>(pagination, loaiYeuCau.Select(LoaiYeuCauDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(LoaiYeuCauDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiYeuCauById(int id)
        {
            var loaiYeuCau = await _loaiYeuCauService.GetLoaiYeuCauById(id);
            var result = LoaiYeuCauDTO.FromEntity(loaiYeuCau);
            return Ok(result);
        }

        [ProducesResponseType(typeof(LoaiYeuCauDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateLoaiYeuCau(LoaiYeuCauDTO loaiYeuCauDTO)
        {
            var loaiYeuCau = loaiYeuCauDTO.ToEntity();
            await _loaiYeuCauService.CreateLoaiYeuCau(loaiYeuCau);
            return Ok(loaiYeuCau);
        }

        [ProducesResponseType(typeof(LoaiYeuCauDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoaiYeuCau(int id, [FromBody]LoaiYeuCauDTO loaiYeuCauDTO)
        {
            var loaiYeuCau = loaiYeuCauDTO.ToEntity();
            await _loaiYeuCauService.UpdateLoaiYeuCau(loaiYeuCau);
            return Ok(loaiYeuCau);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiYeuCau(int id)
        {
            await _loaiYeuCauService.DeleteLoaiYeuCau(id);
            return Ok();
        }
    }
}