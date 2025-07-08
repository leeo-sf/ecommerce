using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypeDiscouponCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "discount_percentage",
                table: "coupon",
                type: "real",
                nullable: false,
                comment: "Porcentagem do desconto",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Porcentagem do desconto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "discount_percentage",
                table: "coupon",
                type: "integer",
                nullable: false,
                comment: "Porcentagem do desconto",
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "Porcentagem do desconto");
        }
    }
}
