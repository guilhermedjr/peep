#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Peep.Wings.Application/Peep.Wings.Application.csproj", "Peep.Wings.Application/"]
COPY ["Peep.Wings.Service/Peep.Wings.Service.csproj", "Peep.Wings.Service/"]
COPY ["Peep.Wings.Domain/Peep.Wings.Domain.csproj", "Peep.Wings.Domain/"]
COPY ["Peep.Wings.Infrastructure.Data/Peep.Wings.Infrastructure.Data.csproj", "Peep.Wings.Infrastructure.Data/"]
COPY ["Peep.Wings.Infrastructure.IoC/Peep.Wings.Infrastructure.IoC.csproj", "Peep.Wings.Infrastructure.IoC/"]
RUN dotnet restore "Peep.Wings.Application/Peep.Wings.Application.csproj"
COPY . .
WORKDIR "/src/Peep.Wings.Application"
RUN dotnet build "Peep.Wings.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Peep.Wings.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Peep.Wings.Application.dll"]

RUN useradd -m peepwingsuser
USER peepwingsuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Peep.Wings.Application.dll