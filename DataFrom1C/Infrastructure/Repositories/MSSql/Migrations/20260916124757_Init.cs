using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingEntries",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountDebitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingEntries", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "AccountingTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashFlowItems",
                columns: table => new
                {
                    CashFlowItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowItems", x => x.CashFlowItemId);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionCompletionCertificates",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionCompletionCertificates", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ContractorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeContract = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "CostItems",
                columns: table => new
                {
                    CostItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostItems", x => x.CostItemId);
                });

            migrationBuilder.CreateTable(
                name: "MoreInformations",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoreInformations", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsDetails",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsDetails", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "PlanOfAccounts",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanOfAccounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    ProductGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsAndServices",
                columns: table => new
                {
                    ProductAndServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsAndServices", x => x.ProductAndServiceId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseGoodsAndServices",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAndServiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseGoodsAndServices", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayments",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashFlowItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePayments", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "SalesGoodsAndServices",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAndServiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesGoodsAndServices", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "SalesPayments",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashFlowItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPayments", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingEntries");

            migrationBuilder.DropTable(
                name: "AccountingTransactions");

            migrationBuilder.DropTable(
                name: "CashFlowItems");

            migrationBuilder.DropTable(
                name: "ConstructionCompletionCertificates");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CostItems");

            migrationBuilder.DropTable(
                name: "MoreInformations");

            migrationBuilder.DropTable(
                name: "PaymentsDetails");

            migrationBuilder.DropTable(
                name: "PlanOfAccounts");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ProductsAndServices");

            migrationBuilder.DropTable(
                name: "PurchaseGoodsAndServices");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            migrationBuilder.DropTable(
                name: "PurchasePayments");

            migrationBuilder.DropTable(
                name: "SalesGoodsAndServices");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "SalesPayments");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
