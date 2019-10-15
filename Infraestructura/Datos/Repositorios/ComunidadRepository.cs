using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;

namespace Infraestructura.Datos.Repositorios
{
    public class ComunidadRepository : GenericRepository<Comunidad>
    {
        public ComunidadRepository(DbContext context) : base(context) { }
    }
}
