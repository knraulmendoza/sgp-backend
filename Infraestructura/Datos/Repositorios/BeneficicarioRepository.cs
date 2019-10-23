using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Datos.Repositorios
{
    public class BeneficicarioRepository : GenericRepository<Beneficiario>
    {
        public BeneficicarioRepository(DbContext context) : base(context)
        {
        }
    }
}
