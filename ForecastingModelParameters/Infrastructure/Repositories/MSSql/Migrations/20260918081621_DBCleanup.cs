using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class DBCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DimComplexProperties",
                schema: "params");

            migrationBuilder.DropTable(
                name: "DimCostItems",
                schema: "params");

            migrationBuilder.DropTable(
                name: "DimDates",
                schema: "params");

            migrationBuilder.DropTable(
                name: "DimProperties",
                schema: "params");

            migrationBuilder.DropTable(
                name: "FactProjectForecasts",
                schema: "params");

            migrationBuilder.DropTable(
                name: "ProjectCostingDataPeriods",
                schema: "params");

            migrationBuilder.DropTable(
                name: "ReportFields",
                schema: "params");

            migrationBuilder.DropTable(
                name: "ProjectCostingDatas",
                schema: "params");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "params");

            migrationBuilder.CreateTable(
                name: "DimComplexProperties",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimComplexProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimCostItems",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlowDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCostItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimDates",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimProperties",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommissioningOfResidentialProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactProjectForecasts",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComplexPropertyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactProjectForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCostingDatas",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fact = table.Column<double>(type: "float", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCostingDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportFields",
                schema: "params",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionCostForecast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parameter = table.Column<bool>(type: "bit", nullable: false),
                    ReportSheet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportFields", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCostingDataPeriods",
                schema: "params",
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
                        principalSchema: "params",
                        principalTable: "ProjectCostingDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCostingDataPeriods_ProjectCostingDataId",
                schema: "params",
                table: "ProjectCostingDataPeriods",
                column: "ProjectCostingDataId");
        }
    }
}
