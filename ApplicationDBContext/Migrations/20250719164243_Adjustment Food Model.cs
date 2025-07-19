using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentFoodModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "portion",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "Foods",
                newName: "CaloriesPer100g");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaloriesPer100g",
                table: "Foods",
                newName: "Calories");

            migrationBuilder.AddColumn<string>(
                name: "portion",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
