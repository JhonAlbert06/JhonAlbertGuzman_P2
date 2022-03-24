using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    public partial class Cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producidos");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizados_ProductoId",
                table: "Utilizados",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizados_Productos_ProductoId",
                table: "Utilizados",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizados_Productos_ProductoId",
                table: "Utilizados");

            migrationBuilder.DropIndex(
                name: "IX_Utilizados_ProductoId",
                table: "Utilizados");

            migrationBuilder.CreateTable(
                name: "Producidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producidos", x => x.Id);
                });
        }
    }
}
