using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class ConvenioRepository : GenericRepository<Convenio>
    {
        public ConvenioRepository(DbContext context) : base(context) { }
    }
}
