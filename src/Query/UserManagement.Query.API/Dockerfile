FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Query/UserManagement.Query.API/UserManagement.Query.API.csproj", "UserManagement.Query.API/"]
RUN dotnet restore "src/Query/UserManagement.Query.API/UserManagement.Query.API.csproj"
COPY . .
WORKDIR "/src/UserManagement.Query.API"
RUN dotnet build "UserManagement.Query.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagement.Query.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.Query.API.dll"]
