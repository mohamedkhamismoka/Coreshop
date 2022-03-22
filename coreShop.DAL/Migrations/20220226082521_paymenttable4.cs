using Microsoft.EntityFrameworkCore.Migrations;

namespace coreShop.DAL.Migrations
{
    public partial class paymenttable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_pays_Paymentid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Paymentid",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "orderid",
                table: "pays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pays_orderid",
                table: "pays",
                column: "orderid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pays_Orders_orderid",
                table: "pays",
                column: "orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pays_Orders_orderid",
                table: "pays");

            migrationBuilder.DropIndex(
                name: "IX_pays_orderid",
                table: "pays");

            migrationBuilder.DropColumn(
                name: "orderid",
                table: "pays");

            migrationBuilder.AddColumn<int>(
                name: "Paymentid",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders",
                column: "Paymentid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_pays_Paymentid",
                table: "Orders",
                column: "Paymentid",
                principalTable: "pays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
