using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "prodReturns",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ProdSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   ProdValveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_prodReturns", x => x.Id);
                   table.ForeignKey(
                       name: "FK_prodReturns_products_ProductId",
                       column: x => x.ProductId,
                       principalTable: "products",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveryAddresses");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "prodReturns");

            migrationBuilder.DropTable(
                name: "railers");

            migrationBuilder.DropTable(
                name: "stacks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "traders");

            migrationBuilder.DropTable(
                name: "productSizes");

            migrationBuilder.DropTable(
                name: "valves");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
