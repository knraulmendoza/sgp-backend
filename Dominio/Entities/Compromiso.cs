using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    class Compromiso : BaseEntity
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Convenio Convenio { get; set; }
    }
}
