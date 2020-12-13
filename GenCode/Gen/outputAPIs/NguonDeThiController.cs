using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class NguonDeThiController: BaseApiController
    {
        private readonly INguonDeThiService _nguonDeThiService;

        public NguonDeThiController(INguonDeThiService nguonDeThiService)
        {
            _nguonDeThiService = nguonDeThiService;
        }

        [ProducesResponseType(typeof(PagedResult<NguonDeThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetNguonDeThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _nguonDeThiService.GetNguonDeThi(keywords);
            var nguonDeThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = nguonDeThi.TotalCount;
            var result = new PagedResult<NguonDeThiDTO>(pagination, nguonDeThi.Select(NguonDeThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(NguonDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNguonDeThiById(int id)
        {
            var nguonDeThi = await _nguonDeThiService.GetNguonDeThiById(id);
            var result = NguonDeThiDTO.FromEntity(nguonDeThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(NguonDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateNguonDeThi(NguonDeThiDTO nguonDeThiDTO)
        {
            var nguonDeThi = nguonDeThiDTO.ToEntity();
            await _nguonDeThiService.CreateNguonDeThi(nguonDeThi);
            return Ok(nguonDeThi);
        }

        [ProducesResponseType(typeof(NguonDeThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNguonDeThi(int id, [FromBody]NguonDeThiDTO nguonDeThiDTO)
        {
            var nguonDeThi = nguonDeThiDTO.ToEntity();
            await _nguonDeThiService.UpdateNguonDeThi(nguonDeThi);
            return Ok(nguonDeThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguonDeThi(int id)
        {
            await _nguonDeThiService.DeleteNguonDeThi(id);
            return Ok();
        }
    }
}