${
    using Typewriter.Extensions.WebApi;
    Template(Settings settings)
    {
        settings
            .IncludeProject("CMS.Core");
        
        settings.OutputExtension = ".cs";

        settings.OutputFilenameFactory = file => 
        {
            return $"outputServices/{file.Name.Replace(".cs", "") + "Service.cs"}";
        };
    }
    string IServiceName(Class c)
    {
        return $"I{c.Name}Service";
    }
    string serviceName(Class c)
    {
        return $"{c.name}Service";
    }
    string ServiceName(Class c)
    {
        return $"{c.Name}Service";
    }
    string NameById(Class c)
    {
        return $"{c.Name}ById";
    }
    string nameRepository(Class c)
    {
        return $"{c.name}Repository";
    }
}$Classes(:BaseEntity)[using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
namespace CMS.Core.Services
{
    public class $ServiceName: $IServiceName
    {
        private readonly IRepository<$Name> _$nameRepository;
        public $ServiceName(IRepository<$Name> $nameRepository)
        {
            _$nameRepository = $nameRepository;
        }
        public IQueryable<$Name> Get$Name(string keywords)
        {
            var query = _$nameRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where($name =>
                        $name.Ten$Name.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<$Name> Get$NameById(int id)
        {
            return await _$nameRepository.GetByIdAsync(id);
        }
        public async Task Create$Name($Name $name)
        {
            await _$nameRepository.AddAsync($name);
        }
        public async Task Update$Name($Name $name)
        {
            await _$nameRepository.UpdateAsync($name);
        }
        public async Task Delete$Name(int id)
        {
            var $name = await _$nameRepository.GetByIdAsync(id);
            await _$nameRepository.DeleteAsync($name);
        }
    }
}]