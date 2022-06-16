using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("8a3d0828-ab86-42b4-9761-92bc5d949002"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("8a3d0828-ab86-42b4-9761-92bc5d94908b"), null, "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("8a3d0828-ab86-42b4-9761-92bc5d949010"), new Guid("8a3d0828-ab86-42b4-9761-92bc5d94908b"), null, new DateTime(2022, 6, 16, 16, 37, 0, 611, DateTimeKind.Local).AddTicks(9048), 1, "Pago de servicios públicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("8a3d0828-ab86-42b4-9761-92bc5d949011"), new Guid("8a3d0828-ab86-42b4-9761-92bc5d949002"), null, new DateTime(2022, 6, 16, 16, 37, 0, 611, DateTimeKind.Local).AddTicks(9118), 0, "Terminar de ver película en Netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8a3d0828-ab86-42b4-9761-92bc5d949010"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8a3d0828-ab86-42b4-9761-92bc5d949011"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("8a3d0828-ab86-42b4-9761-92bc5d949002"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("8a3d0828-ab86-42b4-9761-92bc5d94908b"));
        }
    }
}
