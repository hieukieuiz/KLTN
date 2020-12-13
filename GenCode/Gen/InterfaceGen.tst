${
    using Typewriter.Extensions.WebApi;
    Template(Settings settings)
    {
        settings
            .IncludeProject("CMS.Core");
        
        settings.OutputExtension = ".cs";

        settings.OutputFilenameFactory = file => 
        {
            return $"outputInterfaces/I{file.Name.Replace(".cs", "") + "Service.cs"}";
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
    string NameById(Class c)
    {
        return $"{c.Name}ById";
    }
}$Classes(:BaseEntity)[using CMS.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Core.Interfaces.Services
{
    public interface $IServiceName
    {
        public IQueryable<$Name> Get$Name(string keywords);
        public Task<$Name> Get$NameById(int id);
        public Task Create$Name($Name $name);
        public Task Update$Name($Name $name);
        public Task Delete$Name(int id);
    }
}]