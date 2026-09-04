using ForecastingModelParameters.Application;
using ForecastingModelParameters.Application.Interfaces;
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

        public IEnumerable<T> ProjectCostingData<T>(string complexProperty, string name)
        {
            FileInfo fileInfo = new(filePath + $"\\{name}({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: name];

                var range = sheet.Cells[sheet.Dimension.Address];
                return range.ToCollection<T>();
            }
            else return null;
        }

    }
}
