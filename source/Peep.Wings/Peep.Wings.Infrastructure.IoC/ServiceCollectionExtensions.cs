using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
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
        services.AddScoped<IPeepParrotService, PeepParrotService>();
        services.AddScoped<IPeepStorkService, PeepStorkService>();

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
}

