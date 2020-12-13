using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ChiTietDapAnDeThiController: BaseApiController
    {
        private readonly IChiTietDapAnDeThiService _chiTietDapAnDeThiService;

        public ChiTietDapAnDeThiController(IChiTietDapAnDeThiService chiTietDapAnDeThiService)
        {
            _chiTietDapAnDeThiService = chiTietDapAnDeThiService;
        }

        [ProducesResponseType(typeof(PagedResult<ChiTietDapAnDeThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetChiTietDapAnDeThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _chiTietDapAnDeThiService.GetChiTietDapAnDeThi(keywords);
            var chiTietDapAnDeThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = chiTietDapAnDeThi.TotalCount;
            var result = new PagedResult<ChiTietDapAnDeThiDTO>(pagination, chiTietDapAnDeThi.Select(ChiTietDapAnDeThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietDapAnDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiTietDapAnDeThiById(int id)
        {
            var chiTietDapAnDeThi = await _chiTietDapAnDeThiService.GetChiTietDapAnDeThiById(id);
            var result = ChiTietDapAnDeThiDTO.FromEntity(chiTietDapAnDeThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietDapAnDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateChiTietDapAnDeThi(ChiTietDapAnDeThiDTO chiTietDapAnDeThiDTO)
        {
            var chiTietDapAnDeThi = chiTietDapAnDeThiDTO.ToEntity();
            await _chiTietDapAnDeThiService.CreateChiTietDapAnDeThi(chiTietDapAnDeThi);
            return Ok(chiTietDapAnDeThi);
        }

        [ProducesResponseType(typeof(ChiTietDapAnDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChiTietDapAnDeThi(int id, [FromBody]ChiTietDapAnDeThiDTO chiTietDapAnDeThiDTO)
        {
            var chiTietDapAnDeThi = chiTietDapAnDeThiDTO.ToEntity();
            await _chiTietDapAnDeThiService.UpdateChiTietDapAnDeThi(chiTietDapAnDeThi);
            return Ok(chiTietDapAnDeThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDapAnDeThi(int id)
        {
            await _chiTietDapAnDeThiService.DeleteChiTietDapAnDeThi(id);
            return Ok();
        }
    }
}