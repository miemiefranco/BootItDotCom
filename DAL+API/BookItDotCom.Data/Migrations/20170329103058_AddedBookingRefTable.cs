using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookItDotCom.Data.Migrations
{
    public partial class AddedBookingRefTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookedRoomRefId",
                table: "Room",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Room",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoomRefId",
                table: "Room",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookedRoomReference",
                columns: table => new
                {
                    BookedRoomReferenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedRoomReference", x => x.BookedRoomReferenceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookedRoomRefId",
                table: "Room",
                column: "BookedRoomRefId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_BookedRoomReference_BookedRoomRefId",
                table: "Room",
                column: "BookedRoomRefId",
                principalTable: "BookedRoomReference",
                principalColumn: "BookedRoomReferenceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_BookedRoomReference_BookedRoomRefId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "BookedRoomReference");

            migrationBuilder.DropIndex(
                name: "IX_Room_BookedRoomRefId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "BookedRoomRefId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomRefId",
                table: "Room");
        }
    }
}
