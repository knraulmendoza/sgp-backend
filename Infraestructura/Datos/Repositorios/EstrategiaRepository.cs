using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class EstrategiaRepository : GenericRepository<Estrategia>
    {
        public EstrategiaRepository(DbContext context) : base(context){ }
    }
}
