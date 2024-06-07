using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRefill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Refill_RefillId",
                table: "Alerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Refill",
                table: "Refill");

            migrationBuilder.RenameTable(
                name: "Refill",
                newName: "Refills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefillDate",
                table: "Refills",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Refills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Refills",
                table: "Refills",
                column: "RefillId");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refills_UserID",
                table: "Refills",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Refills_RefillId",
                table: "Alerts",
                column: "RefillId",
                principalTable: "Refills",
                principalColumn: "RefillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Refills_User_UserID",
                table: "Refills",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Refills_RefillId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Refills_User_UserID",
                table: "Refills");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Refills",
                table: "Refills");

            migrationBuilder.DropIndex(
                name: "IX_Refills_UserID",
                table: "Refills");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Refills");

            migrationBuilder.RenameTable(
                name: "Refills",
                newName: "Refill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefillDate",
                table: "Refill",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Refill",
                table: "Refill",
                column: "RefillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Refill_RefillId",
                table: "Alerts",
                column: "RefillId",
                principalTable: "Refill",
                principalColumn: "RefillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
