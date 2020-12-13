using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class TrangThaiDuAnController: BaseApiController
    {
        private readonly ITrangThaiDuAnService _trangThaiDuAnService;

        public TrangThaiDuAnController(ITrangThaiDuAnService trangThaiDuAnService)
        {
            _trangThaiDuAnService = trangThaiDuAnService;
        }

        [ProducesResponseType(typeof(PagedResult<TrangThaiDuAnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetTrangThaiDuAn([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _trangThaiDuAnService.GetTrangThaiDuAn(keywords);
            var trangThaiDuAn = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = trangThaiDuAn.TotalCount;
            var result = new PagedResult<TrangThaiDuAnDTO>(pagination, trangThaiDuAn.Select(TrangThaiDuAnDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(TrangThaiDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrangThaiDuAnById(int id)
        {
            var trangThaiDuAn = await _trangThaiDuAnService.GetTrangThaiDuAnById(id);
            var result = TrangThaiDuAnDTO.FromEntity(trangThaiDuAn);
            return Ok(result);
        }

        [ProducesResponseType(typeof(TrangThaiDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateTrangThaiDuAn(TrangThaiDuAnDTO trangThaiDuAnDTO)
        {
            var trangThaiDuAn = trangThaiDuAnDTO.ToEntity();
            await _trangThaiDuAnService.CreateTrangThaiDuAn(trangThaiDuAn);
            return Ok(trangThaiDuAn);
        }

        [ProducesResponseType(typeof(TrangThaiDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrangThaiDuAn(int id, [FromBody]TrangThaiDuAnDTO trangThaiDuAnDTO)
        {
            var trangThaiDuAn = trangThaiDuAnDTO.ToEntity();
            await _trangThaiDuAnService.UpdateTrangThaiDuAn(trangThaiDuAn);
            return Ok(trangThaiDuAn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangThaiDuAn(int id)
        {
            await _trangThaiDuAnService.DeleteTrangThaiDuAn(id);
            return Ok();
        }
    }
}