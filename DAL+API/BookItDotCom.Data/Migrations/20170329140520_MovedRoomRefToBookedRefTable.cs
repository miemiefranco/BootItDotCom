using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookItDotCom.Data.Migrations
{
    public partial class MovedRoomRefToBookedRefTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_BookedRoomReference_BookedRoomRefId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_HotelOutlets_HotelOutletRefId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_BookedRoomRefId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedRoomReference",
                table: "BookedRoomReference");

            migrationBuilder.DropColumn(
                name: "BookedRoomRefId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomRefId",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "BookedRoomReference",
                newName: "BookedRoomReferences");

            migrationBuilder.RenameIndex(
                name: "IX_Room_HotelOutletRefId",
                table: "Rooms",
                newName: "IX_Rooms_HotelOutletRefId");

            migrationBuilder.AddColumn<int>(
                name: "RoomRefId",
                table: "BookedRoomReferences",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedRoomReferences",
                table: "BookedRoomReferences",
                column: "BookedRoomReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedRoomReferences_RoomRefId",
                table: "BookedRoomReferences",
                column: "RoomRefId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoomReferences_Rooms_RoomRefId",
                table: "BookedRoomReferences",
                column: "RoomRefId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HotelOutlets_HotelOutletRefId",
                table: "Rooms",
                column: "HotelOutletRefId",
                principalTable: "HotelOutlets",
                principalColumn: "HotelOutletId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoomReferences_Rooms_RoomRefId",
                table: "BookedRoomReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HotelOutlets_HotelOutletRefId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedRoomReferences",
                table: "BookedRoomReferences");

            migrationBuilder.DropIndex(
                name: "IX_BookedRoomReferences_RoomRefId",
                table: "BookedRoomReferences");

            migrationBuilder.DropColumn(
                name: "RoomRefId",
                table: "BookedRoomReferences");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "BookedRoomReferences",
                newName: "BookedRoomReference");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelOutletRefId",
                table: "Room",
                newName: "IX_Room_HotelOutletRefId");

            migrationBuilder.AddColumn<int>(
                name: "BookedRoomRefId",
                table: "Room",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomRefId",
                table: "Room",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedRoomReference",
                table: "BookedRoomReference",
                column: "BookedRoomReferenceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Room_HotelOutlets_HotelOutletRefId",
                table: "Room",
                column: "HotelOutletRefId",
                principalTable: "HotelOutlets",
                principalColumn: "HotelOutletId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
