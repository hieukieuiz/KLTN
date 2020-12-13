using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class BaiTestTuyenDungController: BaseApiController
    {
        private readonly IBaiTestTuyenDungService _baiTestTuyenDungService;

        public BaiTestTuyenDungController(IBaiTestTuyenDungService baiTestTuyenDungService)
        {
            _baiTestTuyenDungService = baiTestTuyenDungService;
        }

        [ProducesResponseType(typeof(PagedResult<BaiTestTuyenDungDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetBaiTestTuyenDung([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _baiTestTuyenDungService.GetBaiTestTuyenDung(keywords);
            var baiTestTuyenDung = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = baiTestTuyenDung.TotalCount;
            var result = new PagedResult<BaiTestTuyenDungDTO>(pagination, baiTestTuyenDung.Select(BaiTestTuyenDungDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaiTestTuyenDungDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaiTestTuyenDungById(int id)
        {
            var baiTestTuyenDung = await _baiTestTuyenDungService.GetBaiTestTuyenDungById(id);
            var result = BaiTestTuyenDungDTO.FromEntity(baiTestTuyenDung);
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaiTestTuyenDungDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateBaiTestTuyenDung(BaiTestTuyenDungDTO baiTestTuyenDungDTO)
        {
            var baiTestTuyenDung = baiTestTuyenDungDTO.ToEntity();
            await _baiTestTuyenDungService.CreateBaiTestTuyenDung(baiTestTuyenDung);
            return Ok(baiTestTuyenDung);
        }

        [ProducesResponseType(typeof(BaiTestTuyenDungDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBaiTestTuyenDung(int id, [FromBody]BaiTestTuyenDungDTO baiTestTuyenDungDTO)
        {
            var baiTestTuyenDung = baiTestTuyenDungDTO.ToEntity();
            await _baiTestTuyenDungService.UpdateBaiTestTuyenDung(baiTestTuyenDung);
            return Ok(baiTestTuyenDung);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiTestTuyenDung(int id)
        {
            await _baiTestTuyenDungService.DeleteBaiTestTuyenDung(id);
            return Ok();
        }
    }
}