using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePromotionSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_promotion_promotion_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_promotion_id",
                table: "product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "valid_until",
                table: "promotion",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Data e hora que a promoção encerra",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Data de validade do cupom de desconto");

            migrationBuilder.AlterColumn<double>(
                name: "original_value",
                table: "promotion",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "Valor original do produto",
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true,
                oldComment: "Valor original do produto");

            migrationBuilder.AlterColumn<int>(
                name: "discount_percentage",
                table: "promotion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Porcentagem do desconto",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "Porcentagem do desconto");

            migrationBuilder.AlterColumn<float>(
                name: "discount_amount",
                table: "promotion",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                comment: "Valor do desconto",
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true,
                oldComment: "Valor do desconto");

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                table: "promotion",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Produto que pertence o desconto");

            migrationBuilder.AddColumn<DateTime>(
                name: "promotion_starts_in",
                table: "promotion",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Data e hora que a promoção inicia");

            migrationBuilder.CreateIndex(
                name: "IX_promotion_product_id",
                table: "promotion",
                column: "product_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_promotion_product_product_id",
                table: "promotion",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_promotion_product_product_id",
                table: "promotion");

            migrationBuilder.DropIndex(
                name: "IX_promotion_product_id",
                table: "promotion");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "promotion");

            migrationBuilder.DropColumn(
                name: "promotion_starts_in",
                table: "promotion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "valid_until",
                table: "promotion",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Data de validade do cupom de desconto",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Data e hora que a promoção encerra");

            migrationBuilder.AlterColumn<float>(
                name: "original_value",
                table: "promotion",
                type: "real",
                nullable: true,
                comment: "Valor original do produto",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "Valor original do produto");

            migrationBuilder.AlterColumn<int>(
                name: "discount_percentage",
                table: "promotion",
                type: "integer",
                nullable: true,
                comment: "Porcentagem do desconto",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Porcentagem do desconto");

            migrationBuilder.AlterColumn<float>(
                name: "discount_amount",
                table: "promotion",
                type: "real",
                nullable: true,
                comment: "Valor do desconto",
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "Valor do desconto");

            migrationBuilder.CreateIndex(
                name: "IX_product_promotion_id",
                table: "product",
                column: "promotion_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_promotion_promotion_id",
                table: "product",
                column: "promotion_id",
                principalTable: "promotion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
