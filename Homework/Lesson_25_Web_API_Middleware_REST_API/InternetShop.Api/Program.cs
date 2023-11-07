using Asp.Versioning;
using InternetShop.Api.Middleware;
using InternetShop.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCore(builder.Configuration);
builder.Services.AddCoreLogger();
builder.Services.AddApiVersioning(x =>
{
    x.ApiVersionReader = new UrlSegmentApiVersionReader();
    x.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerModify();

app.UseMiddleware<GlobalHandlerMiddleware>();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
