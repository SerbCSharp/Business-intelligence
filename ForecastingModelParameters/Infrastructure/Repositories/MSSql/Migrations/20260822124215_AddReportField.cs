using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddReportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sheet",
                schema: "params",
                table: "OtherCosts");

            migrationBuilder.RenameColumn(
                name: "MoneyOut",
                schema: "params",
                table: "OtherCostByPeriods",
                newName: "PercentageOfCosts");

            migrationBuilder.RenameColumn(
                name: "MoneyIn",
                schema: "params",
                table: "OtherCostByPeriods",
                newName: "Amount");

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOfCosts",
                schema: "params",
                table: "ConstructionCostByPeriods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ReportFields",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportFields", x => x.RowId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportFields",
                schema: "params");

            migrationBuilder.DropColumn(
                name: "PercentageOfCosts",
                schema: "params",
                table: "ConstructionCostByPeriods");

            migrationBuilder.RenameColumn(
                name: "PercentageOfCosts",
                schema: "params",
                table: "OtherCostByPeriods",
                newName: "MoneyOut");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "params",
                table: "OtherCostByPeriods",
                newName: "MoneyIn");

            migrationBuilder.AddColumn<string>(
                name: "Sheet",
                schema: "params",
                table: "OtherCosts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
