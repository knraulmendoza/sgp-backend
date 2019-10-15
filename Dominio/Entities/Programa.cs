using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Programa : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Proyecto> Proyectos { get; set; }

        public Programa() { }
    }
}
