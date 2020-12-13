using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class QuyenController: BaseApiController
    {
        private readonly IQuyenService _quyenService;

        public QuyenController(IQuyenService quyenService)
        {
            _quyenService = quyenService;
        }

        [ProducesResponseType(typeof(PagedResult<QuyenDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetQuyen([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _quyenService.GetQuyen(keywords);
            var quyen = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = quyen.TotalCount;
            var result = new PagedResult<QuyenDTO>(pagination, quyen.Select(QuyenDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuyenById(int id)
        {
            var quyen = await _quyenService.GetQuyenById(id);
            var result = QuyenDTO.FromEntity(quyen);
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateQuyen(QuyenDTO quyenDTO)
        {
            var quyen = quyenDTO.ToEntity();
            await _quyenService.CreateQuyen(quyen);
            return Ok(quyen);
        }

        [ProducesResponseType(typeof(QuyenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuyen(int id, [FromBody]QuyenDTO quyenDTO)
        {
            var quyen = quyenDTO.ToEntity();
            await _quyenService.UpdateQuyen(quyen);
            return Ok(quyen);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuyen(int id)
        {
            await _quyenService.DeleteQuyen(id);
            return Ok();
        }
    }
}