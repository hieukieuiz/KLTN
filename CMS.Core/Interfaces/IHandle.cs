using CMS.Core.SharedKernel;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}