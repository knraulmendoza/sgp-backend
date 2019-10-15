using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Compromiso : BaseEntity
    {
        public string Nombre { get; set; }
        public Convenio Convenio { get; set; }

        public Compromiso() { }
    }
}
