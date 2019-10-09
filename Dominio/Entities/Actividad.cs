using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Actividad : BaseEntity
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public int ActividadState { get; set; }
        public Meta Meta { get; set; }
        public Indicador Indicador { get; set; }
        public float Costo { get; set; }
    }
}
