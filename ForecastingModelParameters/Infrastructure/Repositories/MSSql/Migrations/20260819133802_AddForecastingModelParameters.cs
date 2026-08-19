using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddForecastingModelParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "params");

            migrationBuilder.RenameTable(
                name: "ConstructionCostByProperties",
                schema: "Parameters",
                newName: "ConstructionCostByProperties",
                newSchema: "params");

            migrationBuilder.CreateTable(
                name: "ConstructionCostByPeriods",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstructionCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentageOfCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionCostByPeriods", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "SalesValueByCategories",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sold = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesValueByPeriods", x => x.RowId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionCostByPeriods",
                schema: "params");

            migrationBuilder.DropTable(
                name: "SalesValueByCategories",
                schema: "params");

            migrationBuilder.DropTable(
                name: "SalesValueByPeriods",
                schema: "params");

            migrationBuilder.EnsureSchema(
                name: "Parameters");

            migrationBuilder.RenameTable(
                name: "ConstructionCostByProperties",
                schema: "params",
                newName: "ConstructionCostByProperties",
                newSchema: "Parameters");
        }
    }
}
