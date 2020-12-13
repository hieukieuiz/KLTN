using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ChiTietDeThiController: BaseApiController
    {
        private readonly IChiTietDeThiService _chiTietDeThiService;

        public ChiTietDeThiController(IChiTietDeThiService chiTietDeThiService)
        {
            _chiTietDeThiService = chiTietDeThiService;
        }

        [ProducesResponseType(typeof(PagedResult<ChiTietDeThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetChiTietDeThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _chiTietDeThiService.GetChiTietDeThi(keywords);
            var chiTietDeThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = chiTietDeThi.TotalCount;
            var result = new PagedResult<ChiTietDeThiDTO>(pagination, chiTietDeThi.Select(ChiTietDeThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiTietDeThiById(int id)
        {
            var chiTietDeThi = await _chiTietDeThiService.GetChiTietDeThiById(id);
            var result = ChiTietDeThiDTO.FromEntity(chiTietDeThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateChiTietDeThi(ChiTietDeThiDTO chiTietDeThiDTO)
        {
            var chiTietDeThi = chiTietDeThiDTO.ToEntity();
            await _chiTietDeThiService.CreateChiTietDeThi(chiTietDeThi);
            return Ok(chiTietDeThi);
        }

        [ProducesResponseType(typeof(ChiTietDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChiTietDeThi(int id, [FromBody]ChiTietDeThiDTO chiTietDeThiDTO)
        {
            var chiTietDeThi = chiTietDeThiDTO.ToEntity();
            await _chiTietDeThiService.UpdateChiTietDeThi(chiTietDeThi);
            return Ok(chiTietDeThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDeThi(int id)
        {
            await _chiTietDeThiService.DeleteChiTietDeThi(id);
            return Ok();
        }
    }
}