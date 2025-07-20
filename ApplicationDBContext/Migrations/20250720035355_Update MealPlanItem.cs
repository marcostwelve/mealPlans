using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealPlanItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServingSize",
                table: "MealPlanItems",
                newName: "Unit");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "MealPlanItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MealPlanItems");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MealPlanItems",
                newName: "ServingSize");
        }
    }
}
