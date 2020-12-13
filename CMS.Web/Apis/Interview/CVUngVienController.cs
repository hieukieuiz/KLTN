using CMS.Core.Interfaces.Services;
using CMS.Core.Interfaces.Services.Interview;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class CVUngVienController: BaseApiController
    {
        private readonly ICVUngVienService _cvUngVienService;

        public CVUngVienController(ICVUngVienService cvUngVienService)
        {
            _cvUngVienService = cvUngVienService;
        }

        [ProducesResponseType(typeof(PagedResult<CVUngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetCVUngVien([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _cvUngVienService.GetCVUngVien(keywords);
            var cvUngVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = cvUngVien.TotalCount;
            var result = new PagedResult<CVUngVienDTO>(pagination, cvUngVien.Select(CVUngVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(CVUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCVUngVienById(int id)
        {
            var cvUngVien = await _cvUngVienService.GetCVUngVienById(id);
            var result = CVUngVienDTO.FromEntity(cvUngVien);
            return Ok(result);
        }

        [ProducesResponseType(typeof(CVUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateCVUngVien(CVUngVienDTO cvUngVienDTO)
        {
            var cvUngVien = cvUngVienDTO.ToEntity();
            await _cvUngVienService.CreateCVUngVien(cvUngVien);
            return Ok(cvUngVien);
        }

        [ProducesResponseType(typeof(CVUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCVUngVien(int id, [FromBody]CVUngVienDTO cvUngVienDTO)
        {
            var cvUngVien = cvUngVienDTO.ToEntity();
            await _cvUngVienService.UpdateCVUngVien(cvUngVien);
            return Ok(cvUngVien);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCVUngVien(int id)
        {
            await _cvUngVienService.DeleteCVUngVien(id);
            return Ok();
        }
    }
}