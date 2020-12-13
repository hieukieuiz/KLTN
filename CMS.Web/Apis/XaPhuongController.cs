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
    public class XaPhuongController : BaseApiController
    {
        private readonly IXaPhuongService _xaPhuongService;

        public XaPhuongController(IXaPhuongService xaPhuongService)
        {
            _xaPhuongService = xaPhuongService;
        }

        [ProducesResponseType(typeof(PagedResult<XaPhuongDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetXaPhuong([FromQuery] string keywords = null, [FromQuery] int? quanHuyenId = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _xaPhuongService.GetXaPhuong(keywords, quanHuyenId);
            var xaPhuong = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = xaPhuong.TotalCount;
            var result = new PagedResult<XaPhuongDTO>(pagination, xaPhuong.Select(XaPhuongDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(XaPhuongDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetXaPhuongById(int id)
        {
            var xaPhuong = await _xaPhuongService.GetXaPhuongById(id);
            var result = XaPhuongDTO.FromEntity(xaPhuong);
            return Ok(result);
        }

        [ProducesResponseType(typeof(XaPhuongDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateXaPhuong(XaPhuongDTO xaPhuongDTO)
        {
            var xaPhuong = xaPhuongDTO.ToEntity();
            await _xaPhuongService.CreateXaPhuong(xaPhuong);
            return Ok(xaPhuong);
        }

        [ProducesResponseType(typeof(XaPhuongDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateXaPhuong(int id, [FromBody]XaPhuongDTO xaPhuongDTO)
        {
            var xaPhuong = xaPhuongDTO.ToEntity();
            await _xaPhuongService.UpdateXaPhuong(xaPhuong);
            return Ok(xaPhuong);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteXaPhuong(int id)
        {
            await _xaPhuongService.DeleteXaPhuong(id);
            return Ok();
        }
    }
}