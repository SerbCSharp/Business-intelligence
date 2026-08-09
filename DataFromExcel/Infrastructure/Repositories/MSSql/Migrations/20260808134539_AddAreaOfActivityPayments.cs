using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaOfActivityPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaOfActivityPayments",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectOrIndirect = table.Column<bool>(type: "bit", nullable: false),
                    ContractIdIncome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOfActivityPayments", x => x.DocumentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaOfActivityPayments");
        }
    }
}
