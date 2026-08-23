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

            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\ConstructionCostByProperty({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("ConstructionCostByProperty");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Property";
            sheetSource.Cells[1, 3].Value = "PlannedCostPerSqm";
            sheetSource.Cells[1, 4].Value = "SquareMeters";
            sheetSource.Cells[1, 5].Value = "ConstructionCost";
            sheetSource.Cells[1, 6].Value = "IncurredCosts";
            sheetSource.Cells[1, 1, 1, 6].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in constructionCostByProperty)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Property;
                sheetSource.Cells[row, column + 3].Value = item.PlannedCostPerSqm;
                sheetSource.Cells[row, column + 4].Value = item.SquareMeters;
                sheetSource.Cells[row, column + 5].Formula = $"C{row}*D{row}";
                sheetSource.Cells[row, column + 6].Value = item.IncurredCosts;
                row++;
            }
            sheetSource.Cells[1, 1, row, 6].AutoFitColumns();
            sheetSource.Cells["C:F"].Style.Numberformat.Format = "### ### ### ##0.00";
            var range = sheetSource.Cells[1, 1, row - 1, 6];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }

        public void SalesValueByCategory(IEnumerable<SalesValueByCategory> salesValueByCategory, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\SalesValueByCategory({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("SalesValueByCategory");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Category";
            sheetSource.Cells[1, 3].Value = "PricePerSqm";
            sheetSource.Cells[1, 4].Value = "SquareMeters";
            sheetSource.Cells[1, 5].Value = "Sold";
            sheetSource.Cells[1, 1, 1, 5].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in salesValueByCategory)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Category;
                sheetSource.Cells[row, column + 3].Value = item.PricePerSqm;
                sheetSource.Cells[row, column + 4].Value = item.SquareMeters;
                sheetSource.Cells[row, column + 5].Value = item.Sold;
                row++;
            }
            sheetSource.Cells[1, 1, row, 5].AutoFitColumns();
            sheetSource.Cells["C:E"].Style.Numberformat.Format = "### ### ### ##0.00";
            var range = sheetSource.Cells[1, 1, row - 1, 5];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }

        public void ConstructionCostByPeriod(IEnumerable<ConstructionCostByPeriod> constructionCostByPeriod, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\ConstructionCostByPeriod({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("ConstructionCostByPeriod");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Property";
            sheetSource.Cells[1, 3].Value = "ConstructionCost";
            sheetSource.Cells[1, 4].Value = "PercentageOfCosts";
            sheetSource.Cells[1, 5].Value = "CommissioningOfResidentialProperty";
            sheetSource.Cells[1, 6].Value = "Quarter";
            sheetSource.Cells[1, 7].Value = "Year";
            sheetSource.Cells[1, 1, 1, 7].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in constructionCostByPeriod)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Property;
                sheetSource.Cells[row, column + 3].Value = item.ConstructionCost;
                sheetSource.Cells[row, column + 4].Value = item.PercentageOfCosts;
                sheetSource.Cells[row, column + 5].Value = item.CommissioningOfResidentialProperty;
                sheetSource.Cells[row, column + 6].Value = item.Quarter;
                sheetSource.Cells[row, column + 7].Value = item.Year;
                row++;
            }
            sheetSource.Cells[1, 1, row, 7].AutoFitColumns();
            sheetSource.Cells["C:D"].Style.Numberformat.Format = "### ### ### ##0.00";
            sheetSource.Cells["F:G"].Style.Numberformat.Format = "###0";
            var range = sheetSource.Cells[1, 1, row - 1, 7];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }

        public void SalesValueByPeriod(IEnumerable<SalesValueByPeriod> salesValueByPeriod, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\SalesValueByPeriod({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("SalesValueByPeriod");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Category";
            sheetSource.Cells[1, 3].Value = "SalesTargetInSqm";
            sheetSource.Cells[1, 4].Value = "Quarter";
            sheetSource.Cells[1, 5].Value = "Year";
            sheetSource.Cells[1, 1, 1, 5].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in salesValueByPeriod)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Category;
                sheetSource.Cells[row, column + 3].Value = item.SalesTargetInSqm;
                sheetSource.Cells[row, column + 4].Value = item.Quarter;
                sheetSource.Cells[row, column + 5].Value = item.Year;
                row++;
            }
            sheetSource.Cells[1, 1, row, 5].AutoFitColumns();
            sheetSource.Cells["C:C"].Style.Numberformat.Format = "### ### ### ##0.00";
            sheetSource.Cells["D:E"].Style.Numberformat.Format = "###0";
            var range = sheetSource.Cells[1, 1, row - 1, 5];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }

        public void OtherCost(IEnumerable<OtherCost> otherCost, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\OtherCost({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("OtherCost");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Name";
            sheetSource.Cells[1, 3].Value = "IncurredCosts";
            sheetSource.Cells[1, 1, 1, 3].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in otherCost)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Name;
                sheetSource.Cells[row, column + 3].Value = item.IncurredCosts;
                row++;
            }
            sheetSource.Cells[1, 1, row, 3].AutoFitColumns();
            sheetSource.Cells["C:C"].Style.Numberformat.Format = "### ### ### ##0.00";
            var range = sheetSource.Cells[1, 1, row - 1, 3];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            package.SaveAs(fileInfo);
        }

        public void OtherCostByPeriod(IEnumerable<OtherCostByPeriod> otherCostByPeriod, string complexProperty)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\OtherCostByPeriod({complexProperty}).xlsx");
            var sheetSource = package.Workbook.Worksheets.Add("OtherCostByPeriod");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;

            sheetSource.Cells[1, 1].Value = "ComplexProperty";
            sheetSource.Cells[1, 2].Value = "Name";
            sheetSource.Cells[1, 3].Value = "Amount";
            sheetSource.Cells[1, 4].Value = "PercentageOfCosts";
            sheetSource.Cells[1, 5].Value = "Quarter";
            sheetSource.Cells[1, 6].Value = "Year";
            sheetSource.Cells[1, 1, 1, 6].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in otherCostByPeriod)
            {
                sheetSource.Cells[row, column + 1].Value = item.ComplexProperty;
                sheetSource.Cells[row, column + 2].Value = item.Name;
                sheetSource.Cells[row, column + 3].Value = item.Amount;
                sheetSource.Cells[row, column + 4].Value = item.PercentageOfCosts;
                sheetSource.Cells[row, column + 5].Value = item.Quarter;
                sheetSource.Cells[row, column + 6].Value = item.Year;
                row++;
            }
            sheetSource.Cells[1, 1, row, 6].AutoFitColumns();
            sheetSource.Cells["C:D"].Style.Numberformat.Format = "### ### ### ##0.000";
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