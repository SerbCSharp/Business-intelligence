using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeOperationInSalesPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOperation",
                table: "SalesPayments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOperation",
                table: "SalesPayments");
        }
    }
}
