using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class CDP : DocumentoPresupuestal
    {
        public DateTime FechaDeVencimiento { get; set; }
        
        public RegistroPresupuestal RegistroPresupuestal { get; set; }

        public CDP() { }
    }
}
