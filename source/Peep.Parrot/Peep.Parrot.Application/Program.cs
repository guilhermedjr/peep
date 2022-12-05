using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using GraphQL.Types;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using Peep.Parrot.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureIoC(builder.Configuration)
    .AddGraphQL().AddSystemTextJson();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseGraphQLAltair();
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

app.UseGraphQL<ISchema>();

app.Run();


