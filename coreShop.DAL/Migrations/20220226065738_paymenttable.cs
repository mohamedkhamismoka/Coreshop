using Microsoft.EntityFrameworkCore.Migrations;

namespace coreShop.DAL.Migrations
{
    public partial class paymenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Paymentid",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creditname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditnumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pay", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders",
                column: "Paymentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pay_Paymentid",
                table: "Orders",
                column: "Paymentid",
                principalTable: "Pay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pay_Paymentid",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Paymentid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Paymentid",
                table: "Orders");
        }
    }
}
