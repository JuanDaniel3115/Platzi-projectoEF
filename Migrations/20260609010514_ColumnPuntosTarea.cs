using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPuntosTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "Tarea");
        }
    }
}
