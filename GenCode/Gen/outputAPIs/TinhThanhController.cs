using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class TinhThanhController: BaseApiController
    {
        private readonly ITinhThanhService _tinhThanhService;

        public TinhThanhController(ITinhThanhService tinhThanhService)
        {
            _tinhThanhService = tinhThanhService;
        }

        [ProducesResponseType(typeof(PagedResult<TinhThanhDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetTinhThanh([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _tinhThanhService.GetTinhThanh(keywords);
            var tinhThanh = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = tinhThanh.TotalCount;
            var result = new PagedResult<TinhThanhDTO>(pagination, tinhThanh.Select(TinhThanhDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(TinhThanhDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTinhThanhById(int id)
        {
            var tinhThanh = await _tinhThanhService.GetTinhThanhById(id);
            var result = TinhThanhDTO.FromEntity(tinhThanh);
            return Ok(result);
        }

        [ProducesResponseType(typeof(TinhThanhDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateTinhThanh(TinhThanhDTO tinhThanhDTO)
        {
            var tinhThanh = tinhThanhDTO.ToEntity();
            await _tinhThanhService.CreateTinhThanh(tinhThanh);
            return Ok(tinhThanh);
        }

        [ProducesResponseType(typeof(TinhThanhDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTinhThanh(int id, [FromBody]TinhThanhDTO tinhThanhDTO)
        {
            var tinhThanh = tinhThanhDTO.ToEntity();
            await _tinhThanhService.UpdateTinhThanh(tinhThanh);
            return Ok(tinhThanh);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTinhThanh(int id)
        {
            await _tinhThanhService.DeleteTinhThanh(id);
            return Ok();
        }
    }
}