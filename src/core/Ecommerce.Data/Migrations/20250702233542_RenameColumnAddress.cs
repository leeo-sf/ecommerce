using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_supplier_SupplierId",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_SupplierId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "address");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "supplier",
                newName: "cnpj");

            migrationBuilder.RenameIndex(
                name: "IX_supplier_Cnpj",
                table: "supplier",
                newName: "IX_supplier_cnpj");

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "supplier",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                comment: "CNPJ do fornecedor",
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_address_id",
                table: "address",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_supplier_id",
                table: "address",
                column: "id",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cnpj",
                table: "supplier",
                newName: "Cnpj");

            migrationBuilder.RenameIndex(
                name: "IX_supplier_cnpj",
                table: "supplier",
                newName: "IX_supplier_Cnpj");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "supplier",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14,
                oldComment: "CNPJ do fornecedor");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "address",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_SupplierId",
                table: "address",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_supplier_SupplierId",
                table: "address",
                column: "SupplierId",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
