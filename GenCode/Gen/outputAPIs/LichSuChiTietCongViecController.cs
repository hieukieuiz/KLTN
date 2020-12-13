using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class LichSuChiTietCongViecController: BaseApiController
    {
        private readonly ILichSuChiTietCongViecService _lichSuChiTietCongViecService;

        public LichSuChiTietCongViecController(ILichSuChiTietCongViecService lichSuChiTietCongViecService)
        {
            _lichSuChiTietCongViecService = lichSuChiTietCongViecService;
        }

        [ProducesResponseType(typeof(PagedResult<LichSuChiTietCongViecDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetLichSuChiTietCongViec([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _lichSuChiTietCongViecService.GetLichSuChiTietCongViec(keywords);
            var lichSuChiTietCongViec = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = lichSuChiTietCongViec.TotalCount;
            var result = new PagedResult<LichSuChiTietCongViecDTO>(pagination, lichSuChiTietCongViec.Select(LichSuChiTietCongViecDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(LichSuChiTietCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLichSuChiTietCongViecById(int id)
        {
            var lichSuChiTietCongViec = await _lichSuChiTietCongViecService.GetLichSuChiTietCongViecById(id);
            var result = LichSuChiTietCongViecDTO.FromEntity(lichSuChiTietCongViec);
            return Ok(result);
        }

        [ProducesResponseType(typeof(LichSuChiTietCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateLichSuChiTietCongViec(LichSuChiTietCongViecDTO lichSuChiTietCongViecDTO)
        {
            var lichSuChiTietCongViec = lichSuChiTietCongViecDTO.ToEntity();
            await _lichSuChiTietCongViecService.CreateLichSuChiTietCongViec(lichSuChiTietCongViec);
            return Ok(lichSuChiTietCongViec);
        }

        [ProducesResponseType(typeof(LichSuChiTietCongViecDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLichSuChiTietCongViec(int id, [FromBody]LichSuChiTietCongViecDTO lichSuChiTietCongViecDTO)
        {
            var lichSuChiTietCongViec = lichSuChiTietCongViecDTO.ToEntity();
            await _lichSuChiTietCongViecService.UpdateLichSuChiTietCongViec(lichSuChiTietCongViec);
            return Ok(lichSuChiTietCongViec);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichSuChiTietCongViec(int id)
        {
            await _lichSuChiTietCongViecService.DeleteLichSuChiTietCongViec(id);
            return Ok();
        }
    }
}