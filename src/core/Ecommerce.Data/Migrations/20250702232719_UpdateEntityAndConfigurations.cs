using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityAndConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_table_category_table_UfId",
                table: "address_table");

            migrationBuilder.DropForeignKey(
                name: "FK_product_table_category_table_CategoryId",
                table: "product_table");

            migrationBuilder.DropForeignKey(
                name: "FK_product_table_supplier_tables_SupplierId",
                table: "product_table");

            migrationBuilder.DropTable(
                name: "clothing_table");

            migrationBuilder.DropTable(
                name: "electronic_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_supplier_tables",
                table: "supplier_tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_table",
                table: "product_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category_table",
                table: "category_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address_table",
                table: "address_table");

            migrationBuilder.DropIndex(
                name: "IX_address_table_UfId",
                table: "address_table");

            migrationBuilder.DropColumn(
                name: "UfId",
                table: "address_table");

            migrationBuilder.RenameTable(
                name: "supplier_tables",
                newName: "supplier");

            migrationBuilder.RenameTable(
                name: "product_table",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "category_table",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "address_table",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "product",
                newName: "supplier_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "product",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_table_SupplierId",
                table: "product",
                newName: "IX_product_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_table_CategoryId",
                table: "product",
                newName: "IX_product_category_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "category",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "supplier",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_in",
                table: "supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de criação");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "supplier",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Fornecedor ativo no sistema");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "supplier",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                comment: "Nome do fornecedor");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_in",
                table: "supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de atualização");

            migrationBuilder.AlterColumn<int>(
                name: "quantity_in_stock",
                table: "product",
                type: "integer",
                maxLength: 10000,
                nullable: false,
                comment: "Quantidade de produtos no estoque",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "product",
                type: "double precision",
                maxLength: 50000,
                nullable: false,
                comment: "Preço do produto",
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "product",
                type: "character varying(180)",
                maxLength: 180,
                nullable: false,
                comment: "Nome do produto",
                oldClrType: typeof(string),
                oldType: "character varying(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string[]>(
                name: "images_url",
                table: "product",
                type: "text[]",
                nullable: false,
                comment: "Imagens do produto",
                oldClrType: typeof(string[]),
                oldType: "text[]");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "Descrição do produto",
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "product",
                type: "text",
                nullable: false,
                comment: "Cor do produto",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "supplier_id",
                table: "product",
                type: "uuid",
                nullable: false,
                comment: "Identificador do fornecedor",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                table: "product",
                type: "uuid",
                nullable: false,
                comment: "Identificador da Categoria",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "coupon_id",
                table: "product",
                type: "uuid",
                nullable: true,
                comment: "Identificador do Cupom");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_in",
                table: "product",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de criação");

            migrationBuilder.AddColumn<Guid>(
                name: "promotion_id",
                table: "product",
                type: "uuid",
                nullable: true,
                comment: "Identificador da Promoção");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_in",
                table: "product",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de atualização");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "category",
                type: "text",
                nullable: false,
                comment: "Nome da categoria",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_in",
                table: "category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de criação");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_in",
                table: "category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de atualização");

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                table: "address",
                type: "text",
                nullable: false,
                comment: "CEP",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "public_place",
                table: "address",
                type: "text",
                nullable: false,
                comment: "Logradouro",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "neighborhood",
                table: "address",
                type: "text",
                nullable: false,
                comment: "Bairro",
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "address",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_in",
                table: "address",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de criação");

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Estado");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_in",
                table: "address",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de atualização");

            migrationBuilder.AddPrimaryKey(
                name: "PK_supplier",
                table: "supplier",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address",
                table: "address",
                column: "id");

            migrationBuilder.CreateTable(
                name: "coupon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false, comment: "Código do cupom"),
                    discount_percentage = table.Column<int>(type: "integer", nullable: false, comment: "Porcentagem do desconto"),
                    valid_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Data de validade do cupom de desconto"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_promotion = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "Produto está em promoção"),
                    original_value = table.Column<float>(type: "real", nullable: true, comment: "Valor original do produto"),
                    discount_percentage = table.Column<int>(type: "integer", nullable: true, comment: "Porcentagem do desconto"),
                    valid_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Data de validade do cupom de desconto"),
                    discount_amount = table.Column<float>(type: "real", nullable: true, comment: "Valor do desconto"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotion", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supplier_Cnpj",
                table: "supplier",
                column: "Cnpj");

            migrationBuilder.CreateIndex(
                name: "IX_product_coupon_id",
                table: "product",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_promotion_id",
                table: "product",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_name",
                table: "category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_SupplierId",
                table: "address",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_coupon_code",
                table: "coupon",
                column: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_address_supplier_SupplierId",
                table: "address",
                column: "SupplierId",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_category_id",
                table: "product",
                column: "category_id",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_coupon_coupon_id",
                table: "product",
                column: "coupon_id",
                principalTable: "coupon",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_promotion_promotion_id",
                table: "product",
                column: "promotion_id",
                principalTable: "promotion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_supplier_supplier_id",
                table: "product",
                column: "supplier_id",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_supplier_SupplierId",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_category_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_coupon_coupon_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_promotion_promotion_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_supplier_supplier_id",
                table: "product");

            migrationBuilder.DropTable(
                name: "coupon");

            migrationBuilder.DropTable(
                name: "promotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_supplier",
                table: "supplier");

            migrationBuilder.DropIndex(
                name: "IX_supplier_Cnpj",
                table: "supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_coupon_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_promotion_id",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_name",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_SupplierId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "supplier");

            migrationBuilder.DropColumn(
                name: "created_in",
                table: "supplier");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "supplier");

            migrationBuilder.DropColumn(
                name: "name",
                table: "supplier");

            migrationBuilder.DropColumn(
                name: "updated_in",
                table: "supplier");

            migrationBuilder.DropColumn(
                name: "coupon_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "created_in",
                table: "product");

            migrationBuilder.DropColumn(
                name: "promotion_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "updated_in",
                table: "product");

            migrationBuilder.DropColumn(
                name: "created_in",
                table: "category");

            migrationBuilder.DropColumn(
                name: "updated_in",
                table: "category");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "created_in",
                table: "address");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "address");

            migrationBuilder.DropColumn(
                name: "updated_in",
                table: "address");

            migrationBuilder.RenameTable(
                name: "supplier",
                newName: "supplier_tables");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "product_table");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "category_table");

            migrationBuilder.RenameTable(
                name: "address",
                newName: "address_table");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                table: "product_table",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "product_table",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_product_supplier_id",
                table: "product_table",
                newName: "IX_product_table_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_id",
                table: "product_table",
                newName: "IX_product_table_CategoryId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "category_table",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "quantity_in_stock",
                table: "product_table",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 10000,
                oldComment: "Quantidade de produtos no estoque");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "product_table",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldMaxLength: 50000,
                oldComment: "Preço do produto");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "product_table",
                type: "character varying(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(180)",
                oldMaxLength: 180,
                oldComment: "Nome do produto");

            migrationBuilder.AlterColumn<string[]>(
                name: "images_url",
                table: "product_table",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldComment: "Imagens do produto");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product_table",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldComment: "Descrição do produto");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "product_table",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Cor do produto");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "product_table",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Identificador do fornecedor");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "product_table",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Identificador da Categoria");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "category_table",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Nome da categoria");

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                table: "address_table",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "CEP");

            migrationBuilder.AlterColumn<string>(
                name: "public_place",
                table: "address_table",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Logradouro");

            migrationBuilder.AlterColumn<string>(
                name: "neighborhood",
                table: "address_table",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Bairro");

            migrationBuilder.AddColumn<Guid>(
                name: "UfId",
                table: "address_table",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_supplier_tables",
                table: "supplier_tables",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_table",
                table: "product_table",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category_table",
                table: "category_table",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address_table",
                table: "address_table",
                column: "id");

            migrationBuilder.CreateTable(
                name: "clothing_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClothingCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TissueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clothing_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_clothing_table_category_table_ClothingCategoryId",
                        column: x => x.ClothingCategoryId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clothing_table_category_table_SizeId",
                        column: x => x.SizeId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clothing_table_category_table_TissueId",
                        column: x => x.TissueId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clothing_table_product_table_id",
                        column: x => x.id,
                        principalTable: "product_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "electronic_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_electronic_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_electronic_table_category_table_TypeId",
                        column: x => x.TypeId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_electronic_table_product_table_id",
                        column: x => x.id,
                        principalTable: "product_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_table_UfId",
                table: "address_table",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_clothing_table_ClothingCategoryId",
                table: "clothing_table",
                column: "ClothingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_clothing_table_SizeId",
                table: "clothing_table",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_clothing_table_TissueId",
                table: "clothing_table",
                column: "TissueId");

            migrationBuilder.CreateIndex(
                name: "IX_electronic_table_TypeId",
                table: "electronic_table",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_table_category_table_UfId",
                table: "address_table",
                column: "UfId",
                principalTable: "category_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_table_category_table_CategoryId",
                table: "product_table",
                column: "CategoryId",
                principalTable: "category_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_table_supplier_tables_SupplierId",
                table: "product_table",
                column: "SupplierId",
                principalTable: "supplier_tables",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
