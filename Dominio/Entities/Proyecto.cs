using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Proyecto : BaseEntity
    {
        public long PropuestaId { get; set; }
        public Propuesta Propuesta { get; set; }
        public ProyectoState ProyectoState { get; set; }
        public string Nombre { get; set; }
        public decimal PresupuestoAprobado { get; set; }
        public decimal PresupuestoEjecutado { get; set; }
        public List<ProyectoComunidad> ProyectosComunidads { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public List<CDP> CDPs { get; set; }
        public List<TransaccionUnaria> TransaccionesUnarias { get; set; }
        public List<TransaccionBinaria> TransaccionesBinarias { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaDeCierrePrevista { get; set; }
        public long ProgramaId { get; set; }
        public Programa Programa { get; set; }
        public List<Actividad> Actividades { get; set; }
        public IList<Beneficiario> Beneficiarios { get; set; }
        public Proyecto() { }

    }
}
