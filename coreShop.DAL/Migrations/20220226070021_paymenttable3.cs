using Microsoft.EntityFrameworkCore.Migrations;

namespace coreShop.DAL.Migrations
{
    public partial class paymenttable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pay_Paymentid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pay",
                table: "Pay");

            migrationBuilder.RenameTable(
                name: "Pay",
                newName: "pays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pays",
                table: "pays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_pays_Paymentid",
                table: "Orders",
                column: "Paymentid",
                principalTable: "pays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_pays_Paymentid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pays",
                table: "pays");

            migrationBuilder.RenameTable(
                name: "pays",
                newName: "Pay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pay",
                table: "Pay",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pay_Paymentid",
                table: "Orders",
                column: "Paymentid",
                principalTable: "Pay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
