using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Services
{
    public class UpdateDataService(IGetDataRepository getDataRepository, IGetDataSource getDataSource, ISaveData saveData)
    {
        private readonly IGetDataRepository _getDataRepository = getDataRepository;
        private readonly IGetDataSource _getDataSource = getDataSource;
        private readonly ISaveData _saveData = saveData;

        public async Task<List<ProjectCostingData>> ProjectCostingDataAsync(string complexProperty, int property, int category, int period)
        {
            var projectCostingData = await _getDataRepository.ProjectCostingDataAsync(complexProperty);
            if (projectCostingData.Count == 0)
            {
                projectCostingData.AddRange(Enumerable.Range(1, property).Select(index => new ProjectCostingData
                {
                    ComplexProperty = complexProperty,
                    Name = $"Позиция №{index}",
                    Field = $"Property{index}",
                    ProjectCostingDataPeriods = [.. Enumerable.Range(1, period).Select(i => new ProjectCostingDataPeriod
                    {
                        Year = DateTime.Now.AddMonths(i * 3).Year,
                        Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1
                    })]
                }));

                projectCostingData.AddRange(Enumerable.Range(1, category).Select(index => new ProjectCostingData
                {
                    ComplexProperty = complexProperty,
                    Name = $"Категория №{index}",
                    Field = $"Category{index}",
                    ProjectCostingDataPeriods = [.. Enumerable.Range(1, period).Select(i => new ProjectCostingDataPeriod
                    {
                        Year = DateTime.Now.AddMonths(i * 3).Year,
                        Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1
                    })]
                }));

                var reportFields = await _getDataRepository.ReportFieldAsync();
                var filteredSequence = reportFields.Where(x => x.Parameter).OrderBy(y => y.ReportSheet).ThenBy(s => s.LineNumber);
                foreach (var item in filteredSequence)
                {
                    projectCostingData.Add(new ProjectCostingData
                    {
                        ComplexProperty = complexProperty,
                        Name = item.Name,
                        Field = item.Field,
                        ProjectCostingDataPeriods = [.. Enumerable.Range(1, period).Select(i => new ProjectCostingDataPeriod
                        {
                            Year = DateTime.Now.AddMonths(i * 3).Year,
                            Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1
                        })]
                    });
                }
            }

            return projectCostingData;
        }

        public async Task SaveProjectCostingDataAsync(string complexProperty)
        {
        }
    }
}
