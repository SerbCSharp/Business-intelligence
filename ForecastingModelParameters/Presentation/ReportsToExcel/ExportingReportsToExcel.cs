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

        public void ProjectCostingData(List<ProjectCostingData> projectCostingData, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"\\ProjectCostingData({complexProperty}).xlsx");
            var sheet = package.Workbook.Worksheets.Add("ProjectCostingData");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;

            sheet.Cells[1, 1].Value = "Field";
            sheet.Cells[1, 2].Value = "Наименование";
            sheet.Cells[1, 3].Value = "Факт";
            sheet.Cells[1, 1, 2, 1].Merge = true;
            sheet.Cells[1, 2, 2, 2].Merge = true;
            sheet.Cells[1, 3, 2, 3].Merge = true;

            var year = projectCostingData[0].ProjectCostingDataPeriods[0].Year;
            var period = projectCostingData[0].ProjectCostingDataPeriods.Count;
            for (int i = 0; i < period; i++)
            {
                sheet.Cells[1, 4 + i].Value = projectCostingData[0].ProjectCostingDataPeriods[i].Year;
                sheet.Cells[2, 4 + i].Value = projectCostingData[0].ProjectCostingDataPeriods[i].Quarter;
            }
            sheet.Cells[1, 1, 2, period + 3].Style.Font.Bold = true;
            sheet.Cells[1, 1, 2, period + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, 2, period + 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            var row = 3;
            var column = 0;
            foreach (var item in projectCostingData)
            {
                sheet.Cells[row, column + 1].Value = item.Field;
                sheet.Cells[row, column + 2].Value = item.Name;
                sheet.Cells[row, column + 3].Value = item.Fact;

                string[] fields = { "EscrowFunding", "InterestPayable", "Principal" };
                if (!fields.Contains(item.Field))
                {
                    for (int j = 0; j < period; j++)
                    {
                        sheet.Cells[row, column + 4 + j].Value = item.ProjectCostingDataPeriods[j].Amount;
                    }
                }
                row++;
            }

            sheet.Column(1).Hidden = true; 
            sheet.Cells[1, 1, row, period + 3].AutoFitColumns();
            sheet.Cells[3, 3, row - 1, period + 3].Style.Numberformat.Format = "### ### ### ##0.00";

            var range = sheet.Cells[1, 1, row - 1, period + 3];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }
    }
}