FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Command/UserManagement.Command.API/UserManagement.Command.API.csproj", "UserManagement.Command.API/"]
RUN dotnet restore "src/Command/UserManagement.Command.API/UserManagement.Command.API.csproj"
COPY . .
WORKDIR "/src/UserManagement.Command.API"
RUN dotnet build "UserManagement.Command.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagement.Command.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.Command.API.dll"]
