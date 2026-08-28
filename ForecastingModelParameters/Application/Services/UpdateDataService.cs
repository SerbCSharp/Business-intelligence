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

        public async Task<IEnumerable<OtherFixedCost>> RequestOtherFixedCostAsync(string complexProperty)
        {
            var otherFixedCost = await _getDataRepository.GetOtherFixedCostAsync(complexProperty);
            if (otherFixedCost.Count == 0)
            {
                var reportFields = await _getDataRepository.GetReportFieldAsync();
                var filteredSequence = reportFields.Where(x => !x.PercentageOrFixed && x.Parameter);
                foreach (var item in filteredSequence)
                {
                    otherFixedCost.Add(new OtherFixedCost
                    {
                        ComplexProperty = complexProperty,
                        Name = item.Name,
                        Field = item.Field
                    });
                }
            }

            return otherFixedCost;
        }

        public async Task<IEnumerable<OtherPercentageCost>> RequestOtherPercentageCostAsync(string complexProperty)
        {
            var otherPercentageCost = await _getDataRepository.GetOtherPercentageCostAsync(complexProperty);
            if (otherPercentageCost.Count == 0)
            {
                var reportFields = await _getDataRepository.GetReportFieldAsync();
                var filteredSequence = reportFields.Where(x => x.PercentageOrFixed && x.Parameter);
                foreach (var item in filteredSequence)
                {
                    otherPercentageCost.Add(new OtherPercentageCost
                    {
                        ComplexProperty = complexProperty,
                        Name = item.Name,
                        Field = item.Field
                    });
                }
            }

            return otherPercentageCost;
        }

        public async Task<IEnumerable<OtherFixedCostByPeriod>> RequestOtherFixedCostByPeriodAsync(string complexProperty, int period)
        {
            var otherFixedCostByPeriod = await _getDataRepository.GetOtherFixedCostByPeriodAsync(complexProperty);
            if (otherFixedCostByPeriod.Count == 0)
            {
                var reportFields = await _getDataRepository.GetReportFieldAsync();
                var filteredSequence = reportFields.Where(x => !x.PercentageOrFixed && x.Parameter);
                foreach (var item in filteredSequence)
                {
                    for (int i = 0; i < period; i++)
                    {
                        otherFixedCostByPeriod.Add(new OtherFixedCostByPeriod
                        {
                            ComplexProperty = complexProperty,
                            Name = item.Name,
                            Field = item.Field,
                            Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1,
                            Year = DateTime.Now.AddMonths(i * 3).Year
                        });
                    }
                }
            }

            return otherFixedCostByPeriod;
        }

        public async Task<IEnumerable<OtherPercentageCostByPeriod>> RequestOtherPercentageCostByPeriodAsync(string complexProperty, int period)
        {
            var otherPercentageCostByPeriod = await _getDataRepository.GetOtherPercentageCostByPeriodAsync(complexProperty);
            if (otherPercentageCostByPeriod.Count == 0)
            {
                var reportFields = await _getDataRepository.GetReportFieldAsync();
                var filteredSequence = reportFields.Where(x => x.PercentageOrFixed && x.Parameter);
                foreach (var item in filteredSequence)
                {
                    for (int i = 0; i < period; i++)
                    {
                        otherPercentageCostByPeriod.Add(new OtherPercentageCostByPeriod
                        {
                            ComplexProperty = complexProperty,
                            Name = item.Name,
                            Field = item.Field,
                            Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1,
                            Year = DateTime.Now.AddMonths(i * 3).Year
                        });
                    }
                }
            }

            return otherPercentageCostByPeriod;
        }

        public async Task SaveConstructionCostByPropertyAsync(string complexProperty)
        {
            var getExcelConstructionCostByProperty = _getDataSource.GetConstructionCostByProperty(complexProperty);
            await _saveData.SaveConstructionCostByPropertyAsync(getExcelConstructionCostByProperty, complexProperty);
        }

        public async Task SaveSalesValueByCategoryAsync(string complexProperty)
        {
            var getExcelSalesValueByCategory = _getDataSource.GetSalesValueByCategory(complexProperty);
            await _saveData.SaveSalesValueByCategoryAsync(getExcelSalesValueByCategory, complexProperty);
        }

        public async Task SaveConstructionCostByPeriodAsync(string complexProperty)
        {
            var getExcelConstructionCostByPeriod = _getDataSource.GetConstructionCostByPeriod(complexProperty);
            await _saveData.SaveConstructionCostByPeriodAsync(getExcelConstructionCostByPeriod, complexProperty);
        }

        public async Task SaveSalesValueByPeriodAsync(string complexProperty)
        {
            var getExcelSalesValueByPeriod = _getDataSource.GetSalesValueByPeriod(complexProperty);
            await _saveData.SaveSalesValueByPeriodAsync(getExcelSalesValueByPeriod, complexProperty);
        }

        public async Task SaveOtherFixedCostAsync(string complexProperty)
        {
            var getExcelOtherFixedCost = _getDataSource.GetOtherFixedCost(complexProperty);
            await _saveData.SaveOtherFixedCostAsync(getExcelOtherFixedCost, complexProperty);
        }

        public async Task SaveOtherPercentageCostAsync(string complexProperty)
        {
            var getExcelOtherPercentageCost = _getDataSource.GetOtherPercentageCost(complexProperty);
            await _saveData.SaveOtherPercentageCostAsync(getExcelOtherPercentageCost, complexProperty);
        }

        public async Task SaveOtherFixedCostByPeriodAsync(string complexProperty)
        {
            var getExcelOtherFixedCostByPeriod = _getDataSource.GetOtherFixedCostByPeriod(complexProperty);
            await _saveData.SaveOtherFixedCostByPeriodAsync(getExcelOtherFixedCostByPeriod, complexProperty);
        }

        public async Task SaveOtherPercentageCostByPeriodAsync(string complexProperty)
        {
            var getExcelOtherPercentageCostByPeriod = _getDataSource.GetOtherPercentageCostByPeriod(complexProperty);
            await _saveData.SaveOtherPercentageCostByPeriodAsync(getExcelOtherPercentageCostByPeriod, complexProperty);
        }

        public async Task<IEnumerable<ConstructionCostByPeriod>> RequestByPeriodsConstructionAsync(string complexProperty, int period)
        {
            await SaveConstructionCostByPropertyAsync(complexProperty);

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
            await SaveSalesValueByCategoryAsync(complexProperty);

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
                            Quarter = (DateTime.Now.AddMonths(i * 3).Month - 1) / 3 + 1,
                            Year = DateTime.Now.AddMonths(i * 3).Year
                        });
                    }
                }
            }

            return salesValueByPeriod;
        }

        public async Task SaveAllProjectCostingDataAsync(string complexProperty)
        {
            await SaveConstructionCostByPropertyAsync(complexProperty);
            await SaveConstructionCostByPeriodAsync(complexProperty);
            await SaveOtherFixedCostAsync(complexProperty);
            await SaveOtherPercentageCostAsync(complexProperty);
            await SaveOtherFixedCostByPeriodAsync(complexProperty);
            await SaveOtherPercentageCostByPeriodAsync(complexProperty);
            await SaveSalesValueByCategoryAsync(complexProperty);
            await SaveSalesValueByPeriodAsync(complexProperty);
        }
    }
}
