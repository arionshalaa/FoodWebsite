using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodWebsite.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Menu_MenuId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Menu_MenuId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MenuId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Category_MenuId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CategoriesId",
                table: "Menu",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RecipeId",
                table: "Menu",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Category_CategoriesId",
                table: "Menu",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Recipes_RecipeId",
                table: "Menu",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Category_CategoriesId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Recipes_RecipeId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_CategoriesId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_RecipeId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MenuId",
                table: "Recipes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MenuId",
                table: "Category",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Menu_MenuId",
                table: "Category",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Menu_MenuId",
                table: "Recipes",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
