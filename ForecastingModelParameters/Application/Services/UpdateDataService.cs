using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Services
{
    public class UpdateDataService(IGetDataRepository getDataRepository, IGetDataSource getDataSource, ISaveData saveData)
    {
        private readonly IGetDataRepository _getDataRepository = getDataRepository;
        private readonly IGetDataSource _getDataSource = getDataSource;
        private readonly ISaveData _saveData = saveData;

        public async Task<IEnumerable<ConstructionCostByProperty>> RequestPropertyAsync(string complexProperty, int property)
        {
            var constructionCostByProperty = await _getDataRepository.GetConstructionCostByPropertyAsync(complexProperty);
            if (constructionCostByProperty.Count == 0)
                constructionCostByProperty.AddRange(Enumerable.Repeat(new ConstructionCostByProperty { ComplexProperty = complexProperty }, property));

            return constructionCostByProperty;
        }

        public async Task<IEnumerable<SalesValueByCategory>> RequestCategoriesAsync(string complexProperty, int category)
        {
            var salesValueByCategory = await _getDataRepository.GetSalesValueByCategoryAsync(complexProperty);
            if (salesValueByCategory.Count == 0)
                salesValueByCategory.AddRange(Enumerable.Repeat(new SalesValueByCategory { ComplexProperty = complexProperty }, category));

            return salesValueByCategory;
        }

        public async Task<IEnumerable<ConstructionCostByPeriod>> RequestByPeriodsConstructionAsync(string complexProperty, int period)
        {
            var getExcelConstructionCostByProperty = _getDataSource.GetConstructionCostByProperty(complexProperty);
            await _saveData.SaveConstructionCostByPropertyAsync(getExcelConstructionCostByProperty, complexProperty);

            var getDBConstructionCostByProperty = await _getDataRepository.GetConstructionCostByPropertyAsync(complexProperty);

            var constructionCostByPeriod = await _getDataRepository.GetConstructionCostByPeriodAsync(complexProperty);
            if (constructionCostByPeriod.Count == 0)
            {
                foreach (var property in getDBConstructionCostByProperty)
                {
                    for (int i = 0; i < period; i++)
                    {
                        constructionCostByPeriod.Add(new ConstructionCostByPeriod
                        {
                            ComplexProperty = complexProperty,
                            Property = property.Property,
                            Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1,
                            Year = DateTime.Now.AddMonths(i * 3).Year
                        });
                    }
                }
            }

            return constructionCostByPeriod;
        }

        public async Task<IEnumerable<SalesValueByPeriod>> RequestBySalesPeriodsAsync(string complexProperty, int period)
        {
            var getExcelSalesValueByCategory = _getDataSource.GetSalesValueByCategory(complexProperty);
            await _saveData.SaveSalesValueByCategoryAsync(getExcelSalesValueByCategory, complexProperty);

            var getDBSalesValueByCategory = await _getDataRepository.GetSalesValueByCategoryAsync(complexProperty);

            var salesValueByPeriod = await _getDataRepository.GetSalesValueByPeriodAsync(complexProperty);
            if (salesValueByPeriod.Count == 0)
            {
                foreach (var category in getDBSalesValueByCategory)
                {
                    for (int i = 0; i < period; i++)
                    {
                        salesValueByPeriod.Add(new SalesValueByPeriod
                        {
                            ComplexProperty = complexProperty,
                            Category = category.Category,
                            SalesValue = category.SalesValue,
                            Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1,
                            Year = DateTime.Now.AddMonths(i * 3).Year
                        });
                    }
                }
            }

            return salesValueByPeriod;
        }
    }
}
