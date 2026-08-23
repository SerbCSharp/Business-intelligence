using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddParameterHasPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalesValue",
                schema: "params",
                table: "SalesValueByPeriods",
                newName: "SalesTargetInSqm");

            migrationBuilder.RenameColumn(
                name: "SalesValue",
                schema: "params",
                table: "SalesValueByCategories",
                newName: "SquareMeters");

            migrationBuilder.RenameColumn(
                name: "ConstructionCost",
                schema: "params",
                table: "ConstructionCostByProperties",
                newName: "SquareMeters");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerSqm",
                schema: "params",
                table: "SalesValueByCategories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "ParameterHasPeriod",
                schema: "params",
                table: "ReportFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PlannedCostPerSqm",
                schema: "params",
                table: "ConstructionCostByProperties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "CommissioningOfResidentialProperty",
                schema: "params",
                table: "ConstructionCostByPeriods",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerSqm",
                schema: "params",
                table: "SalesValueByCategories");

            migrationBuilder.DropColumn(
                name: "ParameterHasPeriod",
                schema: "params",
                table: "ReportFields");

            migrationBuilder.DropColumn(
                name: "PlannedCostPerSqm",
                schema: "params",
                table: "ConstructionCostByProperties");

            migrationBuilder.DropColumn(
                name: "CommissioningOfResidentialProperty",
                schema: "params",
                table: "ConstructionCostByPeriods");

            migrationBuilder.RenameColumn(
                name: "SalesTargetInSqm",
                schema: "params",
                table: "SalesValueByPeriods",
                newName: "SalesValue");

            migrationBuilder.RenameColumn(
                name: "SquareMeters",
                schema: "params",
                table: "SalesValueByCategories",
                newName: "SalesValue");

            migrationBuilder.RenameColumn(
                name: "SquareMeters",
                schema: "params",
                table: "ConstructionCostByProperties",
                newName: "ConstructionCost");
        }
    }
}
