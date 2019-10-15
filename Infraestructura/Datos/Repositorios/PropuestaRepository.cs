using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Datos.Repositorios
{
    public class PropuestaRepository : GenericRepository<Propuesta>
    {
        public PropuestaRepository (DbContext context): base(context){ }
    }
}
