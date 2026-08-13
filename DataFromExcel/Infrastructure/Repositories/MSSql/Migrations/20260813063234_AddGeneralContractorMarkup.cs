using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneralContractorMarkup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GeneralContractorMarkup",
                table: "ObjectOfSaleInContracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralContractorMarkup",
                table: "ObjectOfSaleInContracts");
        }
    }
}
