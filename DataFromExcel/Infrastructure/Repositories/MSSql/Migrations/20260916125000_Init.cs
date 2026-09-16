using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaOfActivityPayments",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectOrIndirect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOfActivityPayments", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectOfSaleInContracts",
                columns: table => new
                {
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralContractorMarkup = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOfSaleInContracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectOfSaleInPurchasePayments",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOfSaleInPurchasePayments", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractDebit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractCredit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                });

            migrationBuilder.CreateTable(
                name: "TotalFloorAreas",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApartmentArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalFloorAreas", x => x.RowId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaOfActivityPayments");

            migrationBuilder.DropTable(
                name: "ObjectOfSaleInContracts");

            migrationBuilder.DropTable(
                name: "ObjectOfSaleInPurchasePayments");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "TotalFloorAreas");
        }
    }
}
