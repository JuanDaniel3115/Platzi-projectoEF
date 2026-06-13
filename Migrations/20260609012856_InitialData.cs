using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectoEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("4af1c509-cef6-42a9-9b33-a58914e94402"), null, "Actividades personales", 50 },
                    { new Guid("4af1c509-cef6-42a9-9b33-a58914e94446"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Puntos", "Titulo" },
                values: new object[,]
                {
                    { new Guid("4af1c509-cef6-42a9-9b33-a58914e94410"), new Guid("4af1c509-cef6-42a9-9b33-a58914e94446"), "Pagar el agua y la luz antes del 5 de cada mes", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 50, "Pago de servicios publicos" },
                    { new Guid("4af1c509-cef6-42a9-9b33-a58914e94411"), new Guid("4af1c509-cef6-42a9-9b33-a58914e94402"), "Terminar de ver la serie de netflix", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 20, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4af1c509-cef6-42a9-9b33-a58914e94410"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4af1c509-cef6-42a9-9b33-a58914e94411"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4af1c509-cef6-42a9-9b33-a58914e94402"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4af1c509-cef6-42a9-9b33-a58914e94446"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
