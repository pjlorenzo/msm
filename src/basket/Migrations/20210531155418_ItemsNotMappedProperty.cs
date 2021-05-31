using Microsoft.EntityFrameworkCore.Migrations;

namespace basket.Migrations
{
    public partial class ItemsNotMappedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
