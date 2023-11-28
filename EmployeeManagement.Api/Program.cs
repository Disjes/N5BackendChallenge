using System.Reflection;
using EmployeeManagement.Data.Extensions;
using EmployeeManagement.Services.Configs;
using EmployeeManagement.Services.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeManagement", Version = "v1" });
});

builder.Services.AddHttpClient();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddOptions();

builder.Services.Configure<ElasticOptions>(options => builder.Configuration.GetSection("ElasticSearch").Bind(options));
builder.Services.Configure<KafkaOptions>(options => builder.Configuration.GetSection("Kafka").Bind(options));

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddServicesServices();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Host.UseSerilog();
builder.Logging.AddSerilog(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Management V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();