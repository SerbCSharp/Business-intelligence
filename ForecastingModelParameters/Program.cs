using ForecastingModelParameters.Application;
using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Application.Services;
using ForecastingModelParameters.Infrastructure.DataSource.Excel;
using ForecastingModelParameters.Infrastructure.Repositories;
using ForecastingModelParameters.Infrastructure.Repositories.MSSql;
using ForecastingModelParameters.Presentation.ReportsToExcel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataDB")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(); 
builder.Services.Configure<FilePathConfiguration>(builder.Configuration.GetSection(FilePathConfiguration.Section));
builder.Services.AddScoped<ISaveData, MSSqlRepository>();
builder.Services.AddScoped<IGetDataRepository, MSSqlRepository>();
builder.Services.AddScoped<IGetDataSource, GetDataExcel>();
builder.Services.AddScoped<UpdateDataService>();
builder.Services.AddScoped<ExportingReportsToExcel>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
