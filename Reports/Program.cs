using Microsoft.Data.SqlClient;
using Reports.Application.Interfaces;
using Reports.Application.Services;
using Reports.Infrastructure.Repositories.MSSql;
using Reports.Presentation.ReportsToExcel;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IDbConnection>((provider) => new SqlConnection(builder.Configuration.GetConnectionString("DataDB"))); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGetData, MSSqlRepository>();
builder.Services.AddScoped<ReportsService>();
builder.Services.AddScoped<ExportingReportsToExcel>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();
