using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class SupAndAddRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "supplier_id",
                table: "address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_address_supplier_id",
                table: "address",
                column: "supplier_id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_supplier_supplier_id",
                table: "address",
                column: "supplier_id",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_supplier_supplier_id",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_supplier_id",
                table: "address");

            migrationBuilder.DropColumn(
                name: "supplier_id",
                table: "address");
        }
    }
}
