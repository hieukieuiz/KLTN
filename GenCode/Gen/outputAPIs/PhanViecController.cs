using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class PhanViecController: BaseApiController
    {
        private readonly IPhanViecService _phanViecService;

        public PhanViecController(IPhanViecService phanViecService)
        {
            _phanViecService = phanViecService;
        }

        [ProducesResponseType(typeof(PagedResult<PhanViecDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetPhanViec([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _phanViecService.GetPhanViec(keywords);
            var phanViec = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = phanViec.TotalCount;
            var result = new PagedResult<PhanViecDTO>(pagination, phanViec.Select(PhanViecDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(PhanViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhanViecById(int id)
        {
            var phanViec = await _phanViecService.GetPhanViecById(id);
            var result = PhanViecDTO.FromEntity(phanViec);
            return Ok(result);
        }

        [ProducesResponseType(typeof(PhanViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreatePhanViec(PhanViecDTO phanViecDTO)
        {
            var phanViec = phanViecDTO.ToEntity();
            await _phanViecService.CreatePhanViec(phanViec);
            return Ok(phanViec);
        }

        [ProducesResponseType(typeof(PhanViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhanViec(int id, [FromBody]PhanViecDTO phanViecDTO)
        {
            var phanViec = phanViecDTO.ToEntity();
            await _phanViecService.UpdatePhanViec(phanViec);
            return Ok(phanViec);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanViec(int id)
        {
            await _phanViecService.DeletePhanViec(id);
            return Ok();
        }
    }
}