﻿// <auto-generated />
using System;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructura.Migrations
{
    [DbContext(typeof(SgpContext))]
    [Migration("20191106220014_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("Dominio.Entities.Actividad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActividadState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaFinalizacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("Dominio.Entities.Beneficiario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PropuestaId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PropuestaId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Beneficiarios");
                });

            modelBuilder.Entity("Dominio.Entities.Componente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<long?>("DimensionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DimensionId");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("Dominio.Entities.Compromiso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ConvenioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConvenioId");

                    b.ToTable("Compromiso");
                });

            modelBuilder.Entity("Dominio.Entities.Comunidad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Comunidad");
                });

            modelBuilder.Entity("Dominio.Entities.Convenio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeSuscripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Obbjeto")
                        .HasColumnType("TEXT");

                    b.Property<short>("Plazo")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Convenio");
                });

            modelBuilder.Entity("Dominio.Entities.Dimension", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dimension");
                });

            modelBuilder.Entity("Dominio.Entities.Documento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("RespaldoFisicoDigitalizado")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("Dominio.Entities.DocumentoPresupuestal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeExpedicion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DocumentoPresupuestal");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DocumentoPresupuestal");
                });

            modelBuilder.Entity("Dominio.Entities.Estrategia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ComponenteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComponenteId");

                    b.ToTable("Estrategia");
                });

            modelBuilder.Entity("Dominio.Entities.IngresoOnceava", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Interes")
                        .HasColumnType("REAL");

                    b.Property<string>("SoporteInteres")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoporteValor")
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("IngresoOnceava");
                });

            modelBuilder.Entity("Dominio.Entities.Programa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<long?>("EstrategiaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EstrategiaId");

                    b.ToTable("Programa");
                });

            modelBuilder.Entity("Dominio.Entities.Propuesta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DocumentoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDeAprovacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDePresentacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroDeFamilias")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PresupuestoEstimado")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.ToTable("Propuestas");
                });

            modelBuilder.Entity("Dominio.Entities.Proyecto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCierre")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeCierrePrevista")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaEjecucion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<float>("PresupuestoAprovado")
                        .HasColumnType("REAL");

                    b.Property<float>("PresupuestoEjecutado")
                        .HasColumnType("REAL");

                    b.Property<long?>("ProgramaId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PropuestaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProyectoState")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProgramaId");

                    b.HasIndex("PropuestaId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("Dominio.Entities.Transaccion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Monto")
                        .HasColumnType("REAL");

                    b.Property<long?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Transaccion");
                });

            modelBuilder.Entity("Dominio.Entities.CertificadoDeDisponibilidadPresupuestal", b =>
                {
                    b.HasBaseType("Dominio.Entities.DocumentoPresupuestal");

                    b.Property<DateTime>("FechaDeVencimiento")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("RegistroPresupuestalId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("RegistroPresupuestalId");

                    b.HasDiscriminator().HasValue("CertificadoDeDisponibilidadPresupuestal");
                });

            modelBuilder.Entity("Dominio.Entities.RegistroPresupuestal", b =>
                {
                    b.HasBaseType("Dominio.Entities.DocumentoPresupuestal");

                    b.Property<long?>("BeneficiarioId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CompromisoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VigenciaFiscal")
                        .HasColumnType("TEXT");

                    b.Property<string>("identificacion")
                        .HasColumnType("TEXT");

                    b.HasIndex("BeneficiarioId");

                    b.HasIndex("CompromisoId");

                    b.HasDiscriminator().HasValue("RegistroPresupuestal");
                });

            modelBuilder.Entity("Dominio.Entities.Actividad", b =>
                {
                    b.HasOne("Dominio.Entities.Proyecto", null)
                        .WithMany("Actividades")
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Dominio.Entities.Beneficiario", b =>
                {
                    b.HasOne("Dominio.Entities.Propuesta", null)
                        .WithMany("Beneficiarios")
                        .HasForeignKey("PropuestaId");

                    b.HasOne("Dominio.Entities.Proyecto", null)
                        .WithMany("Beneficiarios")
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Dominio.Entities.Componente", b =>
                {
                    b.HasOne("Dominio.Entities.Dimension", null)
                        .WithMany("Componentes")
                        .HasForeignKey("DimensionId");
                });

            modelBuilder.Entity("Dominio.Entities.Compromiso", b =>
                {
                    b.HasOne("Dominio.Entities.Convenio", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId");
                });

            modelBuilder.Entity("Dominio.Entities.Comunidad", b =>
                {
                    b.HasOne("Dominio.Entities.Proyecto", null)
                        .WithMany("Comunidad")
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Dominio.Entities.Estrategia", b =>
                {
                    b.HasOne("Dominio.Entities.Componente", null)
                        .WithMany("Estrategias")
                        .HasForeignKey("ComponenteId");
                });

            modelBuilder.Entity("Dominio.Entities.Programa", b =>
                {
                    b.HasOne("Dominio.Entities.Estrategia", null)
                        .WithMany("Programas")
                        .HasForeignKey("EstrategiaId");
                });

            modelBuilder.Entity("Dominio.Entities.Propuesta", b =>
                {
                    b.HasOne("Dominio.Entities.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId");
                });

            modelBuilder.Entity("Dominio.Entities.Proyecto", b =>
                {
                    b.HasOne("Dominio.Entities.Programa", "Programa")
                        .WithMany("Proyectos")
                        .HasForeignKey("ProgramaId");

                    b.HasOne("Dominio.Entities.Propuesta", "Propuesta")
                        .WithMany()
                        .HasForeignKey("PropuestaId");
                });

            modelBuilder.Entity("Dominio.Entities.Transaccion", b =>
                {
                    b.HasOne("Dominio.Entities.Proyecto", "Proyecto")
                        .WithMany("Transacciones")
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Dominio.Entities.CertificadoDeDisponibilidadPresupuestal", b =>
                {
                    b.HasOne("Dominio.Entities.Proyecto", null)
                        .WithMany("CertificadosDeDisponibilidaPresupuestales")
                        .HasForeignKey("ProyectoId");

                    b.HasOne("Dominio.Entities.RegistroPresupuestal", "RegistroPresupuestal")
                        .WithMany()
                        .HasForeignKey("RegistroPresupuestalId");
                });

            modelBuilder.Entity("Dominio.Entities.RegistroPresupuestal", b =>
                {
                    b.HasOne("Dominio.Entities.Beneficiario", "Beneficiario")
                        .WithMany()
                        .HasForeignKey("BeneficiarioId");

                    b.HasOne("Dominio.Entities.Compromiso", "Compromiso")
                        .WithMany()
                        .HasForeignKey("CompromisoId");
                });
#pragma warning restore 612, 618
        }
    }
}
