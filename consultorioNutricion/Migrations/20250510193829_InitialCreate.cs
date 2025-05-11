using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace consultorioNutricion.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "obraSocial",
                columns: table => new
                {
                    obraSocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nombrePlan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__obraSoci__D2B23EF97374D02F", x => x.obraSocialId);
                });

            migrationBuilder.CreateTable(
                name: "provincia",
                columns: table => new
                {
                    provinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__provinci__671F12A57E2EA03C", x => x.provinciaId);
                });

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    ciudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    provinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ciudad__9FC23FCA070C2500", x => x.ciudadId);
                    table.ForeignKey(
                        name: "FK__ciudad__provinci__398D8EEE",
                        column: x => x.provinciaId,
                        principalTable: "provincia",
                        principalColumn: "provinciaId");
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dni = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    altura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    piso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    depto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ciudadId = table.Column<int>(type: "int", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    obraSocialId = table.Column<int>(type: "int", nullable: true),
                    numeroAfiliado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fechaNacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    antecedentes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaAlta = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paciente__0AB98B0EE3EF8262", x => x.pacienteId);
                    table.ForeignKey(
                        name: "FK__paciente__ciudad__412EB0B6",
                        column: x => x.ciudadId,
                        principalTable: "ciudad",
                        principalColumn: "ciudadId");
                    table.ForeignKey(
                        name: "FK__paciente__obraSo__4222D4EF",
                        column: x => x.obraSocialId,
                        principalTable: "obraSocial",
                        principalColumn: "obraSocialId");
                });

            migrationBuilder.CreateTable(
                name: "profesionalSalud",
                columns: table => new
                {
                    profesionalSaludId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dni = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    matricula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    especialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    altura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    piso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    depto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ciudadId = table.Column<int>(type: "int", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__profesio__55AC456B734C3FE7", x => x.profesionalSaludId);
                    table.ForeignKey(
                        name: "FK__profesion__ciuda__3E52440B",
                        column: x => x.ciudadId,
                        principalTable: "ciudad",
                        principalColumn: "ciudadId");
                });

            migrationBuilder.CreateTable(
                name: "turno",
                columns: table => new
                {
                    turnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pacienteId = table.Column<int>(type: "int", nullable: false),
                    profesionalSaludId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__turno__44E227011C6BBA66", x => x.turnoId);
                    table.ForeignKey(
                        name: "FK__turno__pacienteI__44FF419A",
                        column: x => x.pacienteId,
                        principalTable: "paciente",
                        principalColumn: "pacienteId");
                    table.ForeignKey(
                        name: "FK__turno__profesion__45F365D3",
                        column: x => x.profesionalSaludId,
                        principalTable: "profesionalSalud",
                        principalColumn: "profesionalSaludId");
                });

            migrationBuilder.CreateTable(
                name: "consulta",
                columns: table => new
                {
                    consultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turnoId = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    grasaTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    grasaVisceral = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    masaMuscular = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    medicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pesoPosible = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    actividadFisica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    habitosNutricionales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alimentosNoConsumidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diagnosticoNutricional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    indicaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__consulta__6EE42A6A938B2FDE", x => x.consultaId);
                    table.ForeignKey(
                        name: "FK__consulta__turnoI__48CFD27E",
                        column: x => x.turnoId,
                        principalTable: "turno",
                        principalColumn: "turnoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_provinciaId",
                table: "ciudad",
                column: "provinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_consulta_turnoId",
                table: "consulta",
                column: "turnoId");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_ciudadId",
                table: "paciente",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_obraSocialId",
                table: "paciente",
                column: "obraSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_profesionalSalud_ciudadId",
                table: "profesionalSalud",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_turno_pacienteId",
                table: "turno",
                column: "pacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_turno_profesionalSaludId",
                table: "turno",
                column: "profesionalSaludId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consulta");

            migrationBuilder.DropTable(
                name: "turno");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "profesionalSalud");

            migrationBuilder.DropTable(
                name: "obraSocial");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "provincia");
        }
    }
}
