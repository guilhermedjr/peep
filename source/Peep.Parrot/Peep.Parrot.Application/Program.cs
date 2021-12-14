using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Peep.Parrot.Infrastructure.IoC;

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

builder.Services.ConfigureServices(builder.Configuration)
    .ConfigureAuthentication(builder.Configuration);

builder.Services.AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
                .AddJsonOptions(options => options.UseDateOnlyTimeOnlyStringConverters());

/*builder.Services
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });*/

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
   ContractResolver = new CamelCasePropertyNamesContractResolver()
};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Peep.Wings.Application", Version = "v1" });
    c.UseDateOnlyTimeOnlyStringConverters();

});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peep.Parrot.Application v1"));
}

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


