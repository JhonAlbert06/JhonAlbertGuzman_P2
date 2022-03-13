using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    public partial class Cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producido_ProductosEmpaque_ProductoId",
                table: "Producido");

            migrationBuilder.DropIndex(
                name: "IX_Producido_ProductoId",
                table: "Producido");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Producido");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "Producido",
                newName: "Cantidad");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Producido",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Producido_ProductoEmpaqueId",
                table: "Producido",
                column: "ProductoEmpaqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producido_ProductosEmpaque_ProductoEmpaqueId",
                table: "Producido",
                column: "ProductoEmpaqueId",
                principalTable: "ProductosEmpaque",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producido_ProductosEmpaque_ProductoEmpaqueId",
                table: "Producido");

            migrationBuilder.DropIndex(
                name: "IX_Producido_ProductoEmpaqueId",
                table: "Producido");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Producido");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Producido",
                newName: "cantidad");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Producido",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producido_ProductoId",
                table: "Producido",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producido_ProductosEmpaque_ProductoId",
                table: "Producido",
                column: "ProductoId",
                principalTable: "ProductosEmpaque",
                principalColumn: "ProductoId");
        }
    }
}
