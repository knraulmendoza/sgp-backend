using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;

namespace Infraestructura.Datos.Repositorios
{
    public class ConvenioRepository : GenericRepository<Convenio>
    {
        public ConvenioRepository(DbContext context) : base(context) { }
    }
}
