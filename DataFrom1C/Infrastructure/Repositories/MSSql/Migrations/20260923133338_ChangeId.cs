using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFrom1C.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class ChangeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "SalesGoodsAndServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "PurchaseGoodsAndServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "PaymentsDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "MoreInformations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "ConstructionCompletionCertificates",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SalesGoodsAndServices",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PurchaseGoodsAndServices",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentsDetails",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MoreInformations",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConstructionCompletionCertificates",
                newName: "RowId");
        }
    }
}
