using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagement.Command.API.ConfigurationModel;
using UserManagement.Command.API.Controllers;
using UserManagement.Command.Application;
using UserManagement.Command.Application.Cache;
using UserManagement.Command.Infrastructure;
using UserManagement.Command.Infrastructure.Cache;
using UserManagement.Command.Persistence;
using UserManagement.Command.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<Program>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommandAppContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreCommandDb")));

builder.Services.Configure<RedisConfiguration>(builder.Configuration.GetSection("RedisConfig"));
builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection("RabbitMQConfig"));

var rabbitMqConfig = builder.Configuration.GetSection("RabbitMQConfig").Get<RabbitMQConfiguration>();

builder.Services.RegisterPersistenceServices();
builder.Services.RegisterInfrastructureServices(rabbitMqConfig);
builder.Services.RegisterApplicationServices();

var apiAssembly = typeof(UsersController).Assembly;
var applicationAssembly = typeof(ICacheManager).Assembly;
var infrastructureAssembly = typeof(RedisCache).Assembly;

List<Assembly> assemblies = new() { apiAssembly, applicationAssembly, infrastructureAssembly };

builder.Services.AddMediatR(assemblies.ToArray());
builder.Services.AddAutoMapper(assemblies.ToArray());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();