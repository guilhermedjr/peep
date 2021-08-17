#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Peep.Parrot.Application/Peep.Parrot.Application.csproj", "Peep.Parrot.Application/"]
COPY ["Peep.Parrot.Domain/Peep.Parrot.Domain.csproj", "Peep.Parrot.Domain/"]
COPY ["Peep.Parrot.Repositories/Peep.Parrot.Repositories.csproj", "Peep.Parrot.Repositories/"]
COPY ["Peep.Parrot.Infrastructure.Data/Peep.Parrot.Infrastructure.Data.csproj", "Peep.Parrot.Infrastructure.Data/"]
RUN dotnet restore "Peep.Parrot.Application/Peep.Parrot.Application.csproj"
COPY . .
WORKDIR "/src/Peep.Parrot.Application"
RUN dotnet build "Peep.Parrot.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Peep.Parrot.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Peep.Parrot.Application.dll"]

RUN useradd -m peepwingsuser
USER peepwingsuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Peep.Parrot.Application.dll