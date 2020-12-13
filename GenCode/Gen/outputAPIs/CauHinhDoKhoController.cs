using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class CauHinhDoKhoController: BaseApiController
    {
        private readonly ICauHinhDoKhoService _cauHinhDoKhoService;

        public CauHinhDoKhoController(ICauHinhDoKhoService cauHinhDoKhoService)
        {
            _cauHinhDoKhoService = cauHinhDoKhoService;
        }

        [ProducesResponseType(typeof(PagedResult<CauHinhDoKhoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetCauHinhDoKho([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _cauHinhDoKhoService.GetCauHinhDoKho(keywords);
            var cauHinhDoKho = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = cauHinhDoKho.TotalCount;
            var result = new PagedResult<CauHinhDoKhoDTO>(pagination, cauHinhDoKho.Select(CauHinhDoKhoDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(CauHinhDoKhoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCauHinhDoKhoById(int id)
        {
            var cauHinhDoKho = await _cauHinhDoKhoService.GetCauHinhDoKhoById(id);
            var result = CauHinhDoKhoDTO.FromEntity(cauHinhDoKho);
            return Ok(result);
        }

        [ProducesResponseType(typeof(CauHinhDoKhoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateCauHinhDoKho(CauHinhDoKhoDTO cauHinhDoKhoDTO)
        {
            var cauHinhDoKho = cauHinhDoKhoDTO.ToEntity();
            await _cauHinhDoKhoService.CreateCauHinhDoKho(cauHinhDoKho);
            return Ok(cauHinhDoKho);
        }

        [ProducesResponseType(typeof(CauHinhDoKhoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCauHinhDoKho(int id, [FromBody]CauHinhDoKhoDTO cauHinhDoKhoDTO)
        {
            var cauHinhDoKho = cauHinhDoKhoDTO.ToEntity();
            await _cauHinhDoKhoService.UpdateCauHinhDoKho(cauHinhDoKho);
            return Ok(cauHinhDoKho);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCauHinhDoKho(int id)
        {
            await _cauHinhDoKhoService.DeleteCauHinhDoKho(id);
            return Ok();
        }
    }
}