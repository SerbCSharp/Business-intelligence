using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCommissioningOfResidentialProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissioningOfResidentialProperty",
                schema: "params",
                table: "ProjectCostingDataPeriods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommissioningOfResidentialProperty",
                schema: "params",
                table: "ProjectCostingDataPeriods",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
