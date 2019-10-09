using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    class Comunidad : BaseEntity
    {
        public long Id { get; set; }
        public string Comunidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
