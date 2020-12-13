using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class DoanhNghiepController: BaseApiController
    {
        private readonly IDoanhNghiepService _doanhNghiepService;

        public DoanhNghiepController(IDoanhNghiepService doanhNghiepService)
        {
            _doanhNghiepService = doanhNghiepService;
        }

        [ProducesResponseType(typeof(PagedResult<DoanhNghiepDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetDoanhNghiep([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _doanhNghiepService.GetDoanhNghiep(keywords);
            var doanhNghiep = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = doanhNghiep.TotalCount;
            var result = new PagedResult<DoanhNghiepDTO>(pagination, doanhNghiep.Select(DoanhNghiepDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(DoanhNghiepDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoanhNghiepById(int id)
        {
            var doanhNghiep = await _doanhNghiepService.GetDoanhNghiepById(id);
            var result = DoanhNghiepDTO.FromEntity(doanhNghiep);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DoanhNghiepDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateDoanhNghiep(DoanhNghiepDTO doanhNghiepDTO)
        {
            var doanhNghiep = doanhNghiepDTO.ToEntity();
            await _doanhNghiepService.CreateDoanhNghiep(doanhNghiep);
            return Ok(doanhNghiep);
        }

        [ProducesResponseType(typeof(DoanhNghiepDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoanhNghiep(int id, [FromBody]DoanhNghiepDTO doanhNghiepDTO)
        {
            var doanhNghiep = doanhNghiepDTO.ToEntity();
            await _doanhNghiepService.UpdateDoanhNghiep(doanhNghiep);
            return Ok(doanhNghiep);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoanhNghiep(int id)
        {
            await _doanhNghiepService.DeleteDoanhNghiep(id);
            return Ok();
        }
    }
}