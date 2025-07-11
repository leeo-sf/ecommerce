using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueCnpjSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_supplier_cnpj",
                table: "supplier");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_cnpj",
                table: "supplier",
                column: "cnpj",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_supplier_cnpj",
                table: "supplier");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_cnpj",
                table: "supplier",
                column: "cnpj");
        }
    }
}
