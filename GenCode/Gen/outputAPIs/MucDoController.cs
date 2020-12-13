using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class MucDoController: BaseApiController
    {
        private readonly IMucDoService _mucDoService;

        public MucDoController(IMucDoService mucDoService)
        {
            _mucDoService = mucDoService;
        }

        [ProducesResponseType(typeof(PagedResult<MucDoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetMucDo([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _mucDoService.GetMucDo(keywords);
            var mucDo = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = mucDo.TotalCount;
            var result = new PagedResult<MucDoDTO>(pagination, mucDo.Select(MucDoDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(MucDoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMucDoById(int id)
        {
            var mucDo = await _mucDoService.GetMucDoById(id);
            var result = MucDoDTO.FromEntity(mucDo);
            return Ok(result);
        }

        [ProducesResponseType(typeof(MucDoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateMucDo(MucDoDTO mucDoDTO)
        {
            var mucDo = mucDoDTO.ToEntity();
            await _mucDoService.CreateMucDo(mucDo);
            return Ok(mucDo);
        }

        [ProducesResponseType(typeof(MucDoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMucDo(int id, [FromBody]MucDoDTO mucDoDTO)
        {
            var mucDo = mucDoDTO.ToEntity();
            await _mucDoService.UpdateMucDo(mucDo);
            return Ok(mucDo);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMucDo(int id)
        {
            await _mucDoService.DeleteMucDo(id);
            return Ok();
        }
    }
}