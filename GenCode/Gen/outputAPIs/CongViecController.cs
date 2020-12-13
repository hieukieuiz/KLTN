using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class CongViecController: BaseApiController
    {
        private readonly ICongViecService _congViecService;

        public CongViecController(ICongViecService congViecService)
        {
            _congViecService = congViecService;
        }

        [ProducesResponseType(typeof(PagedResult<CongViecDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetCongViec([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _congViecService.GetCongViec(keywords);
            var congViec = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = congViec.TotalCount;
            var result = new PagedResult<CongViecDTO>(pagination, congViec.Select(CongViecDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(CongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCongViecById(int id)
        {
            var congViec = await _congViecService.GetCongViecById(id);
            var result = CongViecDTO.FromEntity(congViec);
            return Ok(result);
        }

        [ProducesResponseType(typeof(CongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateCongViec(CongViecDTO congViecDTO)
        {
            var congViec = congViecDTO.ToEntity();
            await _congViecService.CreateCongViec(congViec);
            return Ok(congViec);
        }

        [ProducesResponseType(typeof(CongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCongViec(int id, [FromBody]CongViecDTO congViecDTO)
        {
            var congViec = congViecDTO.ToEntity();
            await _congViecService.UpdateCongViec(congViec);
            return Ok(congViec);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongViec(int id)
        {
            await _congViecService.DeleteCongViec(id);
            return Ok();
        }
    }
}