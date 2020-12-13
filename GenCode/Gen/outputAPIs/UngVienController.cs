using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class UngVienController: BaseApiController
    {
        private readonly IUngVienService _ungVienService;

        public UngVienController(IUngVienService ungVienService)
        {
            _ungVienService = ungVienService;
        }

        [ProducesResponseType(typeof(PagedResult<UngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetUngVien([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _ungVienService.GetUngVien(keywords);
            var ungVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = ungVien.TotalCount;
            var result = new PagedResult<UngVienDTO>(pagination, ungVien.Select(UngVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUngVienById(int id)
        {
            var ungVien = await _ungVienService.GetUngVienById(id);
            var result = UngVienDTO.FromEntity(ungVien);
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateUngVien(UngVienDTO ungVienDTO)
        {
            var ungVien = ungVienDTO.ToEntity();
            await _ungVienService.CreateUngVien(ungVien);
            return Ok(ungVien);
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUngVien(int id, [FromBody]UngVienDTO ungVienDTO)
        {
            var ungVien = ungVienDTO.ToEntity();
            await _ungVienService.UpdateUngVien(ungVien);
            return Ok(ungVien);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUngVien(int id)
        {
            await _ungVienService.DeleteUngVien(id);
            return Ok();
        }
    }
}