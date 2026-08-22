using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseOptimization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyIn",
                schema: "params",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherCostByPeriods");

            migrationBuilder.DropColumn(
                name: "Sheet",
                schema: "params",
                table: "OtherCostByPeriods");

            migrationBuilder.RenameColumn(
                name: "MoneyOut",
                schema: "params",
                table: "OtherCosts",
                newName: "IncurredCosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherCosts",
                newName: "MoneyOut");

            migrationBuilder.AddColumn<decimal>(
                name: "MoneyIn",
                schema: "params",
                table: "OtherCosts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherCostByPeriods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Sheet",
                schema: "params",
                table: "OtherCostByPeriods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
