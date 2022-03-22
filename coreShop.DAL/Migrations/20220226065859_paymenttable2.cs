using Microsoft.EntityFrameworkCore.Migrations;

namespace coreShop.DAL.Migrations
{
    public partial class paymenttable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders",
                column: "Paymentid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders",
                column: "Paymentid");
        }
    }
}
