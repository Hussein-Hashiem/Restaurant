using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurnat.DAL.Migrations
{
    /// <inheritdoc />
    public partial class eventsEnt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Restaurants_restaurant_id",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_restaurant_id",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Chefs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Chefs");

            migrationBuilder.CreateIndex(
                name: "IX_Events_restaurant_id",
                table: "Events",
                column: "restaurant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Restaurants_restaurant_id",
                table: "Events",
                column: "restaurant_id",
                principalTable: "Restaurants",
                principalColumn: "restaurant_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
