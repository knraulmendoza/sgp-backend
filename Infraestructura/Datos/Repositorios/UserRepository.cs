using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext context) : base(context){ }
    }
}