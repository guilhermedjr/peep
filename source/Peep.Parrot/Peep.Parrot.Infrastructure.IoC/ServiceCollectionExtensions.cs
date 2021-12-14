using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Infrastructure.Data;
using Peep.Parrot.Repositories;

namespace Peep.Parrot.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlServer")));

        /*services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IUsersConnectionsRepository, UsersConnectionsRepository>();
        services.AddScoped<IUserRestrictionsRepository, UserRestrictionsRepository>();*/
        services.AddScoped<IPeepsRepository, PeepsRepository>();
        /*services.AddScoped<INestsRepository, NestsRepository>();*/

        services.AddSingleton<CosmosDbConnection>(InitializeCosmosClientInstanceAsync(
            configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());

        services.AddSignalR();

        return services;
    }

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.Authority = "https://securetoken.google.com/peep-61ac0";
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/peep-61ac0",
                ValidateAudience = true,
                ValidAudience = "peep-61ac0",
                ValidateLifetime = true,
            };
        });

        return services;
    }

    /// <summary>
    /// Creates a Cosmos DB database and a container with the specified partition key. 
    /// </summary>
    /// <returns></returns>
    private static async Task<CosmosDbConnection> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
    {
        string databaseName = configurationSection.GetSection("DatabaseName").Value;
        string containerName = configurationSection.GetSection("ContainerName").Value;
        string account = configurationSection.GetSection("Account").Value;
        string key = configurationSection.GetSection("Key").Value;

        CosmosClientOptions clientOptions = new()
        {
            SerializerOptions = new CosmosSerializationOptions
            { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase }
        };

        CosmosClient client = new(account, key, clientOptions);
        CosmosDbConnection cosmosDbService = new(client, databaseName, containerName);

        DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

        return cosmosDbService;
    }
}
