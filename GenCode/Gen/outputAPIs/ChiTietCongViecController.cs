using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ChiTietCongViecController: BaseApiController
    {
        private readonly IChiTietCongViecService _chiTietCongViecService;

        public ChiTietCongViecController(IChiTietCongViecService chiTietCongViecService)
        {
            _chiTietCongViecService = chiTietCongViecService;
        }

        [ProducesResponseType(typeof(PagedResult<ChiTietCongViecDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetChiTietCongViec([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _chiTietCongViecService.GetChiTietCongViec(keywords);
            var chiTietCongViec = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = chiTietCongViec.TotalCount;
            var result = new PagedResult<ChiTietCongViecDTO>(pagination, chiTietCongViec.Select(ChiTietCongViecDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiTietCongViecById(int id)
        {
            var chiTietCongViec = await _chiTietCongViecService.GetChiTietCongViecById(id);
            var result = ChiTietCongViecDTO.FromEntity(chiTietCongViec);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateChiTietCongViec(ChiTietCongViecDTO chiTietCongViecDTO)
        {
            var chiTietCongViec = chiTietCongViecDTO.ToEntity();
            await _chiTietCongViecService.CreateChiTietCongViec(chiTietCongViec);
            return Ok(chiTietCongViec);
        }

        [ProducesResponseType(typeof(ChiTietCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChiTietCongViec(int id, [FromBody]ChiTietCongViecDTO chiTietCongViecDTO)
        {
            var chiTietCongViec = chiTietCongViecDTO.ToEntity();
            await _chiTietCongViecService.UpdateChiTietCongViec(chiTietCongViec);
            return Ok(chiTietCongViec);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietCongViec(int id)
        {
            await _chiTietCongViecService.DeleteChiTietCongViec(id);
            return Ok();
        }
    }
}