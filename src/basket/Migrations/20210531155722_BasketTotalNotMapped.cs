using Microsoft.EntityFrameworkCore.Migrations;

namespace basket.Migrations
{
    public partial class BasketTotalNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Baskets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Baskets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
