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
    public class KyNangController: BaseApiController
    {
        private readonly IKyNangService _kyNangService;

        public KyNangController(IKyNangService kyNangService)
        {
            _kyNangService = kyNangService;
        }

        [ProducesResponseType(typeof(PagedResult<KyNangDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetKyNang([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _kyNangService.GetKyNang(keywords);
            var kyNang = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = kyNang.TotalCount;
            var result = new PagedResult<KyNangDTO>(pagination, kyNang.Select(KyNangDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(KyNangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKyNangById(int id)
        {
            var kyNang = await _kyNangService.GetKyNangById(id);
            var result = KyNangDTO.FromEntity(kyNang);
            return Ok(result);
        }

        [ProducesResponseType(typeof(KyNangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateKyNang(KyNangDTO kyNangDTO)
        {
            var kyNang = kyNangDTO.ToEntity();
            await _kyNangService.CreateKyNang(kyNang);
            return Ok(kyNang);
        }

        [ProducesResponseType(typeof(KyNangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKyNang(int id, [FromBody]KyNangDTO kyNangDTO)
        {
            var kyNang = kyNangDTO.ToEntity();
            await _kyNangService.UpdateKyNang(kyNang);
            return Ok(kyNang);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKyNang(int id)
        {
            await _kyNangService.DeleteKyNang(id);
            return Ok();
        }
    }
}