using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class BaoCaoController: BaseApiController
    {
        private readonly IBaoCaoService _baoCaoService;

        public BaoCaoController(IBaoCaoService baoCaoService)
        {
            _baoCaoService = baoCaoService;
        }

        [ProducesResponseType(typeof(PagedResult<BaoCaoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetBaoCao([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _baoCaoService.GetBaoCao(keywords);
            var baoCao = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = baoCao.TotalCount;
            var result = new PagedResult<BaoCaoDTO>(pagination, baoCao.Select(BaoCaoDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaoCaoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaoCaoById(int id)
        {
            var baoCao = await _baoCaoService.GetBaoCaoById(id);
            var result = BaoCaoDTO.FromEntity(baoCao);
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaoCaoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateBaoCao(BaoCaoDTO baoCaoDTO)
        {
            var baoCao = baoCaoDTO.ToEntity();
            await _baoCaoService.CreateBaoCao(baoCao);
            return Ok(baoCao);
        }

        [ProducesResponseType(typeof(BaoCaoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBaoCao(int id, [FromBody]BaoCaoDTO baoCaoDTO)
        {
            var baoCao = baoCaoDTO.ToEntity();
            await _baoCaoService.UpdateBaoCao(baoCao);
            return Ok(baoCao);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaoCao(int id)
        {
            await _baoCaoService.DeleteBaoCao(id);
            return Ok();
        }
    }
}