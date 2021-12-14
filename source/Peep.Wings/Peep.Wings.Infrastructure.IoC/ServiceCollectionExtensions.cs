﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using Peep.Wings.Domain.Services;
using Peep.Wings.Domain.Dtos;
using Peep.Wings.Infrastructure.Data;
using Peep.Wings.Service.Services;

namespace Peep.Wings.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlServer")));

        services.AddScoped<IOAuthService<GoogleUserInfoDto>, GoogleService>();

        services.AddSingleton<CosmosDbConnection>(InitializeCosmosClientInstanceAsync(
            configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());

        return services;
    }

    public static void ConfigureIdentity(IdentityOptions options)
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 0;

        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedEmail = true;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedAccount = true;
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

