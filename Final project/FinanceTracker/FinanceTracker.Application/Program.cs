using FinanceTracker.Data.Context;
using FinanceTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FinanceTrackerContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FinanceTrackerConnection")));

var app = builder.Build();

//Transaction transaction = new Transaction()
//{
//    Id = Guid.NewGuid(),
//    Name = null,
//    Description = "test",
//    Sum = new decimal(-120.0)
//};

//Console.WriteLine(transaction);
//Console.ReadLine();

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
