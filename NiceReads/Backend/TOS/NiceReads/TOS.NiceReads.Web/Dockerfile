#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NiceReads/TOS.NiceReads.Web/TOS.NiceReads.Web.csproj", "NiceReads/TOS.NiceReads.Web/"]
COPY ["NiceReads/TOS.NiceReads.Application/TOS.NiceReads.Application.csproj", "NiceReads/TOS.NiceReads.Application/"]
COPY ["NiceReads/TOS.NiceReads.Data/TOS.NiceReads.Data.csproj", "NiceReads/TOS.NiceReads.Data/"]
COPY ["TOS.Data.MongoDB/TOS.Data.MongoDB.csproj", "TOS.Data.MongoDB/"]
COPY ["TOS.Common.Text.Semantics/TOS.Common.Text.Semantics.csproj", "TOS.Common.Text.Semantics/"]
COPY ["TOS.Data/TOS.Data.csproj", "TOS.Data/"]
COPY ["TOS.Common.MongoDB/TOS.Common.MongoDB.csproj", "TOS.Common.MongoDB/"]
COPY ["TOS.Common/TOS.Common.csproj", "TOS.Common/"]
COPY ["NiceReads/TOS.NiceReads.Models/TOS.NiceReads.Models.csproj", "NiceReads/TOS.NiceReads.Models/"]
COPY ["TOS.CQRS/TOS.CQRS.csproj", "TOS.CQRS/"]
COPY ["TOS.Extensions.Logging/TOS.Extensions.Logging.csproj", "TOS.Extensions.Logging/"]
COPY ["NiceReads/TOS.NiceReads.Configuration/TOS.NiceReads.Configuration.csproj", "NiceReads/TOS.NiceReads.Configuration/"]
COPY ["TOS.Common.Configuration/TOS.Common.Configuration.csproj", "TOS.Common.Configuration/"]
RUN dotnet restore "NiceReads/TOS.NiceReads.Web/TOS.NiceReads.Web.csproj"
COPY . .
WORKDIR "/src/NiceReads/TOS.NiceReads.Web"
RUN dotnet build "TOS.NiceReads.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TOS.NiceReads.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TOS.NiceReads.Web.dll"]
