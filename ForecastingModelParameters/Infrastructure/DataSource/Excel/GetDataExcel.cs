using ForecastingModelParameters.Application;
using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.Extensions.Options;
using OfficeOpenXml;

namespace ForecastingModelParameters.Infrastructure.DataSource.Excel
{
    public class GetDataExcel : IGetDataSource
    {
        private readonly FilePathConfiguration _filePathConfiguration;
        private readonly string filePath;

        public GetDataExcel(IOptions<FilePathConfiguration> filePathConfiguration)
        {
            _filePathConfiguration = filePathConfiguration.Value;
            filePath = _filePathConfiguration.FilePath;
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
        }

        public IEnumerable<ProjectCostingData> ProjectCostingData(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\ProjectCostingData({complexProperty}).xlsx");

            var projectCostingDatas = new List<ProjectCostingData>();

            using var package = new ExcelPackage(fileInfo);
            var sheet = package.Workbook.Worksheets[Name: "ProjectCostingData"];

            int rowCount = sheet.Dimension.Rows;
            int colCount = sheet.Dimension.Columns;

            for (int row = 3; row <= rowCount; row++)
            {
                var projectCostingData = new ProjectCostingData
                {
                    ComplexProperty = complexProperty,
                    Id = new Guid(),
                    Field = sheet.Cells[row, 1].Value?.ToString(),
                    Name = sheet.Cells[row, 2].Value?.ToString(),
                    Fact = Convert.ToDouble(sheet.Cells[row, 3].Value)                     
                };

                for (int col = 4; col <= colCount; col++)
                {
                    var projectCostingDataPeriod = new ProjectCostingDataPeriod
                    {
                        ProjectCostingDataId = projectCostingData.Id, // Связываем с родителем
                        Amount = Convert.ToDouble(sheet.Cells[row, col].Value),
                        Year = Convert.ToInt32(sheet.Cells[1, col].Value),
                        Quarter = Convert.ToInt32(sheet.Cells[2, col].Value)
                    };

                    projectCostingData.ProjectCostingDataPeriods.Add(projectCostingDataPeriod);
                }

                projectCostingDatas.Add(projectCostingData);
            }
            return projectCostingDatas;
        }
    }
}