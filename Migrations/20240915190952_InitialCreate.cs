using System;
using System.Collections.Generic;
using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comercial.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Autor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Dificultad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Categorias = table.Column<string>(type: "jsonb", nullable: false),
                    LinkImage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DescripcionFinal = table.Column<string>(type: "text", nullable: false),
                    Duracion = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaDatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UrlMedia = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Likes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    TipoMedia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Comentarios = table.Column<string>(type: "jsonb", nullable: false),
                    Categorias = table.Column<string>(type: "jsonb", nullable: false),
                    IsReel = table.Column<bool>(type: "boolean", nullable: false),
                    Duracion = table.Column<string>(type: "text", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaDatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgressCursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PorcentajeAvanzado = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UrlEntregable = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    SeccionesCompletadas = table.Column<string>(type: "jsonb", nullable: false),
                    CantidadSesiones = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressCursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Correo = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Distrito = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Colegio = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Intereses = table.Column<string>(type: "jsonb", nullable: false),
                    Historial = table.Column<List<VideoHistorial>>(type: "jsonb", nullable: false),
                    Sexo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seccions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeccionPadreId = table.Column<Guid>(type: "uuid", nullable: true),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumeroOrden = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seccions_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seccions_MediaDatos_MediaId",
                        column: x => x.MediaId,
                        principalTable: "MediaDatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seccions_Seccions_SeccionPadreId",
                        column: x => x.SeccionPadreId,
                        principalTable: "Seccions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seccions_CursoId",
                table: "Seccions",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccions_MediaId",
                table: "Seccions",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccions_SeccionPadreId",
                table: "Seccions",
                column: "SeccionPadreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressCursos");

            migrationBuilder.DropTable(
                name: "Seccions");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "MediaDatos");
        }
    }
}
