using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Peep.Parrot.Repositories;
using Peep.Parrot.Infrastructure.Data;
using Peep.Parrot.Application.Consumers;

namespace Peep.Parrot.Application;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("https://peep.vercel.app")
                            .AllowAnyHeader().AllowAnyMethod();
                });
        });

        services.AddSingleton<RedisDbConnection>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = Configuration.GetConnectionString("redis");
        });

        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IUsersConnectionsRepository, UsersConnectionsRepository>();
        services.AddScoped<IUserRestrictionsRepository, UserRestrictionsRepository>();
        services.AddScoped<IPeepsRepository, PeepsRepository>();
        services.AddScoped<INestsRepository, NestsRepository>();

        services.AddControllers();

        services.AddSignalR();

        services.AddHostedService<MessageConsumptionService>();

        services.AddSingleton<MessageConsumptionService>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Peep Parrot ", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsProduction())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peep.Parrot.Application v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

