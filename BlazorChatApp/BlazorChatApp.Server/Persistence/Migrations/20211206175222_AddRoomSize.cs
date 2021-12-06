using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorChatApp.Server.Persistence.Migrations
{
    public partial class AddRoomSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomSize",
                table: "chat_room",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomSize",
                table: "chat_room");
        }
    }
}
