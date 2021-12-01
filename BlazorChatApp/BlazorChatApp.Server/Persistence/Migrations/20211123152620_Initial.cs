using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorChatApp.Server.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat_room",
                columns: table => new
                {
                    chat_room_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chat_room_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_private = table.Column<bool>(type: "boolean", nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_room", x => x.chat_room_id);
                });

            migrationBuilder.CreateTable(
                name: "chat_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chat_user_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "chat_room_user",
                columns: table => new
                {
                    chat_room_user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chat_room_id = table.Column<int>(type: "integer", nullable: true),
                    chat_user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_room_user", x => x.chat_room_user_id);
                    table.ForeignKey(
                        name: "chat_room_user_chat_room_id_fkey",
                        column: x => x.chat_room_id,
                        principalTable: "chat_room",
                        principalColumn: "chat_room_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "chat_room_user_chat_user_id_fkey",
                        column: x => x.chat_user_id,
                        principalTable: "chat_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chat_message",
                columns: table => new
                {
                    chat_message_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chat_room_user_id = table.Column<int>(type: "integer", nullable: true),
                    chat_message_content = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_message", x => x.chat_message_id);
                    table.ForeignKey(
                        name: "chat_message_chat_room_user_id_fkey",
                        column: x => x.chat_room_user_id,
                        principalTable: "chat_room_user",
                        principalColumn: "chat_room_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chat_message_chat_room_user_id",
                table: "chat_message",
                column: "chat_room_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_room_user_chat_room_id",
                table: "chat_room_user",
                column: "chat_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_room_user_chat_user_id",
                table: "chat_room_user",
                column: "chat_user_id");

            migrationBuilder.CreateIndex(
                name: "UsernameConstraint",
                table: "chat_user",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_message");

            migrationBuilder.DropTable(
                name: "chat_room_user");

            migrationBuilder.DropTable(
                name: "chat_room");

            migrationBuilder.DropTable(
                name: "chat_user");
        }
    }
}
