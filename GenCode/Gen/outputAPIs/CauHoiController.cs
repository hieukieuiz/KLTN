using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class CauHoiController: BaseApiController
    {
        private readonly ICauHoiService _cauHoiService;

        public CauHoiController(ICauHoiService cauHoiService)
        {
            _cauHoiService = cauHoiService;
        }

        [ProducesResponseType(typeof(PagedResult<CauHoiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetCauHoi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _cauHoiService.GetCauHoi(keywords);
            var cauHoi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = cauHoi.TotalCount;
            var result = new PagedResult<CauHoiDTO>(pagination, cauHoi.Select(CauHoiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(CauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCauHoiById(int id)
        {
            var cauHoi = await _cauHoiService.GetCauHoiById(id);
            var result = CauHoiDTO.FromEntity(cauHoi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(CauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateCauHoi(CauHoiDTO cauHoiDTO)
        {
            var cauHoi = cauHoiDTO.ToEntity();
            await _cauHoiService.CreateCauHoi(cauHoi);
            return Ok(cauHoi);
        }

        [ProducesResponseType(typeof(CauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCauHoi(int id, [FromBody]CauHoiDTO cauHoiDTO)
        {
            var cauHoi = cauHoiDTO.ToEntity();
            await _cauHoiService.UpdateCauHoi(cauHoi);
            return Ok(cauHoi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCauHoi(int id)
        {
            await _cauHoiService.DeleteCauHoi(id);
            return Ok();
        }
    }
}