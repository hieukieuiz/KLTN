using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class HocVienController: BaseApiController
    {
        private readonly IHocVienService _hocVienService;

        public HocVienController(IHocVienService hocVienService)
        {
            _hocVienService = hocVienService;
        }

        [ProducesResponseType(typeof(PagedResult<HocVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetHocVien([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _hocVienService.GetHocVien(keywords);
            var hocVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = hocVien.TotalCount;
            var result = new PagedResult<HocVienDTO>(pagination, hocVien.Select(HocVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(HocVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHocVienById(int id)
        {
            var hocVien = await _hocVienService.GetHocVienById(id);
            var result = HocVienDTO.FromEntity(hocVien);
            return Ok(result);
        }

        [ProducesResponseType(typeof(HocVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateHocVien(HocVienDTO hocVienDTO)
        {
            var hocVien = hocVienDTO.ToEntity();
            await _hocVienService.CreateHocVien(hocVien);
            return Ok(hocVien);
        }

        [ProducesResponseType(typeof(HocVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHocVien(int id, [FromBody]HocVienDTO hocVienDTO)
        {
            var hocVien = hocVienDTO.ToEntity();
            await _hocVienService.UpdateHocVien(hocVien);
            return Ok(hocVien);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVien(int id)
        {
            await _hocVienService.DeleteHocVien(id);
            return Ok();
        }
    }
}