using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class FileUploadController: BaseApiController
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [ProducesResponseType(typeof(PagedResult<FileUploadDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetFileUpload([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _fileUploadService.GetFileUpload(keywords);
            var fileUpload = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = fileUpload.TotalCount;
            var result = new PagedResult<FileUploadDTO>(pagination, fileUpload.Select(FileUploadDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(FileUploadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileUploadById(int id)
        {
            var fileUpload = await _fileUploadService.GetFileUploadById(id);
            var result = FileUploadDTO.FromEntity(fileUpload);
            return Ok(result);
        }

        [ProducesResponseType(typeof(FileUploadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateFileUpload(FileUploadDTO fileUploadDTO)
        {
            var fileUpload = fileUploadDTO.ToEntity();
            await _fileUploadService.CreateFileUpload(fileUpload);
            return Ok(fileUpload);
        }

        [ProducesResponseType(typeof(FileUploadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFileUpload(int id, [FromBody]FileUploadDTO fileUploadDTO)
        {
            var fileUpload = fileUploadDTO.ToEntity();
            await _fileUploadService.UpdateFileUpload(fileUpload);
            return Ok(fileUpload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileUpload(int id)
        {
            await _fileUploadService.DeleteFileUpload(id);
            return Ok();
        }
    }
}