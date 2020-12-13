using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class LoaiCongViecController: BaseApiController
    {
        private readonly ILoaiCongViecService _loaiCongViecService;

        public LoaiCongViecController(ILoaiCongViecService loaiCongViecService)
        {
            _loaiCongViecService = loaiCongViecService;
        }

        [ProducesResponseType(typeof(PagedResult<LoaiCongViecDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetLoaiCongViec([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _loaiCongViecService.GetLoaiCongViec(keywords);
            var loaiCongViec = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = loaiCongViec.TotalCount;
            var result = new PagedResult<LoaiCongViecDTO>(pagination, loaiCongViec.Select(LoaiCongViecDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(LoaiCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiCongViecById(int id)
        {
            var loaiCongViec = await _loaiCongViecService.GetLoaiCongViecById(id);
            var result = LoaiCongViecDTO.FromEntity(loaiCongViec);
            return Ok(result);
        }

        [ProducesResponseType(typeof(LoaiCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateLoaiCongViec(LoaiCongViecDTO loaiCongViecDTO)
        {
            var loaiCongViec = loaiCongViecDTO.ToEntity();
            await _loaiCongViecService.CreateLoaiCongViec(loaiCongViec);
            return Ok(loaiCongViec);
        }

        [ProducesResponseType(typeof(LoaiCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoaiCongViec(int id, [FromBody]LoaiCongViecDTO loaiCongViecDTO)
        {
            var loaiCongViec = loaiCongViecDTO.ToEntity();
            await _loaiCongViecService.UpdateLoaiCongViec(loaiCongViec);
            return Ok(loaiCongViec);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiCongViec(int id)
        {
            await _loaiCongViecService.DeleteLoaiCongViec(id);
            return Ok();
        }
    }
}