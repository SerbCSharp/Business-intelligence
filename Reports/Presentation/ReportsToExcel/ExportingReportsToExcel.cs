using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using OfficeOpenXml.Style;
using Reports.Application.DTO;
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

            var sheet = package.Workbook.Worksheets.Add("Browse");
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

        public ExcelPackage ProfitCentersSource(IEnumerable<ProfitCentersSource> profitCentersSource)
        {
            var package = new ExcelPackage();

            var sheetSource = package.Workbook.Worksheets.Add("Source");
            sheetSource.Cells.Style.Font.Name = "Calibri";
            sheetSource.Cells.Style.Font.Size = 11;
            sheetSource.View.FreezePanes(2, 1);

            sheetSource.Cells[1, 1].Value = "Вид деятельности";
            sheetSource.Cells[1, 2].Value = "Направление";
            sheetSource.Cells[1, 3].Value = "Тип операции";
            sheetSource.Cells[1, 4].Value = "Поступления";
            sheetSource.Cells[1, 5].Value = "Оплаты";
            sheetSource.Cells[1, 6].Value = "Дата";
            sheetSource.Cells[1, 7].Value = "Назначение платежа";
            sheetSource.Cells[1, 8].Value = "Контрагент";
            sheetSource.Cells[1, 9].Value = "Договор";
            sheetSource.Cells[1, 1, 1, 9].Style.Font.Bold = true;
            sheetSource.Cells[1, 1, 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in profitCentersSource)
            {
                sheetSource.Cells[row, column + 1].Value = item.TypeOfActivity;
                sheetSource.Cells[row, column + 2].Value = item.AreaOfActivity;
                sheetSource.Cells[row, column + 3].Value = item.TypeOperation;
                sheetSource.Cells[row, column + 4].Value = item.Credit;
                sheetSource.Cells[row, column + 5].Value = item.Debit;
                sheetSource.Cells[row, column + 6].Value = item.Date;
                sheetSource.Cells[row, column + 7].Value = item.PaymentPurpose;
                sheetSource.Cells[row, column + 8].Value = item.Contractor;
                sheetSource.Cells[row, column + 9].Value = item.Number;
                row++;
            }
            sheetSource.Cells[1, 1, row, 9].AutoFitColumns();
            sheetSource.Cells[2, 6, row, 6].Style.Numberformat.Format = "dd.mm.yyyy";
            sheetSource.Cells[2, 4, row, 5].Style.Numberformat.Format = "### ### ### ##0.00";
            sheetSource.Column(1).Width = 30;
            sheetSource.Column(7).Width = 50;
            sheetSource.Column(8).Width = 30;
            sheetSource.Column(9).Width = 30;

            var range = sheetSource.Cells[1, 1, row - 1, 9];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            return package;            
        }

        public byte[] ProfitCenters(ExcelPackage package, IEnumerable<ProfitCentersDTO> profitCenters, decimal openingBalance, DateTime startDate, DateTime endDate)
        {
            var sheet = package.Workbook.Worksheets.Add("Profit Centers");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;

            sheet.Cells[1, 1, 1, 5].Merge = true;
            sheet.Cells[1, 1].Value = "ДДС по направлениям";
            sheet.Cells[1, 1].Style.Font.Size = 20;
            sheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            sheet.Cells[2, 4, 2, 5].Merge = true;
            sheet.Cells[2, 4].Value = $"с {DateOnly.FromDateTime(startDate)} по {DateOnly.FromDateTime(endDate)}";
            sheet.Cells[2, 4].Style.Font.Size = 16;
            sheet.Cells[2, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            sheet.Cells[4, 1, 6, 5].Style.Font.Bold = true;
            sheet.Cells[4, 4].Value = "Остаток на начало:";
            sheet.Cells[4, 2, 4, 4].Style.Font.Size = 12;
            sheet.Cells[4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[4, 5].Value = openingBalance;
            sheet.Cells[4, 5].Style.Numberformat.Format = "### ### ### ##0.00";

            sheet.Cells[6, 1].Value = "Направления";
            sheet.Cells[6, 2].Value = "Поступления";
            sheet.Cells[6, 3].Value = "Выплаты (прямые расходы)";
            sheet.Cells[6, 4].Value = "Выплаты (косвенные расходы)";
            sheet.Cells[6, 5].Value = "Сальдо";
            sheet.Cells[6, 1, 6, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 7;
            var column = 0;
            foreach (var item in profitCenters)
            {
                sheet.Cells[row, column + 1].Value = item.AreaOfActivity;
                sheet.Cells[row, column + 2].Value = item.Credit;
                sheet.Cells[row, column + 3].Value = item.Debit;
                sheet.Cells[row, column + 4].Value = item.IndirectCost;
                sheet.Cells[row, column + 5].Formula = $"B{row}-C{row}-D{row}";
                row++;
            }
            sheet.Cells[row, column + 2].Formula = $"=SUBTOTAL(9,B6:B{row - 1})";
            sheet.Cells[row, column + 3].Formula = $"=SUBTOTAL(9,C6:C{row - 1})";
            sheet.Cells[row, column + 4].Formula = $"=SUBTOTAL(9,D6:D{row - 1})";
            sheet.Cells[row, column + 5].Formula = $"=SUBTOTAL(9,E6:E{row - 1})";
            sheet.Cells[row, 2, row, 5].Style.Font.Bold = true;

            sheet.Cells[1, 1, row, 5].AutoFitColumns();
            sheet.Cells[7, 2, row, 5].Style.Numberformat.Format = "### ### ### ##0.00";
            sheet.Column(5).Width = 15;

            var range = sheet.Cells[6, 1, row - 1, 5];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            sheet.Cells[row + 2, 1, row + 2, 5].Style.Font.Bold = true;
            sheet.Cells[row + 2, 4].Value = "Остаток на конец:";
            sheet.Cells[row + 2, 2, row + 2, 4].Style.Font.Size = 12;
            sheet.Cells[row + 2, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[row + 2, 5].Formula = $"=SUBTOTAL(9,E7:E{row - 1})+E4";
            sheet.Cells[row + 2, 5].Style.Numberformat.Format = "### ### ### ##0.00";

            var byteArray = package.GetAsByteArray();
            package.Dispose();

            return byteArray;
        }

        public byte[] ConstructionCost(IEnumerable<ConstructionCostDTO> constructionCost)
        {
            using var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Стоимость строительства");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            sheet.Cells[1, 1].Value = "Контрагент";
            sheet.Cells[1, 2].Value = "Договор";
            sheet.Cells[1, 3].Value = "Дата договора";
            sheet.Cells[1, 4].Value = "Сумма договора";
            sheet.Cells[1, 5].Value = "Выполнение";
            sheet.Cells[1, 6].Value = "Оплата";
            sheet.Cells[1, 7].Value = "Литер";
            sheet.Cells[1, 8].Value = "Статья затрат";
            sheet.Cells[1, 9].Value = "Подрядчик/Поставщик";
            sheet.Cells[1, 10].Value = "Генподрядные";
            sheet.Cells[1, 11].Value = "Стоимость строительства";
            sheet.Cells[1, 12].Value = "Входящий НДС";
            sheet.Cells[1, 1, 1, 12].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var row = 2;
            var column = 0;
            foreach (var item in constructionCost)
            {
                sheet.Cells[row, column + 1].Value = item.Contractor;
                sheet.Cells[row, column + 2].Value = item.Name;
                sheet.Cells[row, column + 3].Value = item.Date;
                sheet.Cells[row, column + 4].Value = item.ContractAmount;
                sheet.Cells[row, column + 5].Value = item.InvoiceAmount;
                sheet.Cells[row, column + 6].Value = item.PaymentAmount;
                sheet.Cells[row, column + 7].Value = item.Property;
                sheet.Cells[row, column + 8].Value = item.CostItem;
                sheet.Cells[row, column + 9].Value = item.ContractorOrSupplier;
                sheet.Cells[row, column + 10].Value = item.GeneralContractorMarkup;
                sheet.Cells[row, column + 11].Value = item.ConstructionCost;
                sheet.Cells[row, column + 12].Value = item.VATRate;
                row++;
            }

            sheet.Cells[row, column + 4].Formula = $"=SUBTOTAL(9,D2:D{row - 1})";
            sheet.Cells[row, column + 5].Formula = $"=SUBTOTAL(9,E2:E{row - 1})";
            sheet.Cells[row, column + 6].Formula = $"=SUBTOTAL(9,F2:F{row - 1})";
            sheet.Cells[row, column + 11].Formula = $"=SUBTOTAL(9,K2:K{row - 1})";
            sheet.Cells[row, 2, row, 12].Style.Font.Bold = true;


            sheet.Cells[1, 1, row, 12].AutoFitColumns();
            sheet.Cells[2, 3, row, 3].Style.Numberformat.Format = "dd.mm.yyyy";
            sheet.Cells[2, 4, row, 6].Style.Numberformat.Format = "### ### ### ##0.00";
            sheet.Cells[2, 10, row, 10].Style.Numberformat.Format = "0%";
            sheet.Cells[2, 11, row, 11].Style.Numberformat.Format = "### ### ### ##0.00";
            sheet.Cells[2, 12, row, 12].Style.Numberformat.Format = "0%";
            sheet.Column(1).Width = 50;
            sheet.Column(2).Width = 50;
            sheet.Column(7).Width = 50;
            sheet.Column(8).Width = 50;

            var range = sheet.Cells[1, 1, row - 1, 12];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            return package.GetAsByteArray();
        }

        public ExcelPackage ConstructionCostByPeriod(IEnumerable<ConstructionCostByPeriod> constructionCostByPeriod)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("СМР");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            sheet.Cells["A1"].LoadFromCollection(constructionCostByPeriod, c => { c.PrintHeaders = true; });

            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column].AutoFitColumns();
            var range = sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            MergeSameAdjacentCells(sheet, 1, 2, sheet.Dimension.End.Row, 5);
            sheet.Cells[2, 1, sheet.Dimension.End.Row, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            sheet.Cells[2, 1, sheet.Dimension.End.Row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return package;
        }

        public void SalesTarget(ExcelPackage package, IEnumerable<SalesTarget> salesTarget)
        {
            var sheet = package.Workbook.Worksheets.Add("План продаж");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            sheet.Cells["A1"].LoadFromCollection(salesTarget, c => { c.PrintHeaders = true; });

            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column].AutoFitColumns();
            var range = sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            MergeSameAdjacentCells(sheet, 1, 2, sheet.Dimension.End.Row, 5);
            sheet.Cells[2, 1, sheet.Dimension.End.Row, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            sheet.Cells[2, 1, sheet.Dimension.End.Row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public void OtherCost(ExcelPackage package, IEnumerable<OtherCost> otherCost)
        {
            var sheet = package.Workbook.Worksheets.Add("Расходы кроме СМР и процентов");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            sheet.Cells["A1"].LoadFromCollection(otherCost, c => { c.PrintHeaders = true; });

            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column].AutoFitColumns();
            var range = sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;

            MergeSameAdjacentCells(sheet, 1, 2, sheet.Dimension.End.Row, 2);
            sheet.Cells[2, 1, sheet.Dimension.End.Row, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            sheet.Cells[2, 1, sheet.Dimension.End.Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public void InterestCost(ExcelPackage package, IEnumerable<InterestCostDTO> interestCost)
        {
            var sheet = package.Workbook.Worksheets.Add("Проценты");
            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;
            sheet.View.FreezePanes(2, 1);

            sheet.Cells["A1"].LoadFromCollection(interestCost, c => { c.PrintHeaders = true; });

            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column].AutoFitColumns();
            var range = sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.AutoFilter = true;
        }

        public byte[] ConstructionCostForecast(ExcelPackage package, IEnumerable<ConstructionCostForecast> constructionCostForecast, string complexProperty)
        {
            var sheet = package.Workbook.Worksheets.Add("Бюджет");
            package.Workbook.Worksheets.MoveToStart("Бюджет");
            package.Workbook.View.ActiveTab = 0;

            sheet.Cells.Style.Font.Name = "Calibri";
            sheet.Cells.Style.Font.Size = 11;

            sheet.Cells[1, 1, 1, 2].Merge = true;
            sheet.Cells[1, 1].Value = $"Прогноз общей стоимости строительства({complexProperty})";
            sheet.Cells[1, 1].Style.Font.Size = 14;
            sheet.Cells[1, 1, 1, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            sheet.Cells["A3"].LoadFromCollection(constructionCostForecast, c => { c.PrintHeaders = true; });

            sheet.Cells[3, 1, 3, sheet.Dimension.End.Column].Style.Font.Bold = true;
            sheet.Cells[3, 1, 3, sheet.Dimension.End.Column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[3, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column].AutoFitColumns();

            sheet.Cells[4, 1, 4, 2].Style.Font.Size = 12;
            sheet.Cells[4, 1, 4, 2].Style.Font.Bold = true;
            sheet.Cells[6, 1, 8, 1].Style.Font.Size = 10;
            sheet.Cells[11, 1, 13, 1].Style.Font.Size = 10;
            sheet.Cells[15, 1, 16, 2].Style.Font.Size = 12;
            sheet.Cells[15, 1, 16, 2].Style.Font.Bold = true;

            sheet.Cells[5, 2].Formula = $"B{6}+B{7}+B{8}";
            sheet.Cells[10, 2].Formula = $"B{11}+B{12}+B{13}";
            sheet.Cells[15, 2].Formula = $"B{5}+B{9}+B{10}+B{14}";
            sheet.Cells[16, 2].Formula = $"B{4}-B{15}";

            var range = sheet.Cells[3, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            var byteArray = package.GetAsByteArray();
            package.Dispose();

            return byteArray;
        }

        public void MergeSameAdjacentCells(ExcelWorksheet sheet, int col, int startRow, int endRow, int numberOfColumns)
        {
            int rangeStartRow = startRow;

            for (int row = startRow; row <= endRow; row++)
            {
                var currentValue = sheet.Cells[row, col].Value?.ToString();
                var nextValue = (row < endRow) ? sheet.Cells[row + 1, col].Value?.ToString() : null;

                if (currentValue != nextValue || row == endRow)
                {
                    if (rangeStartRow < row)
                    {
                        for (int i = 0; i < numberOfColumns; i++)
                        {
                            sheet.Cells[rangeStartRow, col + i, row, col + i].Merge = true;
                        }
                    }

                    rangeStartRow = row + 1;
                }
            }
        }
    }
}