using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    class DocumentoPresupuestal : BaseEntity
    {
        public long Id { get; set; }
        public DateTime FechaDeExpedicion { get; set; }
        public string Codigo { get; set; }

    }
}
