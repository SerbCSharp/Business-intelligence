using DataFromExcel.Application.Interfaces;
using DataFromExcel.Domain;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using System.Data;

namespace DataFromExcel.Infrastructure.DataSource.Excel
{
    public class GetDataExcel : IGetData
    {
        private readonly FilePathConfiguration _filePathConfiguration;
        private readonly string filePath;
        private readonly string companyId;

        public GetDataExcel(IOptions<FilePathConfiguration> filePathConfiguration)
        {
            _filePathConfiguration = filePathConfiguration.Value;
            filePath = _filePathConfiguration.FilePath;
            companyId = _filePathConfiguration.CompanyId;
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
        }

        public IEnumerable<ObjectOfSaleInPurchasePayment> ObjectOfSaleInPurchasePayment()
        {
            FileInfo fileInfo = new(filePath + "\\ObjectOfSaleInPurchasePayment.xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "ObjectOfSaleInPurchasePayment"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
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

                return dataTable.AsEnumerable().Select(row => new ObjectOfSaleInPurchasePayment
                {
                    DocumentId = row.Field<string>("DocumentId"),
                    ContractId = row.Field<string>("ContractId"),
                    Property = row.Field<string>("Property"),
                    CostItem = row.Field<string>("CostItem"),
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    CompanyId = row.Field<string>("CompanyId")
                }).Where(x => x.CompanyId == companyId);
            }
            else return null;
        }

        public IEnumerable<ObjectOfSaleInContract> ObjectOfSaleInContract()
        {
            FileInfo fileInfo = new(filePath + "\\ObjectOfSaleInContract.xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "ObjectOfSaleInContract"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "Amount")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "GeneralContractorMarkup")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "Retainage")
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

                return dataTable.AsEnumerable().Select(row => new ObjectOfSaleInContract
                {
                    ContractId = row.Field<string>("ContractId"),
                    Property = row.Field<string>("Property"),
                    CostItem = row.Field<string>("CostItem"),
                    Amount = row.Field<decimal>("Amount"),
                    ComplexProperty = row.Field<string>("ComplexProperty"),
                    GeneralContractorMarkup = row.Field<decimal>("GeneralContractorMarkup"),
                    Retainage = row.Field<decimal>("Retainage"),
                    AreaOfActivity = row.Field<string>("AreaOfActivity"),
                    CompanyId = row.Field<string>("CompanyId")
                }).Where(x => x.CompanyId == companyId);
            }
            else return null;
        }

        public IEnumerable<TotalFloorArea> TotalFloorArea()
        {
            FileInfo fileInfo = new(filePath + "\\TotalFloorArea.xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "TotalFloorArea"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() is "TotalArea" or "ApartmentArea" or "СommercialArea")
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

                return dataTable.AsEnumerable().Select(row => new TotalFloorArea
                {
                    TotalArea = row.Field<decimal>("TotalArea"),
                    ApartmentArea = row.Field<decimal>("ApartmentArea"),
                    Property = row.Field<string>("Property"),
                    CompanyId = row.Field<string>("CompanyId")
                }).Where(x => x.CompanyId == companyId);
            }
            else return null;
        }

        public IEnumerable<AreaOfActivityPayment> AreaOfActivity()
        {
            FileInfo fileInfo = new(filePath + "\\AreaOfActivity.xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "AreaOfActivity"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "Percent")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "DirectOrIndirect")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(bool));
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

                return dataTable.AsEnumerable().Select(row => new AreaOfActivityPayment
                {
                    DocumentId = row.Field<string>("DocumentId"),
                    Percent = row.Field<decimal>("Percent"),
                    TypeOfActivity = row.Field<string>("TypeOfActivity"),
                    AreaOfActivity = row.Field<string>("AreaOfActivity"),
                    DirectOrIndirect = row.Field<bool>("DirectOrIndirect"),
                    CompanyId = row.Field<string>("CompanyId")
                }).Where(x => x.CompanyId == companyId);
            }
            else return null;
        }

        public IEnumerable<AccountingTransaction> AccountingTransaction() // Бухгалтерские операции
        {
            FileInfo fileInfo = new(filePath + "\\AccountingTransaction.xlsx");
            if (fileInfo.Exists)
            {
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets[Name: "AccountingTransaction"];
                DataTable dataTable = new();

                for (int i = sheet.Dimension.Start.Column; i <= sheet.Dimension.End.Column; i++)
                {
                    if (sheet.Cells[1, i].Value.ToString() == "Дата")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(DateTime));
                    else if (sheet.Cells[1, i].Value.ToString() == "Debit")
                        dataTable.Columns.Add(sheet.Cells[1, i].Value.ToString(), typeof(decimal));
                    else if (sheet.Cells[1, i].Value.ToString() == "Credit")
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

                return dataTable.AsEnumerable().Select(row => new AccountingTransaction
                {
                    Id = row.Field<string>("Код из 1С"),
                    Date = row.Field<DateTime>("Дата"),
                    Debit = row.Field<decimal>("Debit"),
                    Credit = row.Field<decimal>("Credit"),
                    ContractId = row.Field<string>("ContractId"),
                    CompanyId = row.Field<string>("CompanyId")
                }).Where(x => x.CompanyId == companyId);
            }
            else return null;
        }
    }
}
