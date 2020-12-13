using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class HienThiDeThiController: BaseApiController
    {
        private readonly IHienThiDeThiService _hienThiDeThiService;

        public HienThiDeThiController(IHienThiDeThiService hienThiDeThiService)
        {
            _hienThiDeThiService = hienThiDeThiService;
        }

        [ProducesResponseType(typeof(PagedResult<HienThiDeThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetHienThiDeThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _hienThiDeThiService.GetHienThiDeThi(keywords);
            var hienThiDeThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = hienThiDeThi.TotalCount;
            var result = new PagedResult<HienThiDeThiDTO>(pagination, hienThiDeThi.Select(HienThiDeThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(HienThiDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHienThiDeThiById(int id)
        {
            var hienThiDeThi = await _hienThiDeThiService.GetHienThiDeThiById(id);
            var result = HienThiDeThiDTO.FromEntity(hienThiDeThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(HienThiDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateHienThiDeThi(HienThiDeThiDTO hienThiDeThiDTO)
        {
            var hienThiDeThi = hienThiDeThiDTO.ToEntity();
            await _hienThiDeThiService.CreateHienThiDeThi(hienThiDeThi);
            return Ok(hienThiDeThi);
        }

        [ProducesResponseType(typeof(HienThiDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHienThiDeThi(int id, [FromBody]HienThiDeThiDTO hienThiDeThiDTO)
        {
            var hienThiDeThi = hienThiDeThiDTO.ToEntity();
            await _hienThiDeThiService.UpdateHienThiDeThi(hienThiDeThi);
            return Ok(hienThiDeThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHienThiDeThi(int id)
        {
            await _hienThiDeThiService.DeleteHienThiDeThi(id);
            return Ok();
        }
    }
}