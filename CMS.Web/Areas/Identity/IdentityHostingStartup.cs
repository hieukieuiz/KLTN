using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CMS.Web.Areas.Identity.IdentityHostingStartup))]
namespace CMS.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}