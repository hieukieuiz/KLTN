using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class ThanhVienDuAnController: BaseApiController
    {
        private readonly IThanhVienDuAnService _thanhVienDuAnService;

        public ThanhVienDuAnController(IThanhVienDuAnService thanhVienDuAnService)
        {
            _thanhVienDuAnService = thanhVienDuAnService;
        }

        [ProducesResponseType(typeof(PagedResult<ThanhVienDuAnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetThanhVienDuAn([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _thanhVienDuAnService.GetThanhVienDuAn(keywords);
            var thanhVienDuAn = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = thanhVienDuAn.TotalCount;
            var result = new PagedResult<ThanhVienDuAnDTO>(pagination, thanhVienDuAn.Select(ThanhVienDuAnDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(ThanhVienDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetThanhVienDuAnById(int id)
        {
            var thanhVienDuAn = await _thanhVienDuAnService.GetThanhVienDuAnById(id);
            var result = ThanhVienDuAnDTO.FromEntity(thanhVienDuAn);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ThanhVienDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateThanhVienDuAn(ThanhVienDuAnDTO thanhVienDuAnDTO)
        {
            var thanhVienDuAn = thanhVienDuAnDTO.ToEntity();
            await _thanhVienDuAnService.CreateThanhVienDuAn(thanhVienDuAn);
            return Ok(thanhVienDuAn);
        }

        [ProducesResponseType(typeof(ThanhVienDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateThanhVienDuAn(int id, [FromBody]ThanhVienDuAnDTO thanhVienDuAnDTO)
        {
            var thanhVienDuAn = thanhVienDuAnDTO.ToEntity();
            await _thanhVienDuAnService.UpdateThanhVienDuAn(thanhVienDuAn);
            return Ok(thanhVienDuAn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanhVienDuAn(int id)
        {
            await _thanhVienDuAnService.DeleteThanhVienDuAn(id);
            return Ok();
        }
    }
}