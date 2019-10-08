using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Utils
{
    public class SgpContext : DbContext
    {
        public DbSet<Propuesta> propuestas { get; set; }
    }
}
