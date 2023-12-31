using FIAP.Reconecta.API.IoC;
using FIAP.Reconecta.API.Middlewares;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString, x => x.UseNetTopologySuite()).EnableSensitiveDataLogging(true));

builder.Services
    .AddRepositories()
    .AddServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddJWTAuthentication()
    .AddRouting(options => options.LowercaseUrls = true)
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

//prevent to put try catch in Controllers
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
