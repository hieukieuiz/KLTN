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
    public class QuaTrinhHocTapController: BaseApiController
    {
        private readonly IQuaTrinhHocTapService _quaTrinhHocTapService;

        public QuaTrinhHocTapController(IQuaTrinhHocTapService quaTrinhHocTapService)
        {
            _quaTrinhHocTapService = quaTrinhHocTapService;
        }

        [ProducesResponseType(typeof(PagedResult<QuaTrinhHocTapDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetQuaTrinhHocTap([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _quaTrinhHocTapService.GetQuaTrinhHocTap(keywords);
            var quaTrinhHocTap = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = quaTrinhHocTap.TotalCount;
            var result = new PagedResult<QuaTrinhHocTapDTO>(pagination, quaTrinhHocTap.Select(QuaTrinhHocTapDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuaTrinhHocTapDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuaTrinhHocTapById(int id)
        {
            var quaTrinhHocTap = await _quaTrinhHocTapService.GetQuaTrinhHocTapById(id);
            var result = QuaTrinhHocTapDTO.FromEntity(quaTrinhHocTap);
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuaTrinhHocTapDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateQuaTrinhHocTap(QuaTrinhHocTapDTO quaTrinhHocTapDTO)
        {
            var quaTrinhHocTap = quaTrinhHocTapDTO.ToEntity();
            await _quaTrinhHocTapService.CreateQuaTrinhHocTap(quaTrinhHocTap);
            return Ok(quaTrinhHocTap);
        }

        [ProducesResponseType(typeof(QuaTrinhHocTapDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuaTrinhHocTap(int id, [FromBody]QuaTrinhHocTapDTO quaTrinhHocTapDTO)
        {
            var quaTrinhHocTap = quaTrinhHocTapDTO.ToEntity();
            await _quaTrinhHocTapService.UpdateQuaTrinhHocTap(quaTrinhHocTap);
            return Ok(quaTrinhHocTap);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuaTrinhHocTap(int id)
        {
            await _quaTrinhHocTapService.DeleteQuaTrinhHocTap(id);
            return Ok();
        }
    }
}