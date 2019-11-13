using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Proyecto : BaseEntity
    {
        public Propuesta Propuesta { get; set; }

        public ProyectoState ProyectoState { get; set; }

        public string Nombre { get; set; }

        public decimal PresupuestoAprobado { get; set; }

        public decimal PresupuestoEjecutado { get; set; }

        public List<Comunidad> Comunidad { get; set; }

        public DateTime FechaEjecucion { get; set; }

        public List<CertificadoDeDisponibilidadPresupuestal> CertificadosDeDisponibilidaPresupuestales { get; set; }

        /* Comentada por problemas de relación n a n */
        // public List<TransaccionBinaria> TransaccionesBinarias { get; set; }

        public List<TransaccionUnaria> TransaccionesUnarias { get; set; }

        public DateTime FechaCierre { get; set; }

        public DateTime FechaDeCierrePrevista { get; set; }

        public Programa Programa { get; set; }

        public List<Actividad> Actividades { get; set; }
        
        public IList<Beneficiario> Beneficiarios { get; set; }

        public Proyecto() { }

    }
}
