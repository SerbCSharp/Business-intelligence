using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFromExcel.Infrastructure.Repositories.MSSql.Migrations
{
    /// <inheritdoc />
    public partial class AddRowIdInAreaOfActivityPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaOfActivityPayments",
                table: "AreaOfActivityPayments");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AreaOfActivityPayments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "RowId",
                table: "AreaOfActivityPayments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaOfActivityPayments",
                table: "AreaOfActivityPayments",
                column: "RowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaOfActivityPayments",
                table: "AreaOfActivityPayments");

            migrationBuilder.DropColumn(
                name: "RowId",
                table: "AreaOfActivityPayments");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AreaOfActivityPayments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaOfActivityPayments",
                table: "AreaOfActivityPayments",
                column: "DocumentId");
        }
    }
}
