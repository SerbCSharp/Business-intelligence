using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTables : Migration
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
                name: "DimLoanTerms",
                schema: "params");

            migrationBuilder.DropTable(
                name: "DimProperties",
                schema: "params");

            migrationBuilder.DropTable(
                name: "FactProjectForecasts",
                schema: "params");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DimComplexProperties",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowDirection = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimLoanTerms",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimLoanTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimProperties",
                schema: "params",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ComplexPropertyId = table.Column<int>(type: "int", nullable: false),
                    CostItemId = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false),
                    LoanTermId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactProjectForecasts", x => x.Id);
                });
        }
    }
}
