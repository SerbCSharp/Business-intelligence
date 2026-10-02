using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaOfActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaOfActivity",
                table: "ObjectOfSaleInContracts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaOfActivity",
                table: "ObjectOfSaleInContracts");
        }
    }
}
