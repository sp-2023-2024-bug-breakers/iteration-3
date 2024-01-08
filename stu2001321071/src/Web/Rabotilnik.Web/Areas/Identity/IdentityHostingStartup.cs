using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Rabotilnik.Web.Areas.Identity.IdentityHostingStartup))]

namespace Rabotilnik.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
