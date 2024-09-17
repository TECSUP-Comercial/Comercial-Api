using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Likes = table.Column<string>(type: "jsonb", nullable: false),
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
                    Historial = table.Column<string>(type: "jsonb", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Autor", "Categorias", "CreatedOnUtc", "DescripcionFinal", "Description", "Dificultad", "Duracion", "LinkImage", "Nombre" },
                values: new object[,]
                {
                    { new Guid("1082119c-1a36-48c1-bcdb-50c4e557393a"), "Juan Pérez", "[\"Programación\", \"Desarrollo\"]", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Este curso te enseñará desde lo básico hasta temas avanzados de C#.", "Un curso completo sobre desarrollo de aplicaciones con C# y .NET.", "Intermedio", 40, "video.mp4", "Curso de Programación en C#" },
                    { new Guid("c032c778-4699-4651-ba9a-fc0f9f0025d3"), "Maria López", "[\"Desarrollo Web\", \"Javascript\"]", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al final del curso serás capaz de crear sitios web dinámicos y escalables.", "Aprende a desarrollar aplicaciones web interactivas usando JavaScript y frameworks modernos.", "Avanzado", 50, "prueba.png", "Curso de Desarrollo Web con JavaScript" }
                });

            migrationBuilder.InsertData(
                table: "MediaDatos",
                columns: new[] { "Id", "Categorias", "Comentarios", "CreatedOnUtc", "Description", "Duracion", "IsReel", "Likes", "TipoMedia", "UrlMedia" },
                values: new object[,]
                {
                    { new Guid("aee5a707-759b-4517-aa0a-bbd440a2debb"), "[\"Educación\", \"Tutorial\"]", "[{\"usuario\": \"Juan\", \"texto\": \"Buen video!\", \"fecha\": \"2024-08-25T14:30:00\"}]", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Este es el primer video de ejemplo.", "5:00", false, "[{\"123\": true}, {\"456\": false}]", "Video", "video.mp4" },
                    { new Guid("cfdf5ae2-b9aa-4fb0-b6a6-4aac0008167e"), "[\"Tecnología\", \"Programacion\"]", "[{\"usuario\": \"Maria\", \"texto\": \"Muy informativo!\", \"fecha\": \"2024-08-26T10:15:00\"}]", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Este es el segundo video de ejemplo.", "5:00", true, "[{\"userId\": \"789\", \"like\": true}]", "Video", "prueba.png" }
                });

            migrationBuilder.InsertData(
                table: "Seccions",
                columns: new[] { "Id", "CursoId", "Nombre", "SeccionPadreId", "MediaId", "Description", "NumeroOrden", "CreatedOnUtc" },
                values: new object[,]
                {
                    { new Guid("a8f3a5a9-6c3d-4e50-9f0c-8b2c3b2c0c59"), new Guid("1082119c-1a36-48c1-bcdb-50c4e557393a"),"Introducción a C#", null,new Guid("aee5a707-759b-4517-aa0a-bbd440a2debb"),"Una introducción básica al lenguaje C#." ,1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)},
                    { new Guid("b9c2a456-5f5f-4e44-b348-b749a6d5d779"), new Guid("c032c778-4699-4651-ba9a-fc0f9f0025d3"),"Fundamentos de JavaScript", null,new Guid("cfdf5ae2-b9aa-4fb0-b6a6-4aac0008167e"), "Aprenderás los fundamentos esenciales de JavaScript.",2 ,new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)}
                }
            );


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
