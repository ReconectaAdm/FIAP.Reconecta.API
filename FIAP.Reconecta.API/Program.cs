using FIAP.Reconecta.Application.Middlewares;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using FIAP.Reconecta.Infrastructure.IoC;
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
