using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Dimension : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Componente> Componentes { get; set; }

        public Dimension() { }
    }
}
