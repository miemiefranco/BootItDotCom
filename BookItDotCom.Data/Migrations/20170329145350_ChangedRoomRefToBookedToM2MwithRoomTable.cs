using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookItDotCom.Data.Migrations
{
    public partial class ChangedRoomRefToBookedToM2MwithRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookedRoomReferences_RoomRefId",
                table: "BookedRoomReferences");

            migrationBuilder.CreateIndex(
                name: "IX_BookedRoomReferences_RoomRefId",
                table: "BookedRoomReferences",
                column: "RoomRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookedRoomReferences_RoomRefId",
                table: "BookedRoomReferences");

            migrationBuilder.CreateIndex(
                name: "IX_BookedRoomReferences_RoomRefId",
                table: "BookedRoomReferences",
                column: "RoomRefId",
                unique: true);
        }
    }
}
