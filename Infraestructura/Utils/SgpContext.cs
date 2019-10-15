using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Utils
{
    public class SgpContext : DbContext
    {
        private DbSet<Propuesta> propuestas { get; set; }
        private DbSet<Proyecto> proyectos { get; set; }
        private DbSet<Actividad> actividades { get; set; }
        private DbSet<CertificadoDeDisponibilidadPresupuestal> CDPs { get; set; }
        private DbSet<Componente> componente {get; set;} 
        private DbSet<Compromiso> compromiso { get; set; }
        private DbSet<Comunidad> comunidad { get; set; }
        private DbSet<Convenio> convenio { get; set; }
        private DbSet<Dimension> dimension { get; set; }
        private DbSet<DocumentoPresupuestal> documentoPresupuestal { get; set; }
        private DbSet<Estrategia> estrategia { get; set; }
        private DbSet<Programa> programa { get; set; }
        private DbSet<RegistroPresupuestal> registroPresupuestal { get; set; }
        private DbSet<Transaccion> transaccion { get; set; }
    }
}
