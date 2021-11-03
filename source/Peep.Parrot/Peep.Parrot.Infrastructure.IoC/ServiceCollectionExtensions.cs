using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Infrastructure.Data;
using Peep.Parrot.Repositories;

namespace Peep.Parrot.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("postgres")));

        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IUsersConnectionsRepository, UsersConnectionsRepository>();
        services.AddScoped<IUserRestrictionsRepository, UserRestrictionsRepository>();
        services.AddScoped<IPeepsRepository, PeepsRepository>();
        services.AddScoped<INestsRepository, NestsRepository>();

        services.AddSingleton<RedisDbConnection>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("redis");
        });

        services.AddSignalR();

        return services;
    }
}
