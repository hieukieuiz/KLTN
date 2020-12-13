using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class TrangThaiController: BaseApiController
    {
        private readonly ITrangThaiService _trangThaiService;

        public TrangThaiController(ITrangThaiService trangThaiService)
        {
            _trangThaiService = trangThaiService;
        }

        [ProducesResponseType(typeof(PagedResult<TrangThaiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetTrangThai([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _trangThaiService.GetTrangThai(keywords);
            var trangThai = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = trangThai.TotalCount;
            var result = new PagedResult<TrangThaiDTO>(pagination, trangThai.Select(TrangThaiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(TrangThaiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrangThaiById(int id)
        {
            var trangThai = await _trangThaiService.GetTrangThaiById(id);
            var result = TrangThaiDTO.FromEntity(trangThai);
            return Ok(result);
        }

        [ProducesResponseType(typeof(TrangThaiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateTrangThai(TrangThaiDTO trangThaiDTO)
        {
            var trangThai = trangThaiDTO.ToEntity();
            await _trangThaiService.CreateTrangThai(trangThai);
            return Ok(trangThai);
        }

        [ProducesResponseType(typeof(TrangThaiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrangThai(int id, [FromBody]TrangThaiDTO trangThaiDTO)
        {
            var trangThai = trangThaiDTO.ToEntity();
            await _trangThaiService.UpdateTrangThai(trangThai);
            return Ok(trangThai);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangThai(int id)
        {
            await _trangThaiService.DeleteTrangThai(id);
            return Ok();
        }
    }
}