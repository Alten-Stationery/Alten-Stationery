using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterFieldRefillIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Refills_RefillId",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "RefillId",
                table: "Alerts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Refills_RefillId",
                table: "Alerts",
                column: "RefillId",
                principalTable: "Refills",
                principalColumn: "RefillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Refills_RefillId",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "RefillId",
                table: "Alerts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Refills_RefillId",
                table: "Alerts",
                column: "RefillId",
                principalTable: "Refills",
                principalColumn: "RefillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
