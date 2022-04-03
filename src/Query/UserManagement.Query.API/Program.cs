using UserManager.Query.Application;
using UserManager.Query.Application.Configuration;
using UserManager.Query.Infrastructure;
using UserManager.Query.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection("RabbitMQConfig"));
builder.Services.Configure<RedisConfiguration>(builder.Configuration.GetSection("RedisConfig"));
builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("MongoDbConfig"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var rabbitMqConfig = builder.Configuration.GetSection("RabbitMQConfig").Get<RabbitMQConfiguration>();

//Registering services into container
builder.Services.RegisterPersistenceServices();
builder.Services.RegisterInfrastructureServices(rabbitMqConfig);
builder.Services.RegisterApplicationServices();

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