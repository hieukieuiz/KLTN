using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class UngTuyenController: BaseApiController
    {
        private readonly IUngTuyenService _ungTuyenService;

        public UngTuyenController(IUngTuyenService ungTuyenService)
        {
            _ungTuyenService = ungTuyenService;
        }

        [ProducesResponseType(typeof(PagedResult<UngTuyenDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetUngTuyen([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _ungTuyenService.GetUngTuyen(keywords);
            var ungTuyen = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = ungTuyen.TotalCount;
            var result = new PagedResult<UngTuyenDTO>(pagination, ungTuyen.Select(UngTuyenDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngTuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUngTuyenById(int id)
        {
            var ungTuyen = await _ungTuyenService.GetUngTuyenById(id);
            var result = UngTuyenDTO.FromEntity(ungTuyen);
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngTuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateUngTuyen(UngTuyenDTO ungTuyenDTO)
        {
            var ungTuyen = ungTuyenDTO.ToEntity();
            await _ungTuyenService.CreateUngTuyen(ungTuyen);
            return Ok(ungTuyen);
        }

        [ProducesResponseType(typeof(UngTuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUngTuyen(int id, [FromBody]UngTuyenDTO ungTuyenDTO)
        {
            var ungTuyen = ungTuyenDTO.ToEntity();
            await _ungTuyenService.UpdateUngTuyen(ungTuyen);
            return Ok(ungTuyen);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUngTuyen(int id)
        {
            await _ungTuyenService.DeleteUngTuyen(id);
            return Ok();
        }
    }
}