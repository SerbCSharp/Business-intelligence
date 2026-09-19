using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class RedidOperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractCredit",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "ContractDebit",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Operations",
                newName: "ContractId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Operations",
                newName: "Debit");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Operations",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "Operations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "Debit",
                table: "Operations",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ContractId",
                table: "Operations",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Operations",
                newName: "OperationId");

            migrationBuilder.AddColumn<string>(
                name: "ContractCredit",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractDebit",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
