#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Security/TOS.Web.Security/TOS.Web.Security.csproj", "Security/TOS.Web.Security/"]
RUN dotnet restore "Security/TOS.Web.Security/TOS.Web.Security.csproj"
COPY . .
WORKDIR "/src/Security/TOS.Web.Security"
RUN dotnet build "TOS.Web.Security.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TOS.Web.Security.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TOS.Web.Security.dll"]