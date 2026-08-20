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

        public void ConstructionCostByProperty(IEnumerable<ConstructionCostByProperty> constructionCostByProperty, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"\\ConstructionCostByProperty({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("ConstructionCostByProperty");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Property";
            sheetSource.Cells[1, 3].Value = "ConstructionCost";
            sheetSource.Cells[1, 4].Value = "IncurredCosts";
            sheetSource.Cells[1, 1, 1, 4].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in constructionCostByProperty)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Property;
                sheetSource.Cells[row, column + 3].Value = item.ConstructionCost;
                sheetSource.Cells[row, column + 4].Value = item.IncurredCosts;
                row++;
            }
            sheetSource.Cells[1, 1, row, 4].AutoFitColumns();
            sheetSource.Cells["C:D"].Style.Numberformat.Format = "### ### ### ##0.00";
            var range = sheetSource.Cells[1, 1, row - 1, 4];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }

        public void ConstructionCostByPeriod(IEnumerable<ConstructionCostByPeriod> constructionCostByPeriod, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"\\ConstructionCostByPeriod({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("ConstructionCostByPeriod");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Property";
            sheetSource.Cells[1, 3].Value = "ConstructionCost";
            sheetSource.Cells[1, 4].Value = "PercentageOfCosts";
            sheetSource.Cells[1, 5].Value = "Quarter";
            sheetSource.Cells[1, 6].Value = "Year";
            sheetSource.Cells[1, 1, 1, 6].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in constructionCostByPeriod)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Property;
                sheetSource.Cells[row, column + 3].Value = item.ConstructionCost;
                sheetSource.Cells[row, column + 4].Value = item.PercentageOfCosts;
                sheetSource.Cells[row, column + 5].Value = item.Quarter;
                sheetSource.Cells[row, column + 6].Value = item.Year;
                row++;
            }
            sheetSource.Cells[1, 1, row, 6].AutoFitColumns();
            sheetSource.Cells["C:D"].Style.Numberformat.Format = "### ### ### ##0.00";
            sheetSource.Cells["E:F"].Style.Numberformat.Format = "###0";
            var range = sheetSource.Cells[1, 1, row - 1, 6];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }
    }
}