using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baseline.ItemConfig.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddRootItemNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RootItemNumberId",
                table: "Item",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RootItemNumber",
                columns: table => new
                {
                    RootItemNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootItemNumber", x => x.RootItemNumberId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_RootItemNumberId",
                table: "Item",
                column: "RootItemNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_RootItemNumber_Number",
                table: "RootItemNumber",
                column: "Number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_RootItemNumber_RootItemNumberId",
                table: "Item",
                column: "RootItemNumberId",
                principalTable: "RootItemNumber",
                principalColumn: "RootItemNumberId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_RootItemNumber_RootItemNumberId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "RootItemNumber");

            migrationBuilder.DropIndex(
                name: "IX_Item_RootItemNumberId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RootItemNumberId",
                table: "Item");
        }
    }
}
