using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class ReworkingForecastingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactProjectForecasts",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplexPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    CostItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactProjectForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimComplexProperties",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectForecastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimComplexProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimComplexProperties_FactProjectForecasts_ProjectForecastId",
                        column: x => x.ProjectForecastId,
                        principalSchema: "params",
                        principalTable: "FactProjectForecasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimCostItems",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowDirection = table.Column<bool>(type: "bit", nullable: false),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectForecastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCostItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimCostItems_FactProjectForecasts_ProjectForecastId",
                        column: x => x.ProjectForecastId,
                        principalSchema: "params",
                        principalTable: "FactProjectForecasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimDates",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    ProjectForecastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimDates_FactProjectForecasts_ProjectForecastId",
                        column: x => x.ProjectForecastId,
                        principalSchema: "params",
                        principalTable: "FactProjectForecasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimLoanTerms",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscrowFunding = table.Column<double>(type: "float", nullable: false),
                    InterestPayable = table.Column<double>(type: "float", nullable: false),
                    Principal = table.Column<double>(type: "float", nullable: false),
                    KeyRate = table.Column<double>(type: "float", nullable: false),
                    ProjectForecastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimLoanTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimLoanTerms_FactProjectForecasts_ProjectForecastId",
                        column: x => x.ProjectForecastId,
                        principalSchema: "params",
                        principalTable: "FactProjectForecasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimProperties",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissioningOfResidentialProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectForecastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimProperties_FactProjectForecasts_ProjectForecastId",
                        column: x => x.ProjectForecastId,
                        principalSchema: "params",
                        principalTable: "FactProjectForecasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DimComplexProperties_ProjectForecastId",
                schema: "params",
                table: "DimComplexProperties",
                column: "ProjectForecastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimCostItems_ProjectForecastId",
                schema: "params",
                table: "DimCostItems",
                column: "ProjectForecastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimDates_ProjectForecastId",
                schema: "params",
                table: "DimDates",
                column: "ProjectForecastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimLoanTerms_ProjectForecastId",
                schema: "params",
                table: "DimLoanTerms",
                column: "ProjectForecastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimProperties_ProjectForecastId",
                schema: "params",
                table: "DimProperties",
                column: "ProjectForecastId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DimLoanTerms",
                schema: "params");

            migrationBuilder.DropTable(
                name: "DimProperties",
                schema: "params");

            migrationBuilder.DropTable(
                name: "FactProjectForecasts",
                schema: "params");
        }
    }
}
