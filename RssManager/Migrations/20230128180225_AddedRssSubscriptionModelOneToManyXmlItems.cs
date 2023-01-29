using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RssManager.Migrations
{
    public partial class AddedRssSubscriptionModelOneToManyXmlItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_XmlItems",
                table: "XmlItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "XmlItems",
                newName: "RssSubscriptionId");

            migrationBuilder.AlterColumn<int>(
                name: "RssSubscriptionId",
                table: "XmlItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "XmlItemModelId",
                table: "XmlItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_XmlItems",
                table: "XmlItems",
                column: "XmlItemModelId");

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    RssSubscriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.RssSubscriptionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_XmlItems_RssSubscriptionId",
                table: "XmlItems",
                column: "RssSubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_XmlItems_Subscriptions_RssSubscriptionId",
                table: "XmlItems",
                column: "RssSubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "RssSubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XmlItems_Subscriptions_RssSubscriptionId",
                table: "XmlItems");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_XmlItems",
                table: "XmlItems");

            migrationBuilder.DropIndex(
                name: "IX_XmlItems_RssSubscriptionId",
                table: "XmlItems");

            migrationBuilder.DropColumn(
                name: "XmlItemModelId",
                table: "XmlItems");

            migrationBuilder.RenameColumn(
                name: "RssSubscriptionId",
                table: "XmlItems",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "XmlItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_XmlItems",
                table: "XmlItems",
                column: "Id");
        }
    }
}
