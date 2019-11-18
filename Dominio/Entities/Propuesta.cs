using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Dominio.Entities.States;

namespace Dominio.Entities
{
    public class Propuesta : BaseEntity
    {
        public PropuestaState PropuestaState { get; set; }
        public DateTime FechaDePresentacion { get; set; }
        public DateTime FechaDeAprobacion { get; set; }
        public long DocumentoId { get; set; }
        public Documento Documento { get; set; }
        public IList<Beneficiario> Beneficiarios { get; set; }
        public int NumeroDeFamilias { get; set; }
        public string Nombre { get; set; }
        public decimal PresupuestoEstimado { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public Propuesta() { }
    }
}
