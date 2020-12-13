using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class BaiThiController: BaseApiController
    {
        private readonly IBaiThiService _baiThiService;

        public BaiThiController(IBaiThiService baiThiService)
        {
            _baiThiService = baiThiService;
        }

        [ProducesResponseType(typeof(PagedResult<BaiThiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetBaiThi([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _baiThiService.GetBaiThi(keywords);
            var baiThi = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = baiThi.TotalCount;
            var result = new PagedResult<BaiThiDTO>(pagination, baiThi.Select(BaiThiDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaiThiById(int id)
        {
            var baiThi = await _baiThiService.GetBaiThiById(id);
            var result = BaiThiDTO.FromEntity(baiThi);
            return Ok(result);
        }

        [ProducesResponseType(typeof(BaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateBaiThi(BaiThiDTO baiThiDTO)
        {
            var baiThi = baiThiDTO.ToEntity();
            await _baiThiService.CreateBaiThi(baiThi);
            return Ok(baiThi);
        }

        [ProducesResponseType(typeof(BaiThiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBaiThi(int id, [FromBody]BaiThiDTO baiThiDTO)
        {
            var baiThi = baiThiDTO.ToEntity();
            await _baiThiService.UpdateBaiThi(baiThi);
            return Ok(baiThi);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiThi(int id)
        {
            await _baiThiService.DeleteBaiThi(id);
            return Ok();
        }
    }
}