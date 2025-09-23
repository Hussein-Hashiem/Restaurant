using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurnat.DAL.Migrations
{
    /// <inheritdoc />
    public partial class editChefEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_Restaurants_restaurant_id",
                table: "Chefs");

            migrationBuilder.DropIndex(
                name: "IX_Chefs_restaurant_id",
                table: "Chefs");

            migrationBuilder.AlterColumn<int>(
                name: "experience_years",
                table: "Chefs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "age",
                table: "Chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "restaurant_id1",
                table: "Chefs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chefs_restaurant_id1",
                table: "Chefs",
                column: "restaurant_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_Restaurants_restaurant_id1",
                table: "Chefs",
                column: "restaurant_id1",
                principalTable: "Restaurants",
                principalColumn: "restaurant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_Restaurants_restaurant_id1",
                table: "Chefs");

            migrationBuilder.DropIndex(
                name: "IX_Chefs_restaurant_id1",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "restaurant_id1",
                table: "Chefs");

            migrationBuilder.AlterColumn<int>(
                name: "experience_years",
                table: "Chefs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Chefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Chefs_restaurant_id",
                table: "Chefs",
                column: "restaurant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_Restaurants_restaurant_id",
                table: "Chefs",
                column: "restaurant_id",
                principalTable: "Restaurants",
                principalColumn: "restaurant_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
