using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: true),
                    FechaDeSuscripcion = table.Column<DateTime>(nullable: false),
                    Plazo = table.Column<short>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    Obbjeto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    RespaldoFisicoDigitalizado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngresoOnceava",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<double>(nullable: false),
                    Interes = table.Column<double>(nullable: false),
                    SoporteValor = table.Column<string>(nullable: true),
                    SoporteInteres = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoOnceava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compromiso",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    ConvenioId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compromiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compromiso_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    DimensionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_Dimension_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propuestas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaDePresentacion = table.Column<DateTime>(nullable: false),
                    FechaDeAprovacion = table.Column<DateTime>(nullable: false),
                    DocumentoId = table.Column<long>(nullable: true),
                    NumeroDeFamilias = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    PresupuestoEstimado = table.Column<double>(nullable: false),
                    FechaDeRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propuestas_Documento_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estrategia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ComponenteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estrategia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estrategia_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EstrategiaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programa_Estrategia_EstrategiaId",
                        column: x => x.EstrategiaId,
                        principalTable: "Estrategia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropuestaId = table.Column<long>(nullable: true),
                    ProyectoState = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    PresupuestoAprovado = table.Column<float>(nullable: false),
                    PresupuestoEjecutado = table.Column<float>(nullable: false),
                    FechaEjecucion = table.Column<DateTime>(nullable: false),
                    FechaCierre = table.Column<DateTime>(nullable: false),
                    FechaDeCierrePrevista = table.Column<DateTime>(nullable: false),
                    ProgramaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Programa_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Propuestas_PropuestaId",
                        column: x => x.PropuestaId,
                        principalTable: "Propuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    ActividadState = table.Column<int>(nullable: false),
                    Costo = table.Column<float>(nullable: false),
                    ProyectoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    PropuestaId = table.Column<long>(nullable: true),
                    ProyectoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_Propuestas_PropuestaId",
                        column: x => x.PropuestaId,
                        principalTable: "Propuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comunidad",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ProyectoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunidad_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<float>(nullable: false),
                    ProyectoId = table.Column<long>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaccion_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoPresupuestal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaDeExpedicion = table.Column<DateTime>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FechaDeVencimiento = table.Column<DateTime>(nullable: true),
                    RegistroPresupuestalId = table.Column<long>(nullable: true),
                    ProyectoId = table.Column<long>(nullable: true),
                    VigenciaFiscal = table.Column<DateTime>(nullable: true),
                    BeneficiarioId = table.Column<long>(nullable: true),
                    identificacion = table.Column<string>(nullable: true),
                    CompromisoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPresupuestal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoPresupuestal_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentoPresupuestal_DocumentoPresupuestal_RegistroPresupuestalId",
                        column: x => x.RegistroPresupuestalId,
                        principalTable: "DocumentoPresupuestal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentoPresupuestal_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentoPresupuestal_Compromiso_CompromisoId",
                        column: x => x.CompromisoId,
                        principalTable: "Compromiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ProyectoId",
                table: "Actividades",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_PropuestaId",
                table: "Beneficiarios",
                column: "PropuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_ProyectoId",
                table: "Beneficiarios",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_DimensionId",
                table: "Componente",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Compromiso_ConvenioId",
                table: "Compromiso",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunidad_ProyectoId",
                table: "Comunidad",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPresupuestal_ProyectoId",
                table: "DocumentoPresupuestal",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPresupuestal_RegistroPresupuestalId",
                table: "DocumentoPresupuestal",
                column: "RegistroPresupuestalId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPresupuestal_BeneficiarioId",
                table: "DocumentoPresupuestal",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPresupuestal_CompromisoId",
                table: "DocumentoPresupuestal",
                column: "CompromisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estrategia_ComponenteId",
                table: "Estrategia",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_EstrategiaId",
                table: "Programa",
                column: "EstrategiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_DocumentoId",
                table: "Propuestas",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ProgramaId",
                table: "Proyectos",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_PropuestaId",
                table: "Proyectos",
                column: "PropuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_ProyectoId",
                table: "Transaccion",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Comunidad");

            migrationBuilder.DropTable(
                name: "DocumentoPresupuestal");

            migrationBuilder.DropTable(
                name: "IngresoOnceava");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Compromiso");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Propuestas");

            migrationBuilder.DropTable(
                name: "Estrategia");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Dimension");
        }
    }
}
