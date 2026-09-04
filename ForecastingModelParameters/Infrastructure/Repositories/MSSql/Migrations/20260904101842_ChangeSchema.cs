using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProjectCostingDatas",
                newName: "ProjectCostingDatas",
                newSchema: "params");

            migrationBuilder.RenameTable(
                name: "ProjectCostingDataPeriods",
                newName: "ProjectCostingDataPeriods",
                newSchema: "params");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProjectCostingDatas",
                schema: "params",
                newName: "ProjectCostingDatas");

            migrationBuilder.RenameTable(
                name: "ProjectCostingDataPeriods",
                schema: "params",
                newName: "ProjectCostingDataPeriods");
        }
    }
}
