using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class product6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSaleCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSaleCount",
                table: "Products");
        }
    }
}
