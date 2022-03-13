using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductosEmpaque");

            migrationBuilder.RenameColumn(
                name: "CantidadProducido",
                table: "ProductosEmpaque",
                newName: "ProductoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ProductosEmpaque",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque",
                column: "ProductoId");

            migrationBuilder.CreateTable(
                name: "Producido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoEmpaqueId = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producido_ProductosEmpaque_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "ProductosEmpaque",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producido_ProductoId",
                table: "Producido",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "ProductosEmpaque",
                newName: "CantidadProducido");

            migrationBuilder.AlterColumn<int>(
                name: "CantidadProducido",
                table: "ProductosEmpaque",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductosEmpaque",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque",
                column: "Id");
        }
    }
}
