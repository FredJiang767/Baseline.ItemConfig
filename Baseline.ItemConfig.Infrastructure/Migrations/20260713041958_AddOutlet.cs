using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baseline.ItemConfig.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddOutlet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutletType",
                columns: table => new
                {
                    OutletTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutletType", x => x.OutletTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UiTab",
                columns: table => new
                {
                    UiTabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiTab", x => x.UiTabId);
                });

            migrationBuilder.CreateTable(
                name: "Outlet",
                columns: table => new
                {
                    OutletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutletTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlet", x => x.OutletId);
                    table.ForeignKey(
                        name: "FK_Outlet_OutletType_OutletTypeId",
                        column: x => x.OutletTypeId,
                        principalTable: "OutletType",
                        principalColumn: "OutletTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UiSubTab",
                columns: table => new
                {
                    UiSubTabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UiTabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiSubTab", x => x.UiSubTabId);
                    table.ForeignKey(
                        name: "FK_UiSubTab_UiTab_UiTabId",
                        column: x => x.UiTabId,
                        principalTable: "UiTab",
                        principalColumn: "UiTabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemYear = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UiSubTabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UiTabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_UiSubTab_UiSubTabId",
                        column: x => x.UiSubTabId,
                        principalTable: "UiSubTab",
                        principalColumn: "UiSubTabId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_UiTab_UiTabId",
                        column: x => x.UiTabId,
                        principalTable: "UiTab",
                        principalColumn: "UiTabId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutletTypeItem",
                columns: table => new
                {
                    OutletTypeItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutletTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutletTypeItem", x => x.OutletTypeItemId);
                    table.ForeignKey(
                        name: "FK_OutletTypeItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutletTypeItem_OutletType_OutletTypeId",
                        column: x => x.OutletTypeId,
                        principalTable: "OutletType",
                        principalColumn: "OutletTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemYear_ItemNumber",
                table: "Item",
                columns: new[] { "ItemYear", "ItemNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UiSubTabId",
                table: "Item",
                column: "UiSubTabId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UiTabId",
                table: "Item",
                column: "UiTabId");

            migrationBuilder.CreateIndex(
                name: "IX_Outlet_OutletTypeId",
                table: "Outlet",
                column: "OutletTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutletTypeItem_ItemId",
                table: "OutletTypeItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutletTypeItem_OutletTypeId_ItemId",
                table: "OutletTypeItem",
                columns: new[] { "OutletTypeId", "ItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UiSubTab_UiTabId",
                table: "UiSubTab",
                column: "UiTabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outlet");

            migrationBuilder.DropTable(
                name: "OutletTypeItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "OutletType");

            migrationBuilder.DropTable(
                name: "UiSubTab");

            migrationBuilder.DropTable(
                name: "UiTab");
        }
    }
}
