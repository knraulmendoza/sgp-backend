using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class EgresoRepository : GenericRepository<Egreso>
    {
        public EgresoRepository(DbContext context) : base(context){ }
    }
}