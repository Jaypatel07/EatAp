using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EatAp.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantNReviews_Admins_AdminId",
                table: "RestaurantNReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Admins_AdminId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AdminId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Reviews",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "RestaurantNReviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantNReviews_AdminId",
                table: "RestaurantNReviews",
                newName: "IX_RestaurantNReviews_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Admins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantNReviews_Users_UserId",
                table: "RestaurantNReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantNReviews_Users_UserId",
                table: "RestaurantNReviews");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Reviews",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RestaurantNReviews",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantNReviews_UserId",
                table: "RestaurantNReviews",
                newName: "IX_RestaurantNReviews_AdminId");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AdminId",
                table: "Reviews",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_AdminId",
                table: "Menus",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantNReviews_Admins_AdminId",
                table: "RestaurantNReviews",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Admins_AdminId",
                table: "Reviews",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
