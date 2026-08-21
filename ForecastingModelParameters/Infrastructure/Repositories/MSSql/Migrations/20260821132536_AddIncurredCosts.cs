using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddIncurredCosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherCostByPeriods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncurredCosts",
                schema: "params",
                table: "OtherCostByPeriods");
        }
    }
}
