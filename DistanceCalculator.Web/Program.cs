using DistanceCalculator.Application.Strategies;
using DistanceCalculator.Application.Strategies.Contracts;
using DistanceCalculator.Application.Strategies.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDistanceCalculatorStrategy, DistanceCalculatorStrategy>();
builder.Services.AddScoped<IDistanceFormulaStrategy, LawofCosinesDistanceStrategy>();
builder.Services.AddScoped<IDistanceFormulaStrategy, PythagoreanDistanceStrategy>();

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
