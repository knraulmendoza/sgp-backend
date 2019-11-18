using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class DataTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comunidad",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(nullable: true),
                    FechaDeSuscripcion = table.Column<DateTime>(nullable: false),
                    Plazo = table.Column<short>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
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
                    RawData = table.Column<byte[]>(nullable: true),
                    RespaldoFisicoDigitalizado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
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
                    DimensionId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_Dimension_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngresoOnceava",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<decimal>(nullable: false),
                    Interes = table.Column<decimal>(nullable: false),
                    SoporteValorId = table.Column<long>(nullable: false),
                    SoporteInteresId = table.Column<long>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoOnceava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngresoOnceava_Documento_SoporteInteresId",
                        column: x => x.SoporteInteresId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngresoOnceava_Documento_SoporteValorId",
                        column: x => x.SoporteValorId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propuestas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropuestaState = table.Column<int>(nullable: false, defaultValue: 0),
                    FechaDePresentacion = table.Column<DateTime>(nullable: false),
                    FechaDeAprobacion = table.Column<DateTime>(nullable: false),
                    DocumentoId = table.Column<long>(nullable: false),
                    NumeroDeFamilias = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    PresupuestoEstimado = table.Column<decimal>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estrategia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComponenteId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estrategia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estrategia_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstrategiaId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programa_Estrategia_EstrategiaId",
                        column: x => x.EstrategiaId,
                        principalTable: "Estrategia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropuestaId = table.Column<long>(nullable: false),
                    ProyectoState = table.Column<int>(nullable: false, defaultValue: 1),
                    Nombre = table.Column<string>(nullable: true),
                    PresupuestoAprobado = table.Column<decimal>(nullable: false),
                    PresupuestoEjecutado = table.Column<decimal>(nullable: false),
                    FechaEjecucion = table.Column<DateTime>(nullable: false),
                    FechaCierre = table.Column<DateTime>(nullable: false),
                    FechaDeCierrePrevista = table.Column<DateTime>(nullable: false),
                    ProgramaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Programa_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyectos_Propuestas_PropuestaId",
                        column: x => x.PropuestaId,
                        principalTable: "Propuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<long>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    ActividadState = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Egresos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Monto = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(nullable: true),
                    ProyectoDeDestinoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egresos_Proyectos_ProyectoDeDestinoId",
                        column: x => x.ProyectoDeDestinoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoComunidad",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<long>(nullable: false),
                    ComunidadId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoComunidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoComunidad_Comunidad_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoComunidad_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ProyectoId = table.Column<long>(nullable: true),
                    ProyectoDeDestinoId = table.Column<long>(nullable: true),
                    TransaccionUnaria_ProyectoId = table.Column<long>(nullable: true),
                    Concepto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaccion_Proyectos_ProyectoDeDestinoId",
                        column: x => x.ProyectoDeDestinoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaccion_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaccion_Proyectos_TransaccionUnaria_ProyectoId",
                        column: x => x.TransaccionUnaria_ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1L, "", "Atanquez" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 13L, "", "Rancho de la Goya" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 12L, "", "Murillo" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 11L, "", "Pueblo Bello" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 9L, "", "Mojao" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 8L, "", "Río Seco" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 10L, "", "Los Haticos" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 6L, "", "Las Florez" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 5L, "", "Pontón" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 4L, "", "La Mina" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 3L, "", "Chemesquemena" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 2L, "", "Guatapurí" });

            migrationBuilder.InsertData(
                table: "Comunidad",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 7L, "", "Ramalito" });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1L, null, "CONSOLIDACIÓN TERRITORIAL DEL PUEBLO INDÍGENA KANKUAMO PARA LA PROTECCION DE LA MADRE NATURALEZA" });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 2L, null, "FORTALECIMIENTO DEL GOBIERNO PROPIO Y LA AUTODETERMINACIÓN" });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 3L, null, "RESTABLECIMIENTO DE LOS DERECHOS COLECTIVOS E INDIVIDUALES DEL PUEBLO KANKUAMO" });

            migrationBuilder.InsertData(
                table: "Documento",
                columns: new[] { "Id", "Nombre", "RawData", "RespaldoFisicoDigitalizado" },
                values: new object[] { 3L, "Documento 3", new byte[] {  }, "" });

            migrationBuilder.InsertData(
                table: "Documento",
                columns: new[] { "Id", "Nombre", "RawData", "RespaldoFisicoDigitalizado" },
                values: new object[] { 1L, "Documento 1", new byte[] {  }, "" });

            migrationBuilder.InsertData(
                table: "Documento",
                columns: new[] { "Id", "Nombre", "RawData", "RespaldoFisicoDigitalizado" },
                values: new object[] { 2L, "Documento 2", new byte[] {  }, "" });

            migrationBuilder.InsertData(
                table: "Documento",
                columns: new[] { "Id", "Nombre", "RawData", "RespaldoFisicoDigitalizado" },
                values: new object[] { 4L, "Documento 4", new byte[] {  }, "" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 1L, null, 1L, "Recuperación del Territorio Ancestral" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 2L, null, 1L, "Desarrollo del modelo del ordenamiento territorial propio del pueblo Kankuamo en función del manejo integral y ancestral de las cuencas hidrográficas, la conservación de los bosques, la biodiversidad y el uso del suelo según su vocación" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 3L, null, 2L, "Impulso al proceso de recuperación de la identidad del pueblo Kankuamo" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 4L, null, 2L, "Fortalecimiento del sistema de Justicia Propia del pueblo kankuamo" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 5L, null, 2L, "Fortalecimiento del Modelo económico propio del pueblo Kankuamo: Autonomía Administrativa y Fisca" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 6L, null, 2L, "Fortalecimiento del hábitat y buen vivir del pueblo kankuamo" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 7L, null, 2L, "Sistema Educativo Propio" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 8L, null, 2L, "Sistema de Salud Propio" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 9L, null, 3L, "Salvaguarda, restablecimiento y garantía de los Derechos individuales y colectivos del pueblo indígena Kankuamo" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 10L, null, 3L, "Goce efectivos a los Derechos y atención al pueblo Kankuamo afectado por el conflicto" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 11L, null, 3L, "Adecuación institucional para el enfoque diferencial" });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "Id", "Descripcion", "DimensionId", "Nombre" },
                values: new object[] { 12L, null, 3L, "Fortalecimiento cultural para la recuperación de los roles del pueblo Kankuamo, como mecanismo para la apropiación cultural y territorial" });

            migrationBuilder.InsertData(
                table: "Propuestas",
                columns: new[] { "Id", "DocumentoId", "FechaDeAprobacion", "FechaDePresentacion", "FechaDeRegistro", "Nombre", "NumeroDeFamilias", "PresupuestoEstimado" },
                values: new object[] { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propuesta 1", 1500, 1520000m });

            migrationBuilder.InsertData(
                table: "Propuestas",
                columns: new[] { "Id", "DocumentoId", "FechaDeAprobacion", "FechaDePresentacion", "FechaDeRegistro", "Nombre", "NumeroDeFamilias", "PresupuestoEstimado", "PropuestaState" },
                values: new object[] { 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propuesta 2", 2600, 2000000m, 1 });

            migrationBuilder.InsertData(
                table: "Propuestas",
                columns: new[] { "Id", "DocumentoId", "FechaDeAprobacion", "FechaDePresentacion", "FechaDeRegistro", "Nombre", "NumeroDeFamilias", "PresupuestoEstimado" },
                values: new object[] { 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propuesta 3", 1000, 1800000m });

            migrationBuilder.InsertData(
                table: "Propuestas",
                columns: new[] { "Id", "DocumentoId", "FechaDeAprobacion", "FechaDePresentacion", "FechaDeRegistro", "Nombre", "NumeroDeFamilias", "PresupuestoEstimado" },
                values: new object[] { 4L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Propuesta 4", 1380, 1750000m });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 1L, 1L, "", "Consolidación del ordenamiento territorial tradicional del pueblo Kankuamo  a  través del saneamiento y ampliación del  resguardo y  la recuperación y manejo de los   sitios sagrados hasta la “Línea Negra”" });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 2L, 1L, "", "Recuperación de los elementos ambientales del Territorio Kankuamo: bosques secundarios, rastrojos, cuencas abastecedoras mediante la  regeneración natural, y las zonas de alto nivel de erosión y potrerización, mediante la reforestación con especies nativas y la reducción del pastoreo extensivo." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 3L, 2L, "", "Reglamentar los usos y manejo de la tierra, los bosques, las fuentes hídricas, la fauna  en aras de garantizar su preservación y reducir los factores de contaminación, la fragmentación y la presión antrópica  sobre el territorio" });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 4L, 2L, "", "Definir, como áreas  de protección absoluta aquellas zonas del Territorio Kankuamo que representen  y/o contengan  valores ancestrales,  bosques primarios, corredores ecológicos,  fuentes hídricas y altos niveles de erosión" });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 5L, 3L, "", "Fortalecer el sistema organizativo tradicional a partir de los principios establecidos en cada ezwama con la coordinación e integración de  los Mamos y Mayores, que parte desde el reconocimiento del centro de Gobierno Indígena. " });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 6L, 4L, "", "Impulsar y fortalecer la autonomía de las autoridades indígenas en el Territorio Ancestral, definiendo y ordenando las competencias, en el contexto de los mandatos de nuestra Ley de Origen y del control que sobre el territorio ejercen las autoridades indígenas." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 7L, 5L, "", "Fortalecimiento de la Economia propia del pueblo kankuamo" });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 8L, 6L, "", "Promover el desarrollo social sostenible de la población Kankuama." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 9L, 7L, "", "Fortalecimiento de la calidad, cobertura, eficiencia y pertinencia de la educación formal y no formal que se implementa en la población kankuama, teniendo en cuenta el contexto socio-cultural de la etnia y los lineamientos del MEN" });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 10L, 8L, "", "Recuperaciòn del Orden Material y Espiritual del Territorio Ancestral Kankuamo : ARMONIZACION DEL ORDENAMIENTO DE LA VIDA DESDE LOS ENFOQUES DE: SALUD Y ENFERMDAD EN LOS ESPIRITUAL Y MATERIAL." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 11L, 9L, "", "Generar espacios y mecanismos de convivencia pacífica y de resistencia al conflicto armado, a partir de la cohesión sociocultural, la armonía  familiar, la resolución de conflictos comunitarios, la prevención y atención oportuna del desplazamiento, la atención psicosocial y reparación integral a las víctimas y el aprovechamiento adecuado del tiempo libre." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 12L, 9L, "", "Programa de atención a la población Kankuama en situación de desplazamiento que garantice: Atención humanitaria, estabilización socio económica de acuerdo a nuestros usos y costumbres, acceso a la vivienda, orientación y asistencia jurídica, administrativa y de acompañamiento para la exigibilidad de los derechos de los desplazados y crear mecanismo que garanticen la superación de afectaciones y daños." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 13L, 10L, "", "Autoprotección colectiva e individual del Pueblo Indígena Kankuamo." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 14L, 10L, "", "Estabilización Socio-económica de la población en situación de desplazamiento." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 15L, 11L, "", "ncidencia para construcción y la formulación de una política pública/norma/circular/ directriz en la que se establezcan los  lineamientos para la atención de la  población Kankuama." });

            migrationBuilder.InsertData(
                table: "Estrategia",
                columns: new[] { "Id", "ComponenteId", "Descripcion", "Nombre" },
                values: new object[] { 16L, 12L, "", "Plan de Pervivencia de los miembros del Pueblo Kankuamo con un alcance integral y un espectro amplio que abarque todos los sitios donde se encuentren los(as) Kankuamos(as) víctimas del conflicto armado de forma directa o indirecta;" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 1L, "", 1L, "Saneamiento y ampliación del Resguardo Kankuamo" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 17L, "", 14L, "Impulso a las actividades de recuperación, reconstrucción y fortalecimiento de los procesos de autonomia alimentaria atraves de los procesos y visión propia del Pueblo Kankuamo" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 16L, "", 13L, "Programa de Protección Propia." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 15L, "", 12L, "Salvaguarda, restablecimiento y garantias de los derechos colectivos e individuales." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 14L, "", 11L, "Salvaguarda, restablecimiento y garantias de los derechos colectivos e individuales." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 13L, "", 10L, "Construccion e Implementacion del Sistema Intercultural de Salud  Propia del Pueblo Kankuamo" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 12L, "", 9L, "Educación propia." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 11L, "", 8L, "Construcción y Fortalecimiento de la infraestructura vial del Resguardo Kankuamo" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 18L, "", 15L, "Fortalecimiento de las capacidades organizativas y técnicas de los miembros del pueblo kankuamo en situación de desplazamiento." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 10L, "", 8L, "Fortalecimiento de la calidad de vida mediante la construcción y mejoramiento de viviendas en las comunidades del Resguardo Kankuamo" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 8L, "", 7L, "Fortalecimeinto de la autonomia alimentaria del pueblo kankuamo." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 7L, "Recuperaciòn del tejido sociocultural para garantizar el diálogo intergeneracional y la reapropiación de las Normas Propias", 6L, "Recuperaciòn del tejido sociocultural para garantizar el diálogo intergeneracional y la reapropiación de las Normas Propias" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 6L, "", 6L, "Fortalecimiento de los instrumentos y mecanismos internos para el Control Social del pueblo kankuamo " });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 5L, "", 4L, "Conservacion y proteccion ambiental  del territorio kankuamo." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 4L, "", 3L, "Conservacion y proteccion ambiental  del territorio kankuamo." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 3L, "", 2L, "Conservacion y proteccion ambiental  del territorio kankuamo." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 2L, "rotección y Recuperación de Espacios Sagrados", 1L, "Protección y Recuperación de Espacios Sagrados" });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 9L, "", 7L, "Fortalecimiento, promoción  de los sistemas propios de economía del pueblo kankuamo." });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Descripcion", "EstrategiaId", "Nombre" },
                values: new object[] { 19L, "", 16L, "Incentivar y Reactivar la Productividad en la población Kankuama en situación de desplazamiento, para fortalecer procesos de estabilización socioeconómica y retorno digno." });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "FechaCierre", "FechaDeCierrePrevista", "FechaEjecucion", "Nombre", "PresupuestoAprobado", "PresupuestoEjecutado", "ProgramaId", "PropuestaId", "ProyectoState" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proyecto 1", 1520000m, 1500000m, 1L, 1L, 1 });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "FechaCierre", "FechaDeCierrePrevista", "FechaEjecucion", "Nombre", "PresupuestoAprobado", "PresupuestoEjecutado", "ProgramaId", "PropuestaId", "ProyectoState" },
                values: new object[] { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proyecto 2", 2000000m, 1900000m, 2L, 2L, 1 });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "FechaCierre", "FechaDeCierrePrevista", "FechaEjecucion", "Nombre", "PresupuestoAprobado", "PresupuestoEjecutado", "ProgramaId", "PropuestaId", "ProyectoState" },
                values: new object[] { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proyecto 3", 1800000m, 1700000m, 3L, 3L, 2 });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "FechaCierre", "FechaDeCierrePrevista", "FechaEjecucion", "Nombre", "PresupuestoAprobado", "PresupuestoEjecutado", "ProgramaId", "PropuestaId", "ProyectoState" },
                values: new object[] { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proyecto 4", 2200000m, 2000000m, 4L, 4L, 4 });

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
                name: "IX_Egresos_ProyectoDeDestinoId",
                table: "Egresos",
                column: "ProyectoDeDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estrategia_ComponenteId",
                table: "Estrategia",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoOnceava_SoporteInteresId",
                table: "IngresoOnceava",
                column: "SoporteInteresId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoOnceava_SoporteValorId",
                table: "IngresoOnceava",
                column: "SoporteValorId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_EstrategiaId",
                table: "Programa",
                column: "EstrategiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_DocumentoId",
                table: "Propuestas",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoComunidad_ComunidadId",
                table: "ProyectoComunidad",
                column: "ComunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoComunidad_ProyectoId",
                table: "ProyectoComunidad",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ProgramaId",
                table: "Proyectos",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_PropuestaId",
                table: "Proyectos",
                column: "PropuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_ProyectoDeDestinoId",
                table: "Transaccion",
                column: "ProyectoDeDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_ProyectoId",
                table: "Transaccion",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_TransaccionUnaria_ProyectoId",
                table: "Transaccion",
                column: "TransaccionUnaria_ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "DocumentoPresupuestal");

            migrationBuilder.DropTable(
                name: "Egresos");

            migrationBuilder.DropTable(
                name: "IngresoOnceava");

            migrationBuilder.DropTable(
                name: "ProyectoComunidad");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Compromiso");

            migrationBuilder.DropTable(
                name: "Comunidad");

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
