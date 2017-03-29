using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookItDotCom.Data.Migrations
{
    public partial class AddedRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Floor = table.Column<string>(nullable: true),
                    HotelOutletRefId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: true),
                    RoomType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_HotelOutlets_HotelOutletRefId",
                        column: x => x.HotelOutletRefId,
                        principalTable: "HotelOutlets",
                        principalColumn: "HotelOutletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelOutletRefId",
                table: "Room",
                column: "HotelOutletRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
