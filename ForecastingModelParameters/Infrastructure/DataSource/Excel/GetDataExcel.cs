using ForecastingModelParameters.Application;
using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using System;
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
            FileInfo fileInfo = new(filePath + $"\\ConstructionCostByPeriod({complexProperty}).xlsx");
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
                    else if (sheet.Cells[1, i].Value.ToString() == "CommissioningOfResidentialProperty")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(bool));
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
                    CommissioningOfResidentialProperty = row.Field<bool>("CommissioningOfResidentialProperty"),
                    Quarter = row.Field<int>("Quarter"),
                    Year = row.Field<int>("Year")
                });
            }
            else return null;
        }

        public IEnumerable<ConstructionCostByProperty> GetConstructionCostByProperty(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\ConstructionCostByProperty({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "ConstructionCostByProperty"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "PlannedCostPerSqm")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "SquareMeters")
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
                    PlannedCostPerSqm = row.Field<decimal>("PlannedCostPerSqm"),
                    SquareMeters = row.Field<decimal>("SquareMeters"),
                    IncurredCosts = row.Field<decimal>("IncurredCosts")
                });
            }
            else return null;
        }

        public IEnumerable<OtherFixedCost> GetOtherFixedCost(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\OtherFixedCost({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "OtherFixedCost"];

                var range = sheet.Cells[sheet.Dimension.Address];
                return range.ToCollection<OtherFixedCost>();
            }
            else return null;
        }

        public IEnumerable<OtherFixedCostByPeriod> GetOtherFixedCostByPeriod(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\OtherFixedCostByPeriod({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "OtherFixedCostByPeriod"];

                var range = sheet.Cells[sheet.Dimension.Address];
                return range.ToCollection<OtherFixedCostByPeriod>();
            }
            else return null;
        }

        public IEnumerable<OtherPercentageCost> GetOtherPercentageCost(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\OtherPercentageCost({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "OtherPercentageCost"];

                var range = sheet.Cells[sheet.Dimension.Address];

                return range.ToCollection<OtherPercentageCost>();
            }
            else return null;
        }

        public IEnumerable<SalesValueByCategory> GetSalesValueByCategory(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\SalesValueByCategory({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "SalesValueByCategory"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "PricePerSqm")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "SquareMeters")
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
                    PricePerSqm = row.Field<decimal>("PricePerSqm"),
                    SquareMeters = row.Field<decimal>("SquareMeters"),
                    Sold = row.Field<decimal>("Sold")
                });
            }
            else return null;
        }

        public IEnumerable<SalesValueByPeriod> GetSalesValueByPeriod(string complexProperty)
        {
            FileInfo fileInfo = new(filePath + $"\\SalesValueByPeriod({complexProperty}).xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "SalesValueByPeriod"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "SalesTargetInSqm")
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
                    SalesTargetInSqm = row.Field<decimal>("SalesTargetInSqm"),
                    Quarter = row.Field<int>("Quarter"),
                    Year = row.Field<int>("Year")
                });
            }
            else return null;
        }
    }
}
