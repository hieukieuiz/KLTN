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
    public class QuanHuyenController : BaseApiController
    {
        private readonly IQuanHuyenService _quanHuyenService;

        public QuanHuyenController(IQuanHuyenService quanHuyenService)
        {
            _quanHuyenService = quanHuyenService;
        }

        [ProducesResponseType(typeof(PagedResult<QuanHuyenDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetQuanHuyen([FromQuery] string keywords = null, [FromQuery] int? tinhThanhId = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _quanHuyenService.GetQuanHuyen(keywords, tinhThanhId);
            var quanHuyen = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = quanHuyen.TotalCount;
            var result = new PagedResult<QuanHuyenDTO>(pagination, quanHuyen.Select(QuanHuyenDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuanHuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuanHuyenById(int id)
        {
            var quanHuyen = await _quanHuyenService.GetQuanHuyenById(id);
            var result = QuanHuyenDTO.FromEntity(quanHuyen);
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuanHuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateQuanHuyen(QuanHuyenDTO quanHuyenDTO)
        {
            var quanHuyen = quanHuyenDTO.ToEntity();
            await _quanHuyenService.CreateQuanHuyen(quanHuyen);
            return Ok(quanHuyen);
        }

        [ProducesResponseType(typeof(QuanHuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateQuanHuyen(int id, [FromBody]QuanHuyenDTO quanHuyenDTO)
        {
            var quanHuyen = quanHuyenDTO.ToEntity();
            await _quanHuyenService.UpdateQuanHuyen(quanHuyen);
            return Ok(quanHuyen);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteQuanHuyen(int id)
        {
            await _quanHuyenService.DeleteQuanHuyen(id);
            return Ok();
        }
    }
}