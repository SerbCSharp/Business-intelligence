using ForecastingModelParameters.Application;
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

        public void RequestProjectCostingData<T>(IEnumerable<T> requestProjectCostingData, string complexProperty, string name)
        {
            using var package = new ExcelPackage();

            FileInfo fileInfo = new(filePath + $"\\{name}({complexProperty}).xlsx");
            var sheet = package.Workbook.Worksheets.Add(name);
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;

            sheet.Cells["A1"].LoadFromCollection(requestProjectCostingData, c => { c.PrintHeaders = true; });

            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column].AutoFitColumns();
            var range = sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            package.SaveAs(fileInfo);
        }
    }
}