using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazi_demo.Data.Migrations
{
    public partial class password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerEMBG",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEMBG",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerEMBG",
                table: "Bookings",
                column: "CustomerEMBG",
                principalTable: "Customers",
                principalColumn: "EMBG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerEMBG",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEMBG",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerEMBG",
                table: "Bookings",
                column: "CustomerEMBG",
                principalTable: "Customers",
                principalColumn: "EMBG",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
