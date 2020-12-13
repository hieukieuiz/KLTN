using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class BangCapUngVienController: BaseApiController
    {
        private readonly IBangCapUngVienService _bangCapUngVienService;

        public BangCapUngVienController(IBangCapUngVienService bangCapUngVienService)
        {
            _bangCapUngVienService = bangCapUngVienService;
        }

        [ProducesResponseType(typeof(PagedResult<BangCapUngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetBangCapUngVien([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _bangCapUngVienService.GetBangCapUngVien(keywords);
            var bangCapUngVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = bangCapUngVien.TotalCount;
            var result = new PagedResult<BangCapUngVienDTO>(pagination, bangCapUngVien.Select(BangCapUngVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(BangCapUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBangCapUngVienById(int id)
        {
            var bangCapUngVien = await _bangCapUngVienService.GetBangCapUngVienById(id);
            var result = BangCapUngVienDTO.FromEntity(bangCapUngVien);
            return Ok(result);
        }

        [ProducesResponseType(typeof(BangCapUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateBangCapUngVien(BangCapUngVienDTO bangCapUngVienDTO)
        {
            var bangCapUngVien = bangCapUngVienDTO.ToEntity();
            await _bangCapUngVienService.CreateBangCapUngVien(bangCapUngVien);
            return Ok(bangCapUngVien);
        }

        [ProducesResponseType(typeof(BangCapUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBangCapUngVien(int id, [FromBody]BangCapUngVienDTO bangCapUngVienDTO)
        {
            var bangCapUngVien = bangCapUngVienDTO.ToEntity();
            await _bangCapUngVienService.UpdateBangCapUngVien(bangCapUngVien);
            return Ok(bangCapUngVien);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBangCapUngVien(int id)
        {
            await _bangCapUngVienService.DeleteBangCapUngVien(id);
            return Ok();
        }
    }
}