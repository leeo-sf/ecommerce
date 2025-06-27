using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_table", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "supplier_tables",
                columns: table => new { id = table.Column<Guid>(type: "uuid", nullable: false) },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_tables", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "address_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    zip_code = table.Column<string>(
                        type: "character varying(10)",
                        maxLength: 10,
                        nullable: false
                    ),
                    public_place = table.Column<string>(
                        type: "character varying(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    neighborhood = table.Column<string>(
                        type: "character varying(300)",
                        maxLength: 300,
                        nullable: false
                    ),
                    UfId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_table_category_table_UfId",
                        column: x => x.UfId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "product_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(
                        type: "character varying(180)",
                        maxLength: 180,
                        nullable: false
                    ),
                    description = table.Column<string>(
                        type: "character varying(2000)",
                        maxLength: 2000,
                        nullable: false
                    ),
                    color = table.Column<string>(
                        type: "character varying(20)",
                        maxLength: 20,
                        nullable: false
                    ),
                    images_url = table.Column<string[]>(type: "text[]", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    quantity_in_stock = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_table_category_table_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_product_table_supplier_tables_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "supplier_tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "clothing_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClothingCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_clothing_table_category_table_SizeId",
                        column: x => x.SizeId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_clothing_table_category_table_TissueId",
                        column: x => x.TissueId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_clothing_table_product_table_id",
                        column: x => x.id,
                        principalTable: "product_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

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
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_electronic_table_product_table_id",
                        column: x => x.id,
                        principalTable: "product_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_address_table_UfId",
                table: "address_table",
                column: "UfId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_clothing_table_ClothingCategoryId",
                table: "clothing_table",
                column: "ClothingCategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_clothing_table_SizeId",
                table: "clothing_table",
                column: "SizeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_clothing_table_TissueId",
                table: "clothing_table",
                column: "TissueId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_electronic_table_TypeId",
                table: "electronic_table",
                column: "TypeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_table_CategoryId",
                table: "product_table",
                column: "CategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_table_SupplierId",
                table: "product_table",
                column: "SupplierId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "address_table");

            migrationBuilder.DropTable(name: "clothing_table");

            migrationBuilder.DropTable(name: "electronic_table");

            migrationBuilder.DropTable(name: "product_table");

            migrationBuilder.DropTable(name: "category_table");

            migrationBuilder.DropTable(name: "supplier_tables");
        }
    }
}
