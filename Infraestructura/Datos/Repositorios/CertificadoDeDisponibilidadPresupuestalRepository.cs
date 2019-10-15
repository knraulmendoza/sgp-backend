using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;

namespace Infraestructura.Datos.Repositorios
{
    public class CertificadoDeDisponibilidadPresupuestalRepository : GenericRepository<CertificadoDeDisponibilidadPresupuestalRepository>
    {
        public CertificadoDeDisponibilidadPresupuestalRepository(DbContext context) : base(context) { }
    }
}
