using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class DocumentoPresupuestal : BaseEntity
    {
        public DateTime FechaDeExpedicion { get; set; }
        public string Codigo { get; set; }

        public DocumentoPresupuestal() { }
    }
}
