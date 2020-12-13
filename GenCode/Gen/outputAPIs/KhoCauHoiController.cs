using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class KhoCauHoiController: BaseApiController
    {
        private readonly IKhoCauHoiService _khoCauHoiService;

        public KhoCauHoiController(IKhoCauHoiService khoCauHoiService)
        {
            _khoCauHoiService = khoCauHoiService;
        }

        [ProducesResponseType(typeof(PagedResult<KhoCauHoiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetKhoCauHoi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _khoCauHoiService.GetKhoCauHoi(keywords);
            var khoCauHoi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = khoCauHoi.TotalCount;
            var result = new PagedResult<KhoCauHoiDTO>(pagination, khoCauHoi.Select(KhoCauHoiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(KhoCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhoCauHoiById(int id)
        {
            var khoCauHoi = await _khoCauHoiService.GetKhoCauHoiById(id);
            var result = KhoCauHoiDTO.FromEntity(khoCauHoi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(KhoCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateKhoCauHoi(KhoCauHoiDTO khoCauHoiDTO)
        {
            var khoCauHoi = khoCauHoiDTO.ToEntity();
            await _khoCauHoiService.CreateKhoCauHoi(khoCauHoi);
            return Ok(khoCauHoi);
        }

        [ProducesResponseType(typeof(KhoCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhoCauHoi(int id, [FromBody]KhoCauHoiDTO khoCauHoiDTO)
        {
            var khoCauHoi = khoCauHoiDTO.ToEntity();
            await _khoCauHoiService.UpdateKhoCauHoi(khoCauHoi);
            return Ok(khoCauHoi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoCauHoi(int id)
        {
            await _khoCauHoiService.DeleteKhoCauHoi(id);
            return Ok();
        }
    }
}