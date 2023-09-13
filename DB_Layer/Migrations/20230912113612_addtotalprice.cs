using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Layer.Migrations
{
    /// <inheritdoc />
    public partial class addtotalprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalprice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalprice",
                table: "Order");
        }
    }
}
