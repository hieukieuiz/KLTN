using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class DapAnCauHoiController: BaseApiController
    {
        private readonly IDapAnCauHoiService _dapAnCauHoiService;

        public DapAnCauHoiController(IDapAnCauHoiService dapAnCauHoiService)
        {
            _dapAnCauHoiService = dapAnCauHoiService;
        }

        [ProducesResponseType(typeof(PagedResult<DapAnCauHoiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetDapAnCauHoi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _dapAnCauHoiService.GetDapAnCauHoi(keywords);
            var dapAnCauHoi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = dapAnCauHoi.TotalCount;
            var result = new PagedResult<DapAnCauHoiDTO>(pagination, dapAnCauHoi.Select(DapAnCauHoiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(DapAnCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDapAnCauHoiById(int id)
        {
            var dapAnCauHoi = await _dapAnCauHoiService.GetDapAnCauHoiById(id);
            var result = DapAnCauHoiDTO.FromEntity(dapAnCauHoi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DapAnCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateDapAnCauHoi(DapAnCauHoiDTO dapAnCauHoiDTO)
        {
            var dapAnCauHoi = dapAnCauHoiDTO.ToEntity();
            await _dapAnCauHoiService.CreateDapAnCauHoi(dapAnCauHoi);
            return Ok(dapAnCauHoi);
        }

        [ProducesResponseType(typeof(DapAnCauHoiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDapAnCauHoi(int id, [FromBody]DapAnCauHoiDTO dapAnCauHoiDTO)
        {
            var dapAnCauHoi = dapAnCauHoiDTO.ToEntity();
            await _dapAnCauHoiService.UpdateDapAnCauHoi(dapAnCauHoi);
            return Ok(dapAnCauHoi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDapAnCauHoi(int id)
        {
            await _dapAnCauHoiService.DeleteDapAnCauHoi(id);
            return Ok();
        }
    }
}