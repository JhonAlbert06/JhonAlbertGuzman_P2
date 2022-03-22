using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producidos_ProductosEmpaque_ProductoId",
                table: "Producidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizados_ProductosEmpaque_ProductoId",
                table: "Utilizados");

            migrationBuilder.DropIndex(
                name: "IX_Utilizados_ProductoId",
                table: "Utilizados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque");

            migrationBuilder.DropIndex(
                name: "IX_Producidos_ProductoId",
                table: "Producidos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductosEmpaque");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "ProductosEmpaque",
                newName: "EmpaqueId");

            migrationBuilder.AddColumn<int>(
                name: "EmpaqueId",
                table: "Utilizados",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpaqueId",
                table: "ProductosEmpaque",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque",
                column: "EmpaqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizados_EmpaqueId",
                table: "Utilizados",
                column: "EmpaqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizados_ProductosEmpaque_EmpaqueId",
                table: "Utilizados",
                column: "EmpaqueId",
                principalTable: "ProductosEmpaque",
                principalColumn: "EmpaqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizados_ProductosEmpaque_EmpaqueId",
                table: "Utilizados");

            migrationBuilder.DropIndex(
                name: "IX_Utilizados_EmpaqueId",
                table: "Utilizados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosEmpaque",
                table: "ProductosEmpaque");

            migrationBuilder.DropColumn(
                name: "EmpaqueId",
                table: "Utilizados");

            migrationBuilder.RenameColumn(
                name: "EmpaqueId",
                table: "ProductosEmpaque",
                newName: "ProductoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Utilizados_ProductoId",
                table: "Utilizados",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producidos_ProductoId",
                table: "Producidos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producidos_ProductosEmpaque_ProductoId",
                table: "Producidos",
                column: "ProductoId",
                principalTable: "ProductosEmpaque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizados_ProductosEmpaque_ProductoId",
                table: "Utilizados",
                column: "ProductoId",
                principalTable: "ProductosEmpaque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
