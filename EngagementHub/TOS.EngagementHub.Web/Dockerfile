#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EngagementHub/TOS.EngagementHub.Web/TOS.EngagementHub.Web.csproj", "EngagementHub/TOS.EngagementHub.Web/"]
RUN dotnet restore "EngagementHub/TOS.EngagementHub.Web/TOS.EngagementHub.Web.csproj"
COPY . .
WORKDIR "/src/EngagementHub/TOS.EngagementHub.Web"
RUN dotnet build "TOS.EngagementHub.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TOS.EngagementHub.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TOS.EngagementHub.Web.dll"]