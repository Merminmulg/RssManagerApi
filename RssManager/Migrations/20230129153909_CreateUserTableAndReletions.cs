using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RssManager.Migrations
{
    public partial class CreateUserTableAndReletions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserXmlItemModel",
                columns: table => new
                {
                    ItemsXmlItemModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserXmlItemModel", x => new { x.ItemsXmlItemModelId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_UserXmlItemModel_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserXmlItemModel_XmlItems_ItemsXmlItemModelId",
                        column: x => x.ItemsXmlItemModelId,
                        principalTable: "XmlItems",
                        principalColumn: "XmlItemModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserXmlItemModel_UsersUserId",
                table: "UserXmlItemModel",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserXmlItemModel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
