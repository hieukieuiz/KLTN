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
    public class QuaTrinhLamDuAnController: BaseApiController
    {
        private readonly IQuaTrinhLamDuAnService _quaTrinhLamDuAnService;

        public QuaTrinhLamDuAnController(IQuaTrinhLamDuAnService quaTrinhLamDuAnService)
        {
            _quaTrinhLamDuAnService = quaTrinhLamDuAnService;
        }

        [ProducesResponseType(typeof(PagedResult<QuaTrinhLamDuAnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetQuaTrinhLamDuAn([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _quaTrinhLamDuAnService.GetQuaTrinhLamDuAn(keywords);
            var quaTrinhLamDuAn = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = quaTrinhLamDuAn.TotalCount;
            var result = new PagedResult<QuaTrinhLamDuAnDTO>(pagination, quaTrinhLamDuAn.Select(QuaTrinhLamDuAnDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuaTrinhLamDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuaTrinhLamDuAnById(int id)
        {
            var quaTrinhLamDuAn = await _quaTrinhLamDuAnService.GetQuaTrinhLamDuAnById(id);
            var result = QuaTrinhLamDuAnDTO.FromEntity(quaTrinhLamDuAn);
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuaTrinhLamDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateQuaTrinhLamDuAn(QuaTrinhLamDuAnDTO quaTrinhLamDuAnDTO)
        {
            var quaTrinhLamDuAn = quaTrinhLamDuAnDTO.ToEntity();
            await _quaTrinhLamDuAnService.CreateQuaTrinhLamDuAn(quaTrinhLamDuAn);
            return Ok(quaTrinhLamDuAn);
        }

        [ProducesResponseType(typeof(QuaTrinhLamDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuaTrinhLamDuAn(int id, [FromBody]QuaTrinhLamDuAnDTO quaTrinhLamDuAnDTO)
        {
            var quaTrinhLamDuAn = quaTrinhLamDuAnDTO.ToEntity();
            await _quaTrinhLamDuAnService.UpdateQuaTrinhLamDuAn(quaTrinhLamDuAn);
            return Ok(quaTrinhLamDuAn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuaTrinhLamDuAn(int id)
        {
            await _quaTrinhLamDuAnService.DeleteQuaTrinhLamDuAn(id);
            return Ok();
        }
    }
}