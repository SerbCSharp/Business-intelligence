using ForecastingModelParameters.Application;
using ForecastingModelParameters.Domain;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ForecastingModelParameters.Presentation.ReportsToExcel
{
    public class ExportingReportsToExcel
    {
        private readonly FilePathConfiguration _filePathConfiguration;
        private readonly string filePath;

        public ExportingReportsToExcel(IOptions<FilePathConfiguration> filePathConfiguration)
        {
            _filePathConfiguration = filePathConfiguration.Value;
            filePath = _filePathConfiguration.FilePath;
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
        }

        public void ProjectCostingData(List<ProjectCostingData> projectCostingData, string complexProperty, int period)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"\\ProjectCostingData({complexProperty}).xlsx");
            var sheet = package.Workbook.Worksheets.Add("ProjectCostingData");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;

            sheet.Cells[1, 1].Value = "Наименование";
            sheet.Cells[1, 2].Value = "Факт";
            sheet.Cells[1, 1, 2, 1].Merge = true;
            sheet.Cells[1, 2, 2, 2].Merge = true;
            for (int i = 0; i < period; i++)
            {
                sheet.Cells[1, 3 + i].Value = projectCostingData[i].ProjectCostingDataPeriods[i].Year;
                sheet.Cells[2, 3 + i].Value = projectCostingData[i].ProjectCostingDataPeriods[i].Quarter;
            }

            var row = 3;
            var column = 0;
            foreach (var item in projectCostingData)
            {
                sheet.Cells[row, column + 1].Value = item.Name;
                sheet.Cells[row, column + 2].Value = item.Fact;
                for (int i = 0; i < period; i++)
                {
                    sheet.Cells[row, column + 3 + i].Value = projectCostingData[i].ProjectCostingDataPeriods[i].Quarter;
                }

                row++;
            }

            sheet.Cells[1, 1, row, 2].AutoFitColumns();

            package.SaveAs(fileInfo);
        }
    }
}