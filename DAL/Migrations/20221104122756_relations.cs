using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(name: "FK_Products", table: "Orders", column: "ProductID", principalTable: "Products", principalColumn: "ProductID");
            migrationBuilder.AddForeignKey(name: "FK_Reviews_Products", table: "Reviews", column: "ProductID", principalTable: "Products", principalColumn: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Products", table: "Orders");
            migrationBuilder.DropForeignKey(name: "FK_Reviews_Products", table: "Reviews");
        }
    }
}
