using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baseline.ItemConfig.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddHuntTypeLicenseYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HuntTypeLicenseYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterHuntTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntTypeLicenseYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuntTypeLicenseYears_MasterHuntTypes_MasterHuntTypeId",
                        column: x => x.MasterHuntTypeId,
                        principalTable: "MasterHuntTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HuntTypeLicenseYears_MasterHuntTypeId_Year",
                table: "HuntTypeLicenseYears",
                columns: new[] { "MasterHuntTypeId", "Year" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuntTypeLicenseYears");
        }
    }
}
