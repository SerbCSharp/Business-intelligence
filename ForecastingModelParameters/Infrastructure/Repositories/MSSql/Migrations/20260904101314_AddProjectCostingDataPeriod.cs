using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectCostingDataPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCostingDataPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCostingDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Quarter = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCostingDataPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCostingDataPeriods_ProjectCostingDatas_ProjectCostingDataId",
                        column: x => x.ProjectCostingDataId,
                        principalTable: "ProjectCostingDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCostingDataPeriods_ProjectCostingDataId",
                table: "ProjectCostingDataPeriods",
                column: "ProjectCostingDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCostingDataPeriods");
        }
    }
}
