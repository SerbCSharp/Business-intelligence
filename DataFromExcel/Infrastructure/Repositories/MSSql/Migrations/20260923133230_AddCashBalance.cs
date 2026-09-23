using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddCashBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "TotalFloorAreas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "AreaOfActivityPayments",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "CashBalances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBalances", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashBalances");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TotalFloorAreas",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AreaOfActivityPayments",
                newName: "RowId");
        }
    }
}
