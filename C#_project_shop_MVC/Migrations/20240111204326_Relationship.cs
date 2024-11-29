using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_shop_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Season",
                table: "Shoes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SaleId",
                table: "Shoes",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Sales_SaleId",
                table: "Shoes",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Sales_SaleId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_SaleId",
                table: "Shoes");

            migrationBuilder.AlterColumn<string>(
                name: "Season",
                table: "Shoes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
