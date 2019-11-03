using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dominio.Entities
{
    public class Propuesta : BaseEntity
    {
        public DateTime FechaDePresentacion { get; set; }
        public DateTime FechaDeAprovacion {get; set;}
        public Documento Documento { get; set; }
        public IList<Beneficiario> Beneficiarios { get; set; }
        public int NumeroDeFamilias {get; set;}
        public string Nombre {get; set;}
        public Double PresupuestoEstimado {get; set;}
        public DateTime FechaDeRegistro {get; set;}

        public Propuesta() { }
    }
}
