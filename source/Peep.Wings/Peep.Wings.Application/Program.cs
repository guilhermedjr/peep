using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Ocelot.DependencyInjection;
using Peep.Wings.Infrastructure.Data;
using Peep.Wings.Infrastructure.IoC;
using Peep.Wings.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
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

builder.Services.AddControllers();

builder.Services.AddMvc()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Peep.Wings.Application", Version = "v1" });
});

builder.Services
    .AddDefaultIdentity<ApplicationUser>(Peep.Wings.Infrastructure.IoC.ServiceCollectionExtensions.ConfigureIdentity)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureServices(builder.Configuration)
    .ConfigureAuthentication(builder.Configuration);

builder.Services.AddHttpClient<PeepParrotService>();
builder.Services.AddHttpClient<PeepStorkService>();
builder.Services.AddHttpClient<GoogleService>();

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peep.Wings.Application v1"));
}

//await app.UseOcelot();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
