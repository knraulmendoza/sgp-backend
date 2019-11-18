using System.IO;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities.States;

namespace Infraestructura.Utils
{
    public class SgpContext : DbContext
    {
        public SgpContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            System.Console.WriteLine("Configurando DbContext");
            // Database.SetInitializer<SgpContext>(new CreateDatabaseIfNotExists<SgpContext>());
            // optionsBuilder.UseSqlServer("Server=DESKTOP-RB14CRB;Database=sgp;Trusted_Connection=True;");
            //optionsBuilder.UseSqlite(@"Data Source=D:\Documents\Datos\9no Semestre\Procesos Agiles\sgp-backend\sgp.db");

            // optionsBuilder.UseSqlServer("Server=DESKTOP-RB14CRB;Database=sgp;Trusted_Connection=True;");
            string urlBase = "D:/";
            urlBase = Path.Combine(urlBase, "sgp.db");
            optionsBuilder.UseSqlite(@"Data Source=" + urlBase);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Proyecto>()
                .HasMany(t => t.TransaccionesUnarias)
                .WithOne(t => t.Proyecto);

            model.Entity<Proyecto>()
                .HasMany(t => t.TransaccionesBinarias)
                .WithOne(t => t.Proyecto);
            
            model.Entity<Propuesta>()
                .Property(p => p.PropuestaState).HasDefaultValue(PropuestaState.ESPERA);
            
            model.Entity<Proyecto>()
                .Property(p => p.ProyectoState).HasDefaultValue(ProyectoState.VIABLE);

            model.Entity<Dimension>().HasData(
                new Dimension
                {
                    Id = 1,
                    Nombre = "CONSOLIDACIÓN TERRITORIAL DEL PUEBLO INDÍGENA KANKUAMO PARA LA PROTECCION DE LA MADRE NATURALEZA"
                },
                new Dimension
                {
                    Id = 2,
                    Nombre = "FORTALECIMIENTO DEL GOBIERNO PROPIO Y LA AUTODETERMINACIÓN"
                },
                new Dimension
                {
                    Id = 3,
                    Nombre = "RESTABLECIMIENTO DE LOS DERECHOS COLECTIVOS E INDIVIDUALES DEL PUEBLO KANKUAMO"
                }
            );
            model.Entity<Componente>().HasData(
                new Componente
                {
                    Id = 1,
                    Nombre = "Recuperación del Territorio Ancestral",
                    DimensionId = 1
                },
                new Componente
                {
                    Id = 2,
                    Nombre = "Desarrollo del modelo del ordenamiento territorial propio del pueblo Kankuamo en función del manejo integral y ancestral de las cuencas hidrográficas, la conservación de los bosques, la biodiversidad y el uso del suelo según su vocación",
                    DimensionId = 1
                },
                new Componente
                {
                    Id = 3,
                    Nombre = "Impulso al proceso de recuperación de la identidad del pueblo Kankuamo",
                    DimensionId = 2
                },
                new Componente
                {
                    Id = 4,
                    Nombre = "Fortalecimiento del sistema de Justicia Propia del pueblo kankuamo",
                    DimensionId = 2
                },
                new Componente
                {
                    Id = 5,
                    Nombre = "Fortalecimiento del Modelo económico propio del pueblo Kankuamo: Autonomía Administrativa y Fisca",
                    DimensionId = 2
                },
                new Componente
                {
                    Id = 6,
                    Nombre = "Fortalecimiento del hábitat y buen vivir del pueblo kankuamo",
                    DimensionId = 2
                },
                new Componente
                {
                    Id = 7,
                    Nombre = "Sistema Educativo Propio",
                    DimensionId = 2
                },
                new Componente
                {
                    Id = 8,
                    Nombre = "Sistema de Salud Propio",
                    DimensionId = 2
                },
                new Componente
                {
                    Id = 9,
                    Nombre = "Salvaguarda, restablecimiento y garantía de los Derechos individuales y colectivos del pueblo indígena Kankuamo",
                    DimensionId = 3
                },
                new Componente
                {
                    Id = 10,
                    Nombre = "Goce efectivos a los Derechos y atención al pueblo Kankuamo afectado por el conflicto",
                    DimensionId = 3
                },
                new Componente
                {
                    Id = 11,
                    Nombre = "Adecuación institucional para el enfoque diferencial",
                    DimensionId = 3
                },
                new Componente
                {
                    Id = 12,
                    Nombre = "Fortalecimiento cultural para la recuperación de los roles del pueblo Kankuamo, como mecanismo para la apropiación cultural y territorial",
                    DimensionId = 3
                }
            );
            model.Entity<Estrategia>().HasData(
                new Estrategia
                {
                    Id = 1,
                    Nombre = "Consolidación del ordenamiento territorial tradicional del pueblo Kankuamo  a  través del saneamiento y ampliación del  resguardo y  la recuperación y manejo de los   sitios sagrados hasta la “Línea Negra”",
                    Descripcion = "",
                    ComponenteId = 1
                },
                new Estrategia
                {
                    Id = 2,
                    Nombre = "Recuperación de los elementos ambientales del Territorio Kankuamo: bosques secundarios, rastrojos, cuencas abastecedoras mediante la  regeneración natural, y las zonas de alto nivel de erosión y potrerización, mediante la reforestación con especies nativas y la reducción del pastoreo extensivo.",
                    Descripcion = "",
                    ComponenteId = 1
                },
                new Estrategia
                {
                    Id = 3,
                    Nombre = "Reglamentar los usos y manejo de la tierra, los bosques, las fuentes hídricas, la fauna  en aras de garantizar su preservación y reducir los factores de contaminación, la fragmentación y la presión antrópica  sobre el territorio",
                    Descripcion = "",
                    ComponenteId = 2
                },
                new Estrategia
                {
                    Id = 4,
                    Nombre = "Definir, como áreas  de protección absoluta aquellas zonas del Territorio Kankuamo que representen  y/o contengan  valores ancestrales,  bosques primarios, corredores ecológicos,  fuentes hídricas y altos niveles de erosión",
                    Descripcion = "",
                    ComponenteId = 2
                },
                new Estrategia
                {
                    Id = 5,
                    Nombre = "Fortalecer el sistema organizativo tradicional a partir de los principios establecidos en cada ezwama con la coordinación e integración de  los Mamos y Mayores, que parte desde el reconocimiento del centro de Gobierno Indígena. ",
                    Descripcion = "",
                    ComponenteId = 3
                },
                new Estrategia
                {
                    Id = 6,
                    Nombre = "Impulsar y fortalecer la autonomía de las autoridades indígenas en el Territorio Ancestral, definiendo y ordenando las competencias, en el contexto de los mandatos de nuestra Ley de Origen y del control que sobre el territorio ejercen las autoridades indígenas.",
                    Descripcion = "",
                    ComponenteId = 4
                },
                new Estrategia
                {
                    Id = 7,
                    Nombre = "Fortalecimiento de la Economia propia del pueblo kankuamo",
                    Descripcion = "",
                    ComponenteId = 5
                },
                new Estrategia
                {
                    Id = 8,
                    Nombre = "Promover el desarrollo social sostenible de la población Kankuama.",
                    Descripcion = "",
                    ComponenteId = 6
                },
                new Estrategia
                {
                    Id = 9,
                    Nombre = "Fortalecimiento de la calidad, cobertura, eficiencia y pertinencia de la educación formal y no formal que se implementa en la población kankuama, teniendo en cuenta el contexto socio-cultural de la etnia y los lineamientos del MEN",
                    Descripcion = "",
                    ComponenteId = 7
                },
                new Estrategia
                {
                    Id = 10,
                    Nombre = "Recuperaciòn del Orden Material y Espiritual del Territorio Ancestral Kankuamo : ARMONIZACION DEL ORDENAMIENTO DE LA VIDA DESDE LOS ENFOQUES DE: SALUD Y ENFERMDAD EN LOS ESPIRITUAL Y MATERIAL.",
                    Descripcion = "",
                    ComponenteId = 8
                },
                new Estrategia
                {
                    Id = 11,
                    Nombre = "Generar espacios y mecanismos de convivencia pacífica y de resistencia al conflicto armado, a partir de la cohesión sociocultural, la armonía  familiar, la resolución de conflictos comunitarios, la prevención y atención oportuna del desplazamiento, la atención psicosocial y reparación integral a las víctimas y el aprovechamiento adecuado del tiempo libre.",
                    Descripcion = "",
                    ComponenteId = 9
                },
                new Estrategia
                {
                    Id = 12,
                    Nombre = "Programa de atención a la población Kankuama en situación de desplazamiento que garantice: Atención humanitaria, estabilización socio económica de acuerdo a nuestros usos y costumbres, acceso a la vivienda, orientación y asistencia jurídica, administrativa y de acompañamiento para la exigibilidad de los derechos de los desplazados y crear mecanismo que garanticen la superación de afectaciones y daños.",
                    Descripcion = "",
                    ComponenteId = 9
                },
                new Estrategia
                {
                    Id = 13,
                    Nombre = "Autoprotección colectiva e individual del Pueblo Indígena Kankuamo.",
                    Descripcion = "",
                    ComponenteId = 10
                },
                new Estrategia
                {
                    Id = 14,
                    Nombre = "Estabilización Socio-económica de la población en situación de desplazamiento.",
                    Descripcion = "",
                    ComponenteId = 10
                },
                new Estrategia
                {
                    Id = 15,
                    Nombre = "ncidencia para construcción y la formulación de una política pública/norma/circular/ directriz en la que se establezcan los  lineamientos para la atención de la  población Kankuama.",
                    Descripcion = "",
                    ComponenteId = 11
                },
                new Estrategia
                {
                    Id = 16,
                    Nombre = "Plan de Pervivencia de los miembros del Pueblo Kankuamo con un alcance integral y un espectro amplio que abarque todos los sitios donde se encuentren los(as) Kankuamos(as) víctimas del conflicto armado de forma directa o indirecta;",
                    Descripcion = "",
                    ComponenteId = 12
                }
            );
            model.Entity<Programa>().HasData(
                new Programa
                {
                    Id = 1,
                    Nombre = "Saneamiento y ampliación del Resguardo Kankuamo",
                    Descripcion = "",
                    EstrategiaId = 1
                },
                new Programa
                {
                    Id = 2,
                    Nombre = "Protección y Recuperación de Espacios Sagrados",
                    Descripcion = "rotección y Recuperación de Espacios Sagrados",
                    EstrategiaId = 1
                },
                new Programa
                {
                    Id = 3,
                    Nombre = "Conservacion y proteccion ambiental  del territorio kankuamo.",
                    Descripcion = "",
                    EstrategiaId = 2
                },
                new Programa
                {
                    Id = 4,
                    Nombre = "Conservacion y proteccion ambiental  del territorio kankuamo.",
                    Descripcion = "",
                    EstrategiaId = 3
                },
                new Programa
                {
                    Id = 5,
                    Nombre = "Conservacion y proteccion ambiental  del territorio kankuamo.",
                    Descripcion = "",
                    EstrategiaId = 4
                },
                new Programa
                {
                    Id = 6,
                    Nombre = "Fortalecimiento de los instrumentos y mecanismos internos para el Control Social del pueblo kankuamo ",
                    Descripcion = "",
                    EstrategiaId = 6
                },
                new Programa
                {
                    Id = 7,
                    Nombre = "Recuperaciòn del tejido sociocultural para garantizar el diálogo intergeneracional y la reapropiación de las Normas Propias",
                    Descripcion = "Recuperaciòn del tejido sociocultural para garantizar el diálogo intergeneracional y la reapropiación de las Normas Propias",
                    EstrategiaId = 6
                },
                new Programa
                {
                    Id = 8,
                    Nombre = "Fortalecimeinto de la autonomia alimentaria del pueblo kankuamo.",
                    Descripcion = "",
                    EstrategiaId = 7
                },
                new Programa
                {
                    Id = 9,
                    Nombre = "Fortalecimiento, promoción  de los sistemas propios de economía del pueblo kankuamo.",
                    Descripcion = "",
                    EstrategiaId = 7
                },
                new Programa
                {
                    Id = 10,
                    Nombre = "Fortalecimiento de la calidad de vida mediante la construcción y mejoramiento de viviendas en las comunidades del Resguardo Kankuamo",
                    Descripcion = "",
                    EstrategiaId = 8
                },
                new Programa
                {
                    Id = 11,
                    Nombre = "Construcción y Fortalecimiento de la infraestructura vial del Resguardo Kankuamo",
                    Descripcion = "",
                    EstrategiaId = 8
                },
                new Programa
                {
                    Id = 12,
                    Nombre = "Educación propia.",
                    Descripcion = "",
                    EstrategiaId = 9
                },
                new Programa
                {
                    Id = 13,
                    Nombre = "Construccion e Implementacion del Sistema Intercultural de Salud  Propia del Pueblo Kankuamo",
                    Descripcion = "",
                    EstrategiaId = 10
                },
                new Programa
                {
                    Id = 14,
                    Nombre = "Salvaguarda, restablecimiento y garantias de los derechos colectivos e individuales.",
                    Descripcion = "",
                    EstrategiaId = 11
                },
                new Programa
                {
                    Id = 15,
                    Nombre = "Salvaguarda, restablecimiento y garantias de los derechos colectivos e individuales.",
                    Descripcion = "",
                    EstrategiaId = 12
                },
                new Programa
                {
                    Id = 16,
                    Nombre = "Programa de Protección Propia.",
                    Descripcion = "",
                    EstrategiaId = 13
                },
                new Programa
                {
                    Id = 17,
                    Nombre = "Impulso a las actividades de recuperación, reconstrucción y fortalecimiento de los procesos de autonomia alimentaria atraves de los procesos y visión propia del Pueblo Kankuamo",
                    Descripcion = "",
                    EstrategiaId = 14
                },
                new Programa
                {
                    Id = 18,
                    Nombre = "Fortalecimiento de las capacidades organizativas y técnicas de los miembros del pueblo kankuamo en situación de desplazamiento.",
                    Descripcion = "",
                    EstrategiaId = 15
                },
                new Programa
                {
                    Id = 19,
                    Nombre = "Incentivar y Reactivar la Productividad en la población Kankuama en situación de desplazamiento, para fortalecer procesos de estabilización socioeconómica y retorno digno.",
                    Descripcion = "",
                    EstrategiaId = 16
                }
            );
        }

        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<CertificadoDeDisponibilidadPresupuestal> CDPs { get; set; }
        public DbSet<Componente> Componente { get; set; }
        public DbSet<Compromiso> Compromiso { get; set; }
        public DbSet<Comunidad> Comunidad { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Dimension> Dimension { get; set; }
        public DbSet<DocumentoPresupuestal> DocumentoPresupuestal { get; set; }
        public DbSet<Estrategia> Estrategia { get; set; }
        public DbSet<Programa> Programa { get; set; }
        public DbSet<RegistroPresupuestal> RegistroPresupuestal { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<IngresoOnceava> IngresoOnceava { get; set; }
    }
}