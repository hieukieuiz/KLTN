using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class UngVienLamBaiTestController: BaseApiController
    {
        private readonly IUngVienLamBaiTestService _ungVienLamBaiTestService;

        public UngVienLamBaiTestController(IUngVienLamBaiTestService ungVienLamBaiTestService)
        {
            _ungVienLamBaiTestService = ungVienLamBaiTestService;
        }

        [ProducesResponseType(typeof(PagedResult<UngVienLamBaiTestDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetUngVienLamBaiTest([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _ungVienLamBaiTestService.GetUngVienLamBaiTest(keywords);
            var ungVienLamBaiTest = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = ungVienLamBaiTest.TotalCount;
            var result = new PagedResult<UngVienLamBaiTestDTO>(pagination, ungVienLamBaiTest.Select(UngVienLamBaiTestDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngVienLamBaiTestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUngVienLamBaiTestById(int id)
        {
            var ungVienLamBaiTest = await _ungVienLamBaiTestService.GetUngVienLamBaiTestById(id);
            var result = UngVienLamBaiTestDTO.FromEntity(ungVienLamBaiTest);
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngVienLamBaiTestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateUngVienLamBaiTest(UngVienLamBaiTestDTO ungVienLamBaiTestDTO)
        {
            var ungVienLamBaiTest = ungVienLamBaiTestDTO.ToEntity();
            await _ungVienLamBaiTestService.CreateUngVienLamBaiTest(ungVienLamBaiTest);
            return Ok(ungVienLamBaiTest);
        }

        [ProducesResponseType(typeof(UngVienLamBaiTestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUngVienLamBaiTest(int id, [FromBody]UngVienLamBaiTestDTO ungVienLamBaiTestDTO)
        {
            var ungVienLamBaiTest = ungVienLamBaiTestDTO.ToEntity();
            await _ungVienLamBaiTestService.UpdateUngVienLamBaiTest(ungVienLamBaiTest);
            return Ok(ungVienLamBaiTest);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUngVienLamBaiTest(int id)
        {
            await _ungVienLamBaiTestService.DeleteUngVienLamBaiTest(id);
            return Ok();
        }
    }
}