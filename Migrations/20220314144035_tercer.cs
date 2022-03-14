using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    public partial class tercer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producido");

            migrationBuilder.CreateTable(
                name: "Producidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producidos_ProductosEmpaque_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "ProductosEmpaque",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilizados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizados_ProductosEmpaque_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "ProductosEmpaque",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producidos_ProductoId",
                table: "Producidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizados_ProductoId",
                table: "Utilizados",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producidos");

            migrationBuilder.DropTable(
                name: "Utilizados");

            migrationBuilder.CreateTable(
                name: "Producido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    ProductoEmpaqueId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producido_ProductosEmpaque_ProductoEmpaqueId",
                        column: x => x.ProductoEmpaqueId,
                        principalTable: "ProductosEmpaque",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producido_ProductoEmpaqueId",
                table: "Producido",
                column: "ProductoEmpaqueId");
        }
    }
}
