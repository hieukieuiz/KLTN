${
    using Typewriter.Extensions.WebApi;
    Template(Settings settings)
    {
        settings
            .IncludeProject("CMS.Core");
        
        settings.OutputExtension = ".cs";

        settings.OutputFilenameFactory = file => 
        {
            return $"outputAPIs/{file.Name.Replace(".cs", "") + "Controller.cs"}";
        };
    }
    string ApiName(Class c)
    {
        return c.Name + "Controller";
    }
    string IServiceName(Class c)
    {
        return $"I{c.Name}Service";
    }
    string serviceName(Class c)
    {
        return $"{c.name}Service";
    }
    string NameDTO(Class c)
    {
        return $"{c.Name}DTO";
    }
    string NameById(Class c)
    {
        return $"{c.Name}ById";
    }
    string nameDTO(Class c)
    {
        return $"{c.name}DTO";
    }
}$Classes(:BaseEntity)[using CMS.Core.Interfaces.Services;
using CMS.Infrastructure;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class $ApiName: BaseApiController
    {
        private readonly $IServiceName _$serviceName;

        public $ApiName($IServiceName $serviceName)
        {
            _$serviceName = $serviceName;
        }

        [ProducesResponseType(typeof(PagedResult<$NameDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get$Name([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _$serviceName.Get$Name(keywords);
            var $name = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = $name.TotalCount;
            var result = new PagedResult<$NameDTO>(pagination, $name.Select($NameDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof($NameDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get$NameById(int id)
        {
            var $name = await _$serviceName.Get$NameById(id);
            var result = $NameDTO.FromEntity($name);
            return Ok(result);
        }

        [ProducesResponseType(typeof($NameDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create$Name($NameDTO $nameDTO)
        {
            var $name = $nameDTO.ToEntity();
            await _$serviceName.Create$Name($name);
            return Ok($name);
        }

        [ProducesResponseType(typeof($NameDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update$Name(int id, [FromBody]$NameDTO $nameDTO)
        {
            var $name = $nameDTO.ToEntity();
            await _$serviceName.Update$Name($name);
            return Ok($name);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete$Name(int id)
        {
            await _$serviceName.Delete$Name(id);
            return Ok();
        }
    }
}]