using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Peep.Parrot.GraphQL.Schemas;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Domain.Entities;
using Peep.Parrot.Domain.Handler;
using Peep.Parrot.Handlers;
using Peep.Parrot.Infrastructure.Data;
using Peep.Parrot.Repositories;

namespace Peep.Parrot.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                                        "http://localhost:44364",
                                        "http://localhost:44327",
                                        "https://peep.vercel.app")
                            .AllowAnyHeader().AllowAnyMethod();
                });
        });

        return services;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
                .AddJsonOptions(options => options.UseDateOnlyTimeOnlyStringConverters());

        services.AddMvc()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Peep.Wings.Application", Version = "v1" });
            c.UseDateOnlyTimeOnlyStringConverters();

        });

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlServer")));

        services.AddSingleton<ISchema, UsersSchema>(services => new UsersSchema(
            new SelfActivatingServiceProvider(services)
            ));

        services.AddSingleton<ISchema, PeepsSchema>(services => new PeepsSchema(
           new SelfActivatingServiceProvider(services)
           ));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IPeepsRepository, PeepsRepository>();
        services.AddScoped<ISearchRepository<ApplicationUser>, UsersSearchRepository>();

        services.AddScoped<ISearchHandler, SearchHandler>();

        services.AddSingleton<CosmosDbConnection>(InitializeCosmosClientInstanceAsync(
            configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());

        services.AddSignalR();

        return services;
    }

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
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
