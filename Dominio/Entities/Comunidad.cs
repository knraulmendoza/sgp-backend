using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Comunidad : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<ProyectoComunidad> ProyectosComunidads { get; set; }
        public Comunidad() { }
    }
}