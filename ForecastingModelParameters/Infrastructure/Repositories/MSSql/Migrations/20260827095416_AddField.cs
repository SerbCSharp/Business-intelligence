using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field",
                schema: "params",
                table: "ReportFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportSheet",
                schema: "params",
                table: "ReportFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PercentageOfCosts",
                schema: "params",
                table: "OtherPercentageCosts",
                type: "float(18)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<double>(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherFixedCosts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Field",
                schema: "params",
                table: "OtherFixedCosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Year",
                schema: "params",
                table: "OtherFixedCostByPeriods",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Quarter",
                schema: "params",
                table: "OtherFixedCostByPeriods",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                schema: "params",
                table: "OtherFixedCostByPeriods",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field",
                schema: "params",
                table: "ReportFields");

            migrationBuilder.DropColumn(
                name: "ReportSheet",
                schema: "params",
                table: "ReportFields");

            migrationBuilder.DropColumn(
                name: "Field",
                schema: "params",
                table: "OtherFixedCosts");

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentageOfCosts",
                schema: "params",
                table: "OtherPercentageCosts",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherFixedCosts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                schema: "params",
                table: "OtherFixedCostByPeriods",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Quarter",
                schema: "params",
                table: "OtherFixedCostByPeriods",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "params",
                table: "OtherFixedCostByPeriods",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
