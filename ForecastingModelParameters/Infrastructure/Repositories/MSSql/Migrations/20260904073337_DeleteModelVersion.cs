using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class DeleteModelVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionCostByPeriods",
                schema: "params");

            migrationBuilder.DropTable(
                name: "ConstructionCostByProperties",
                schema: "params");

            migrationBuilder.DropTable(
                name: "OtherFixedCostByPeriods",
                schema: "params");

            migrationBuilder.DropTable(
                name: "OtherFixedCosts",
                schema: "params");

            migrationBuilder.DropTable(
                name: "OtherPercentageCostByPeriods",
                schema: "params");

            migrationBuilder.DropTable(
                name: "OtherPercentageCosts",
                schema: "params");

            migrationBuilder.DropTable(
                name: "SalesValueByCategories",
                schema: "params");

            migrationBuilder.DropTable(
                name: "SalesValueByPeriods",
                schema: "params");

            migrationBuilder.DropColumn(
                name: "PercentageOrFixed",
                schema: "params",
                table: "ReportFields");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PercentageOrFixed",
                schema: "params",
                table: "ReportFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ConstructionCostByPeriods",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommissioningOfResidentialProperty = table.Column<bool>(type: "bit", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstructionCost = table.Column<double>(type: "float", nullable: false),
                    PercentageOfCosts = table.Column<double>(type: "float(18)", precision: 18, scale: 4, nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quarter = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionCostByPeriods", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionCostByProperties",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncurredCosts = table.Column<double>(type: "float", nullable: false),
                    PlannedCostPerSqm = table.Column<double>(type: "float", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SquareMeters = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionCostByProperties", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "OtherFixedCostByPeriods",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quarter = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherFixedCostByPeriods", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "OtherFixedCosts",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncurredCosts = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherFixedCosts", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "OtherPercentageCostByPeriods",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageOfCosts = table.Column<double>(type: "float(18)", precision: 18, scale: 4, nullable: false),
                    Quarter = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPercentageCostByPeriods", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "OtherPercentageCosts",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageOfCosts = table.Column<double>(type: "float(18)", precision: 18, scale: 4, nullable: false),
                    ResidentialProperty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPercentageCosts", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "SalesValueByCategories",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerSqm = table.Column<double>(type: "float", nullable: false),
                    ResidentialProperty = table.Column<bool>(type: "bit", nullable: false),
                    Sold = table.Column<double>(type: "float", nullable: false),
                    SquareMeters = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesValueByCategories", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "SalesValueByPeriods",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerSqm = table.Column<double>(type: "float", nullable: false),
                    Quarter = table.Column<double>(type: "float", nullable: false),
                    SalesTargetInSqm = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesValueByPeriods", x => x.RowId);
                });
        }
    }
}
