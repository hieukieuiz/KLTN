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
    public class KyNangUngVienController: BaseApiController
    {
        private readonly IKyNangUngVienService _kyNangUngVienService;

        public KyNangUngVienController(IKyNangUngVienService kyNangUngVienService)
        {
            _kyNangUngVienService = kyNangUngVienService;
        }

        [ProducesResponseType(typeof(PagedResult<KyNangUngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetKyNangUngVien([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _kyNangUngVienService.GetKyNangUngVien(keywords);
            var kyNangUngVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = kyNangUngVien.TotalCount;
            var result = new PagedResult<KyNangUngVienDTO>(pagination, kyNangUngVien.Select(KyNangUngVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(KyNangUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKyNangUngVienById(int id)
        {
            var kyNangUngVien = await _kyNangUngVienService.GetKyNangUngVienById(id);
            var result = KyNangUngVienDTO.FromEntity(kyNangUngVien);
            return Ok(result);
        }

        [ProducesResponseType(typeof(KyNangUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateKyNangUngVien(KyNangUngVienDTO kyNangUngVienDTO)
        {
            var kyNangUngVien = kyNangUngVienDTO.ToEntity();
            await _kyNangUngVienService.CreateKyNangUngVien(kyNangUngVien);
            return Ok(kyNangUngVien);
        }

        [ProducesResponseType(typeof(KyNangUngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKyNangUngVien(int id, [FromBody]KyNangUngVienDTO kyNangUngVienDTO)
        {
            var kyNangUngVien = kyNangUngVienDTO.ToEntity();
            await _kyNangUngVienService.UpdateKyNangUngVien(kyNangUngVien);
            return Ok(kyNangUngVien);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKyNangUngVien(int id)
        {
            await _kyNangUngVienService.DeleteKyNangUngVien(id);
            return Ok();
        }
    }
}