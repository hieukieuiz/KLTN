using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class KetQuaBaiThiController: BaseApiController
    {
        private readonly IKetQuaBaiThiService _ketQuaBaiThiService;

        public KetQuaBaiThiController(IKetQuaBaiThiService ketQuaBaiThiService)
        {
            _ketQuaBaiThiService = ketQuaBaiThiService;
        }

        [ProducesResponseType(typeof(PagedResult<KetQuaBaiThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetKetQuaBaiThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _ketQuaBaiThiService.GetKetQuaBaiThi(keywords);
            var ketQuaBaiThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = ketQuaBaiThi.TotalCount;
            var result = new PagedResult<KetQuaBaiThiDTO>(pagination, ketQuaBaiThi.Select(KetQuaBaiThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(KetQuaBaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKetQuaBaiThiById(int id)
        {
            var ketQuaBaiThi = await _ketQuaBaiThiService.GetKetQuaBaiThiById(id);
            var result = KetQuaBaiThiDTO.FromEntity(ketQuaBaiThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(KetQuaBaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateKetQuaBaiThi(KetQuaBaiThiDTO ketQuaBaiThiDTO)
        {
            var ketQuaBaiThi = ketQuaBaiThiDTO.ToEntity();
            await _ketQuaBaiThiService.CreateKetQuaBaiThi(ketQuaBaiThi);
            return Ok(ketQuaBaiThi);
        }

        [ProducesResponseType(typeof(KetQuaBaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKetQuaBaiThi(int id, [FromBody]KetQuaBaiThiDTO ketQuaBaiThiDTO)
        {
            var ketQuaBaiThi = ketQuaBaiThiDTO.ToEntity();
            await _ketQuaBaiThiService.UpdateKetQuaBaiThi(ketQuaBaiThi);
            return Ok(ketQuaBaiThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKetQuaBaiThi(int id)
        {
            await _ketQuaBaiThiService.DeleteKetQuaBaiThi(id);
            return Ok();
        }
    }
}