using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Componente : BaseEntity
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Estrategia> Estrategias { get; set; }
    }
}
