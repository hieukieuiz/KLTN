using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class NhomKyNangController: BaseApiController
    {
        private readonly INhomKyNangService _nhomKyNangService;

        public NhomKyNangController(INhomKyNangService nhomKyNangService)
        {
            _nhomKyNangService = nhomKyNangService;
        }

        [ProducesResponseType(typeof(PagedResult<NhomKyNangDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetNhomKyNang([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _nhomKyNangService.GetNhomKyNang(keywords);
            var nhomKyNang = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = nhomKyNang.TotalCount;
            var result = new PagedResult<NhomKyNangDTO>(pagination, nhomKyNang.Select(NhomKyNangDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(NhomKyNangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhomKyNangById(int id)
        {
            var nhomKyNang = await _nhomKyNangService.GetNhomKyNangById(id);
            var result = NhomKyNangDTO.FromEntity(nhomKyNang);
            return Ok(result);
        }

        [ProducesResponseType(typeof(NhomKyNangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateNhomKyNang(NhomKyNangDTO nhomKyNangDTO)
        {
            var nhomKyNang = nhomKyNangDTO.ToEntity();
            await _nhomKyNangService.CreateNhomKyNang(nhomKyNang);
            return Ok(nhomKyNang);
        }

        [ProducesResponseType(typeof(NhomKyNangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhomKyNang(int id, [FromBody]NhomKyNangDTO nhomKyNangDTO)
        {
            var nhomKyNang = nhomKyNangDTO.ToEntity();
            await _nhomKyNangService.UpdateNhomKyNang(nhomKyNang);
            return Ok(nhomKyNang);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhomKyNang(int id)
        {
            await _nhomKyNangService.DeleteNhomKyNang(id);
            return Ok();
        }
    }
}