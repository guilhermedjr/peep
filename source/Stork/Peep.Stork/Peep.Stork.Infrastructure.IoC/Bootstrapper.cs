using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Peep.Stork.Infrastructure.Data;
using Peep.Stork.Domain.Hub;
using Peep.Stork.Hubs;

namespace Peep.Stork.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("postgres")));

            services.AddSingleton<IDirectMessagesHub>(new DirectMessagesHub());
        }
    }
}
