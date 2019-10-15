using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;

namespace Infraestructura.Datos.Repositorios
{
    public class ActividadRepository : GenericRepository<Actividad>
    {
        public ActividadRepository(DdContext context) : base(context) { }
    }
}
