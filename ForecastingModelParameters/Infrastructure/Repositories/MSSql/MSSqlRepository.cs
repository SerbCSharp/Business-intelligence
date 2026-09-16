using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData, IGetDataRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<List<ProjectCostingData>> ProjectCostingDataAsync(string complexProperty)
        {
            return await _dataContext.ProjectCostingDatas.Include(x => x.ProjectCostingDataPeriods)
                .Where(y => y.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<ProjectForecast>> ProjectForecastAsync(string complexProperty)
        {
            //var newProjectForecast = new ProjectForecast
            //{
            //    Amount = 1734040000,
            //    ComplexProperty = new ComplexProperty { Name = "ЖК КИПАРИС" },
            //    CostItem = new CostItem { Name = "СМР", FlowDirection = false },
            //    Date = new Date { Year = 2026, Quarter = 2 },
            //    Property = new Property { Id = 1, Name = "Позиция 6" },
            //    LoanTerm = new LoanTerm { Name = "Проектное финансирование Сбербанк" }
            //};

            //_dataContext.FactProjectForecasts.Add(newProjectForecast);
            //_dataContext.SaveChanges();

            //return await _dataContext.FactProjectForecasts
            //    .Include(x => x.Date)
            //    .Include(x => x.ComplexProperty)
            //    .Include(x => x.CostItem)
            //    .Include(x => x.Property)
            //    .Include(x => x.LoanTerm)
            //    .Where(y => y.ComplexProperty.Name == complexProperty).ToListAsync();
            return null;
        }

        public async Task<List<ReportField>> ReportFieldAsync()
        {
            return await _dataContext.ReportFields.ToListAsync();
        }

        public async Task SaveProjectCostingDataAsync(IEnumerable<ProjectCostingData> projectCostingDatas, string complexProperty)
        {
            await _dataContext.ProjectCostingDatas.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.ProjectCostingDatas.AddRangeAsync(projectCostingDatas);
            await _dataContext.SaveChangesAsync();
        }
    }
}
