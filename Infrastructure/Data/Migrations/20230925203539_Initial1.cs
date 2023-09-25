using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Ciudad_CiudadId",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_CiudadId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "FechaNac",
                table: "Persona",
                newName: "Fecha Nacimiento");

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Nombre",
                keyValue: null,
                column: "Nombre",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Persona",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Apellido",
                keyValue: null,
                column: "Apellido",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Persona",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fecha Nacimiento",
                table: "Persona",
                type: "Date",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abreviatura = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdCiuFK",
                table: "Persona",
                column: "IdCiuFK");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdTipoDoc",
                table: "Persona",
                column: "IdTipoDoc");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Ciudad_IdCiuFK",
                table: "Persona",
                column: "IdCiuFK",
                principalTable: "Ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_TipoDocumento_IdTipoDoc",
                table: "Persona",
                column: "IdTipoDoc",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Ciudad_IdCiuFK",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_TipoDocumento_IdTipoDoc",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdCiuFK",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_IdTipoDoc",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "Fecha Nacimiento",
                table: "Persona",
                newName: "FechaNac");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Persona",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Persona",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaNac",
                table: "Persona",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Persona",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persona",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CiudadId",
                table: "Persona",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Ciudad_CiudadId",
                table: "Persona",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id");
        }
    }
}
