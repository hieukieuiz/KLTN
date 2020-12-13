using CMS.Core.Enums;
using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class TruongDaiHocController: BaseApiController
    {
        private readonly ITruongDaiHocService _truongDaiHocService;

        public TruongDaiHocController(ITruongDaiHocService truongDaiHocService)
        {
            _truongDaiHocService = truongDaiHocService;
        }

        [ProducesResponseType(typeof(PagedResult<TruongDaiHocDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetTruongDaiHoc([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _truongDaiHocService.GetTruongDaiHoc(keywords);
            var truongDaiHoc = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = truongDaiHoc.TotalCount;
            var result = new PagedResult<TruongDaiHocDTO>(pagination, truongDaiHoc.Select(TruongDaiHocDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(TruongDaiHocDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruongDaiHocById(int id)
        {
            var truongDaiHoc = await _truongDaiHocService.GetTruongDaiHocById(id);
            var result = TruongDaiHocDTO.FromEntity(truongDaiHoc);
            return Ok(result);
        }

        [ProducesResponseType(typeof(TruongDaiHocDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateTruongDaiHoc(TruongDaiHocDTO truongDaiHocDTO)
        {
            var truongDaiHoc = truongDaiHocDTO.ToEntity();
            await _truongDaiHocService.CreateTruongDaiHoc(truongDaiHoc);
            return Ok(truongDaiHoc);
        }

        [ProducesResponseType(typeof(TruongDaiHocDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateTruongDaiHoc(int id, [FromBody]TruongDaiHocDTO truongDaiHocDTO)
        {
            var truongDaiHoc = truongDaiHocDTO.ToEntity();
            await _truongDaiHocService.UpdateTruongDaiHoc(truongDaiHoc);
            return Ok(truongDaiHoc);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteTruongDaiHoc(int id)
        {
            await _truongDaiHocService.DeleteTruongDaiHoc(id);
            return Ok();
        }
    }
}