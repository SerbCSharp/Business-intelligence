using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddComplexProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComplexProperty",
                table: "ObjectOfSaleInPurchasePayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplexProperty",
                table: "ObjectOfSaleInPurchaseInvoices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplexProperty",
                table: "ObjectOfSaleInPurchasePayments");

            migrationBuilder.DropColumn(
                name: "ComplexProperty",
                table: "ObjectOfSaleInPurchaseInvoices");
        }
    }
}
