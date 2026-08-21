using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class FinishedProjectForecastingModelParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentageOfMoneyOut",
                schema: "params",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "PercentageOfCosts",
                schema: "params",
                table: "ConstructionCostByPeriods");

            migrationBuilder.AddColumn<string>(
                name: "Sheet",
                schema: "params",
                table: "OtherCosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sheet",
                schema: "params",
                table: "OtherCostByPeriods",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sheet",
                schema: "params",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "Sheet",
                schema: "params",
                table: "OtherCostByPeriods");

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOfMoneyOut",
                schema: "params",
                table: "OtherCosts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOfCosts",
                schema: "params",
                table: "ConstructionCostByPeriods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
