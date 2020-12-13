using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class BaiTuyenDungController: BaseApiController
    {
        private readonly IBaiTuyenDungService _baiTuyenDungService;

        public BaiTuyenDungController(IBaiTuyenDungService baiTuyenDungService)
        {
            _baiTuyenDungService = baiTuyenDungService;
        }

        [ProducesResponseType(typeof(PagedResult<BaiTuyenDungDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetBaiTuyenDung([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _baiTuyenDungService.GetBaiTuyenDung(keywords);
            var baiTuyenDung = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = baiTuyenDung.TotalCount;
            var result = new PagedResult<BaiTuyenDungDTO>(pagination, baiTuyenDung.Select(BaiTuyenDungDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaiTuyenDungDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaiTuyenDungById(int id)
        {
            var baiTuyenDung = await _baiTuyenDungService.GetBaiTuyenDungById(id);
            var result = BaiTuyenDungDTO.FromEntity(baiTuyenDung);
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaiTuyenDungDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateBaiTuyenDung(BaiTuyenDungDTO baiTuyenDungDTO)
        {
            var baiTuyenDung = baiTuyenDungDTO.ToEntity();
            await _baiTuyenDungService.CreateBaiTuyenDung(baiTuyenDung);
            return Ok(baiTuyenDung);
        }

        [ProducesResponseType(typeof(BaiTuyenDungDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBaiTuyenDung(int id, [FromBody]BaiTuyenDungDTO baiTuyenDungDTO)
        {
            var baiTuyenDung = baiTuyenDungDTO.ToEntity();
            await _baiTuyenDungService.UpdateBaiTuyenDung(baiTuyenDung);
            return Ok(baiTuyenDung);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiTuyenDung(int id)
        {
            await _baiTuyenDungService.DeleteBaiTuyenDung(id);
            return Ok();
        }
    }
}