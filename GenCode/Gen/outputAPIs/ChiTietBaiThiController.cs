using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ChiTietBaiThiController: BaseApiController
    {
        private readonly IChiTietBaiThiService _chiTietBaiThiService;

        public ChiTietBaiThiController(IChiTietBaiThiService chiTietBaiThiService)
        {
            _chiTietBaiThiService = chiTietBaiThiService;
        }

        [ProducesResponseType(typeof(PagedResult<ChiTietBaiThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetChiTietBaiThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _chiTietBaiThiService.GetChiTietBaiThi(keywords);
            var chiTietBaiThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = chiTietBaiThi.TotalCount;
            var result = new PagedResult<ChiTietBaiThiDTO>(pagination, chiTietBaiThi.Select(ChiTietBaiThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietBaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiTietBaiThiById(int id)
        {
            var chiTietBaiThi = await _chiTietBaiThiService.GetChiTietBaiThiById(id);
            var result = ChiTietBaiThiDTO.FromEntity(chiTietBaiThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ChiTietBaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateChiTietBaiThi(ChiTietBaiThiDTO chiTietBaiThiDTO)
        {
            var chiTietBaiThi = chiTietBaiThiDTO.ToEntity();
            await _chiTietBaiThiService.CreateChiTietBaiThi(chiTietBaiThi);
            return Ok(chiTietBaiThi);
        }

        [ProducesResponseType(typeof(ChiTietBaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChiTietBaiThi(int id, [FromBody]ChiTietBaiThiDTO chiTietBaiThiDTO)
        {
            var chiTietBaiThi = chiTietBaiThiDTO.ToEntity();
            await _chiTietBaiThiService.UpdateChiTietBaiThi(chiTietBaiThi);
            return Ok(chiTietBaiThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietBaiThi(int id)
        {
            await _chiTietBaiThiService.DeleteChiTietBaiThi(id);
            return Ok();
        }
    }
}