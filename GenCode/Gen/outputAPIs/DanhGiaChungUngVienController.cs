using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class DanhGiaChungUngVienController: BaseApiController
    {
        private readonly IDanhGiaChungUngVienService _danhGiaChungUngVienService;

        public DanhGiaChungUngVienController(IDanhGiaChungUngVienService danhGiaChungUngVienService)
        {
            _danhGiaChungUngVienService = danhGiaChungUngVienService;
        }

        [ProducesResponseType(typeof(PagedResult<DanhGiaChungUngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetDanhGiaChungUngVien([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _danhGiaChungUngVienService.GetDanhGiaChungUngVien(keywords);
            var danhGiaChungUngVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = danhGiaChungUngVien.TotalCount;
            var result = new PagedResult<DanhGiaChungUngVienDTO>(pagination, danhGiaChungUngVien.Select(DanhGiaChungUngVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(DanhGiaChungUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDanhGiaChungUngVienById(int id)
        {
            var danhGiaChungUngVien = await _danhGiaChungUngVienService.GetDanhGiaChungUngVienById(id);
            var result = DanhGiaChungUngVienDTO.FromEntity(danhGiaChungUngVien);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DanhGiaChungUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateDanhGiaChungUngVien(DanhGiaChungUngVienDTO danhGiaChungUngVienDTO)
        {
            var danhGiaChungUngVien = danhGiaChungUngVienDTO.ToEntity();
            await _danhGiaChungUngVienService.CreateDanhGiaChungUngVien(danhGiaChungUngVien);
            return Ok(danhGiaChungUngVien);
        }

        [ProducesResponseType(typeof(DanhGiaChungUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDanhGiaChungUngVien(int id, [FromBody]DanhGiaChungUngVienDTO danhGiaChungUngVienDTO)
        {
            var danhGiaChungUngVien = danhGiaChungUngVienDTO.ToEntity();
            await _danhGiaChungUngVienService.UpdateDanhGiaChungUngVien(danhGiaChungUngVien);
            return Ok(danhGiaChungUngVien);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhGiaChungUngVien(int id)
        {
            await _danhGiaChungUngVienService.DeleteDanhGiaChungUngVien(id);
            return Ok();
        }
    }
}