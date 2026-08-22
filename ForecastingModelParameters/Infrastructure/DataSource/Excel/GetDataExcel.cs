using ForecastingModelParameters.Application;
using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using System.Data;

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

        public IEnumerable<ConstructionCostByPeriod> GetConstructionCostByPeriod(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\ConstructionCostByPeriod({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "ConstructionCostByPeriod"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "ConstructionCost")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "PercentageOfCosts")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "Quarter")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(int));
                    else if (sheet.Cells[1, i].Value.ToString() == "Year")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(int));
                    else
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 1; j <= sheet.Dimension.End.Column; j++)
                    {
                        dataRow[j - 1] = sheet.Cells[i, j].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                return dataTable.AsEnumerable().Select(row => new ConstructionCostByPeriod
                {
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    Property = row.Field<string>("Property"),
                    ConstructionCost = row.Field<decimal>("ConstructionCost"),
                    PercentageOfCosts = row.Field<decimal>("PercentageOfCosts"),
                    Quarter = row.Field<int>("Quarter"),
                    Year = row.Field<int>("Year")
                });
            }
            else return null;
        }

        public IEnumerable<ConstructionCostByProperty> GetConstructionCostByProperty(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\ConstructionCostByProperty({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "ConstructionCostByProperty"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "ConstructionCost")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "IncurredCosts")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 1; j <= sheet.Dimension.End.Column; j++)
                    {
                        dataRow[j - 1] = sheet.Cells[i, j].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                return dataTable.AsEnumerable().Select(row => new ConstructionCostByProperty
                {
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    Property = row.Field<string>("Property"),
                    ConstructionCost = row.Field<decimal>("ConstructionCost"),
                    IncurredCosts = row.Field<decimal>("IncurredCosts")
                });
            }
            else return null;
        }

        public IEnumerable<OtherCost> GetOtherCost(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\OtherCost({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "OtherCost"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "IncurredCosts")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 1; j <= sheet.Dimension.End.Column; j++)
                    {
                        dataRow[j - 1] = sheet.Cells[i, j].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                return dataTable.AsEnumerable().Select(row => new OtherCost
                {
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    Name = row.Field<string>("Name"),
                    IncurredCosts = row.Field<decimal>("IncurredCosts")                     
                });
            }
            else return null;
        }

        public IEnumerable<OtherCostByPeriod> GetOtherCostByPeriod(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\OtherCostByPeriod({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "OtherCostByPeriod"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "Amount")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "PercentageOfCosts")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "Quarter")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(int));
                    else if (sheet.Cells[1, i].Value.ToString() == "Year")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(int));
                    else
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 1; j <= sheet.Dimension.End.Column; j++)
                    {
                        dataRow[j - 1] = sheet.Cells[i, j].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                return dataTable.AsEnumerable().Select(row => new OtherCostByPeriod
                {
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    Name = row.Field<string>("Name"),
                    Amount = row.Field<decimal>("Amount"),
                    PercentageOfCosts = row.Field<decimal>("PercentageOfCosts"),
                    Quarter = row.Field<int>("Quarter"),
                    Year = row.Field<int>("Year")
                });
            }
            else return null;
        }

        public IEnumerable<SalesValueByCategory> GetSalesValueByCategory(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\SalesValueByCategory({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "SalesValueByCategory"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "SalesValue")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "Sold")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 1; j <= sheet.Dimension.End.Column; j++)
                    {
                        dataRow[j - 1] = sheet.Cells[i, j].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                return dataTable.AsEnumerable().Select(row => new SalesValueByCategory
                {
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    Category = row.Field<string>("Category"),
                    SalesValue = row.Field<decimal>("SalesValue"),
                    Sold = row.Field<decimal>("Sold")
                });
            }
            else return null;
        }

        public IEnumerable<SalesValueByPeriod> GetSalesValueByPeriod(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"C:\\Business-intelligence\\ForecastingModel\\SalesValueByPeriod({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "SalesValueByPeriod"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "SalesValue")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "Quarter")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(int));
                    else if (sheet.Cells[1, i].Value.ToString() == "Year")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(int));
                    else
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 1; j <= sheet.Dimension.End.Column; j++)
                    {
                        dataRow[j - 1] = sheet.Cells[i, j].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                return dataTable.AsEnumerable().Select(row => new SalesValueByPeriod
                {
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    Category = row.Field<string>("Category"),
                    SalesValue = row.Field<decimal>("SalesValue"),
                    Quarter = row.Field<int>("Quarter"),
                    Year = row.Field<int>("Year")
                });
            }
            else return null;
        }
    }
}
