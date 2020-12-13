using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class QuyenDuAnController: BaseApiController
    {
        private readonly IQuyenDuAnService _quyenDuAnService;

        public QuyenDuAnController(IQuyenDuAnService quyenDuAnService)
        {
            _quyenDuAnService = quyenDuAnService;
        }

        [ProducesResponseType(typeof(PagedResult<QuyenDuAnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetQuyenDuAn([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _quyenDuAnService.GetQuyenDuAn(keywords);
            var quyenDuAn = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = quyenDuAn.TotalCount;
            var result = new PagedResult<QuyenDuAnDTO>(pagination, quyenDuAn.Select(QuyenDuAnDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuyenDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuyenDuAnById(int id)
        {
            var quyenDuAn = await _quyenDuAnService.GetQuyenDuAnById(id);
            var result = QuyenDuAnDTO.FromEntity(quyenDuAn);
            return Ok(result);
        }

        [ProducesResponseType(typeof(QuyenDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateQuyenDuAn(QuyenDuAnDTO quyenDuAnDTO)
        {
            var quyenDuAn = quyenDuAnDTO.ToEntity();
            await _quyenDuAnService.CreateQuyenDuAn(quyenDuAn);
            return Ok(quyenDuAn);
        }

        [ProducesResponseType(typeof(QuyenDuAnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuyenDuAn(int id, [FromBody]QuyenDuAnDTO quyenDuAnDTO)
        {
            var quyenDuAn = quyenDuAnDTO.ToEntity();
            await _quyenDuAnService.UpdateQuyenDuAn(quyenDuAn);
            return Ok(quyenDuAn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuyenDuAn(int id)
        {
            await _quyenDuAnService.DeleteQuyenDuAn(id);
            return Ok();
        }
    }
}