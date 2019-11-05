using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Beneficiario : BaseEntity
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }
    }
}
