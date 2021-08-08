using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Peep.Wings.Domain.Services;
using Peep.Wings.Infrastructure.Data;
using Peep.Wings.Service.Services;

namespace Peep.Wings.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("postgres")));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

        public static IServiceCollection ConfigureExternalLoginProviders(this IServiceCollection services, 
            IConfiguration configuration)
        {

            if (configuration["Authentication:Google:ClientId"] != null)
            {
                services.AddAuthentication().AddGoogle(o =>
                {
                    o.ClientId = configuration["Authentication:Google:ClientId"];
                    o.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
            }

            if (configuration["Authentication:GitHub:ClientId"] != null)
            {
                services.AddAuthentication().AddGitHub(gitHubOptions =>
                {
                    gitHubOptions.ClientId = configuration["Authentication:GitHub:ClientId"];
                    gitHubOptions.ClientSecret = configuration["Authentication:GitHub:ClientSecret"];
                });
            }

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
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
