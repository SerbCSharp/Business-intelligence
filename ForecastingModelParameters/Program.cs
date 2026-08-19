using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Application.Services;
using ForecastingModelParameters.Infrastructure.Repositories;
using ForecastingModelParameters.Infrastructure.Repositories.MSSql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataDB")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISaveData, MSSqlRepository>();
builder.Services.AddScoped<UpdateDataService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
