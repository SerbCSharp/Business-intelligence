using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherCostByPeriods",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoneyIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCostByPeriods", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "OtherCosts",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoneyIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentageOfMoneyOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCosts", x => x.RowId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherCostByPeriods",
                schema: "params");

            migrationBuilder.DropTable(
                name: "OtherCosts",
                schema: "params");
        }
    }
}
