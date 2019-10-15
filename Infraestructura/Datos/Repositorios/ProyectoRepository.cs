using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;

namespace Infraestructura.Datos.Repositorios
{
    public class ProyectoRepository : GenericRepository<Proyecto>
    {
        public ProgramaRepository(DbContext context) : base(context) { }
    }
}
