using OfficeOpenXml;
using OfficeOpenXml.Style;
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

            var sheet = package.Workbook.Worksheets.Add("Browse");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            var type = data.GetType().GetInterface("IEnumerable`1").GetGenericArguments()[0];
            var fields = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var countFields = fields.Length;

            // Шапка
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
    }
}
