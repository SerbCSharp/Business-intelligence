using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using OfficeOpenXml.Style;
using Reports.Domain;
using System.Reflection;

namespace Reports.Presentation.ReportsToExcel
{
    public class ExportingReportsToExcel
    {
        public ExportingReportsToExcel()
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
        }

        public byte[] Browse<T>(IEnumerable<T> data) // Универсальный просмотрщик
        {
            using var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Source");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            var type = data.GetType().GetInterface("IEnumerable`1").GetGenericArguments()[0];
            var fields = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var countFields = fields.Length;

            for (int i = 0; i < countFields; i++)
            {
                sheet.Cells[1, i + 1].Value = fields[i].Name;
                switch (fields[i].PropertyType.Name)
                {
                    case "String":
                        sheet.Column(i + 1).Style.Numberformat.Format = "@";
                        break;
                    case "DateTime":
                        sheet.Column(i + 1).Style.Numberformat.Format = "dd.mm.yyyy";
                        break;
                    case "Decimal":
                        sheet.Column(i + 1).Style.Numberformat.Format = "### ### ### ##0.00";
                        break;
                    default:
                        break;
                }
            }
            sheet.Cells[1, 1, 1, countFields].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, countFields].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            foreach (var item in data)
            {
                for (int i = 0; i < countFields; i++)
                {
                    sheet.Cells[row, i + 1].Value = fields[i].GetValue(item);
                }
                row++;
            }

            sheet.Cells[1, 1, row, countFields].AutoFitColumns();

            var range = sheet.Cells[1, 1, row - 1, countFields];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            return package.GetAsByteArray();
        }

        public byte[] NonProductionCosts(IEnumerable<NonProductionCosts> nonProductionCosts)
        {
            using var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Нероизводственные расходы");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Месяц";
            sheet.Cells[1, 3].Value = "Нероизводственные расходы";
            sheet.Cells[1, 4].Value = "Производственные расходы";
            sheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in nonProductionCosts)
            {
                sheet.Cells[row, column + 1].Value = item.Year;
                sheet.Cells[row, column + 2].Value = item.Month;
                sheet.Cells[row, column + 3].Value = item.NonProductionAmount;
                sheet.Cells[row, column + 4].Value = item.ProductionAmount;
                row++;
            }
            sheet.Cells[1, 1, row, 4].AutoFitColumns();
            sheet.Cells[2, 1, row, 2].Style.Numberformat.Format = "####";
            sheet.Cells[2, 3, row, 4].Style.Numberformat.Format = "### ### ### ###";

            var range = sheet.Cells[1, 1, row - 1, 4];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            // Добавляем график на лист
            var chart = sheet.Drawings.AddChart("ProductionChart", eChartType.Line) as ExcelLineChart;
            chart.Title.Text = "Динамика производственных и непроизводственных расходов";
            chart.SetPosition(1, 0, 5, 0);
            chart.SetSize(1000, 700);
            chart.Legend.Position = eLegendPosition.Bottom;

            var nonProductionY = sheet.Cells[2, 3, row, 3];
            var productionY = sheet.Cells[2, 4, row, 4];
            var rangeX = sheet.Cells[2, 1, row, 2];
            var nonProduction = chart.Series.Add(nonProductionY, rangeX);
            nonProduction.Header = "Нероизводственные расходы";
            var production = chart.Series.Add(productionY);
            production.Header = "Производственные расходы";

            chart.YAxis.AddGridlines(addMajor: true, addMinor: false);
            chart.XAxis.AddGridlines(addMajor: true, addMinor: false);
            chart.StyleManager.SetChartStyle(ePresetChartStyle.LineChartStyle4);

            return package.GetAsByteArray();
        }
    }
}