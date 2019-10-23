using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class DocumentoPresupuestalRepository : GenericRepository<DocumentoPresupuestal>
    {
        public DocumentoPresupuestalRepository(DbContext context): base(context) { }
    }
}
