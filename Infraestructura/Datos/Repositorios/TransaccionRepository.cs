using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class TransaccionRepository : GenericRepository<Transaccion>
    {
        public TransaccionRepository(DbContext context) : base(context) { }
    }
}
