using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class Redesignedstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowDirection = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Year = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissioningOfResidentialProperty = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexPropertyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactProjectForecasts", x => x.Id);
                });
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
                name: "DimProperties",
                schema: "params");

            migrationBuilder.DropTable(
                name: "FactProjectForecasts",
                schema: "params");
        }
    }
}
