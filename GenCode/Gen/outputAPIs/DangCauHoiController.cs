using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class DangCauHoiController: BaseApiController
    {
        private readonly IDangCauHoiService _dangCauHoiService;

        public DangCauHoiController(IDangCauHoiService dangCauHoiService)
        {
            _dangCauHoiService = dangCauHoiService;
        }

        [ProducesResponseType(typeof(PagedResult<DangCauHoiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetDangCauHoi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _dangCauHoiService.GetDangCauHoi(keywords);
            var dangCauHoi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = dangCauHoi.TotalCount;
            var result = new PagedResult<DangCauHoiDTO>(pagination, dangCauHoi.Select(DangCauHoiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(DangCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDangCauHoiById(int id)
        {
            var dangCauHoi = await _dangCauHoiService.GetDangCauHoiById(id);
            var result = DangCauHoiDTO.FromEntity(dangCauHoi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DangCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateDangCauHoi(DangCauHoiDTO dangCauHoiDTO)
        {
            var dangCauHoi = dangCauHoiDTO.ToEntity();
            await _dangCauHoiService.CreateDangCauHoi(dangCauHoi);
            return Ok(dangCauHoi);
        }

        [ProducesResponseType(typeof(DangCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDangCauHoi(int id, [FromBody]DangCauHoiDTO dangCauHoiDTO)
        {
            var dangCauHoi = dangCauHoiDTO.ToEntity();
            await _dangCauHoiService.UpdateDangCauHoi(dangCauHoi);
            return Ok(dangCauHoi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDangCauHoi(int id)
        {
            await _dangCauHoiService.DeleteDangCauHoi(id);
            return Ok();
        }
    }
}