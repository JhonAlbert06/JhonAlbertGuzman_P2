using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JhonAlbertGuzman_P2.Migrations
{
    public partial class cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadUtilizados",
                table: "ProductosEmpaque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadUtilizados",
                table: "ProductosEmpaque",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
