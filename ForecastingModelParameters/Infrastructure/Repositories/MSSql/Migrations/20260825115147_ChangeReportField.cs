using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComplexProperty",
                schema: "params",
                table: "ReportFields",
                newName: "ReportSheet");

            migrationBuilder.AddColumn<int>(
                name: "LineNumber",
                schema: "params",
                table: "ReportFields",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineNumber",
                schema: "params",
                table: "ReportFields");

            migrationBuilder.RenameColumn(
                name: "ReportSheet",
                schema: "params",
                table: "ReportFields",
                newName: "ComplexProperty");
        }
    }
}
