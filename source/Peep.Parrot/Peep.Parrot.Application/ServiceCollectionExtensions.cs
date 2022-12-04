using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
namespace Peep.Parrot.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureCors().ConfigureAuthentication().ConfigureServices(configuration);
        return services;
    }

    private static IServiceCollection ConfigureCors(this IServiceCollection services)
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

    private static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
                .AddJsonOptions(options => options.UseDateOnlyTimeOnlyStringConverters());

        /*services.AddMvc()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });*/

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Peep.Wings.Application", Version = "v1" });
            c.UseDateOnlyTimeOnlyStringConverters();

        });

        /*services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlServer")));*/

        services.AddSignalR();

        return services;
    }

    private static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
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
}
