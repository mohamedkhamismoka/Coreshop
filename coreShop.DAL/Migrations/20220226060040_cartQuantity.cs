using Microsoft.EntityFrameworkCore.Migrations;

namespace coreShop.DAL.Migrations
{
    public partial class cartQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "product_Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "product_Carts");
        }
    }
}
