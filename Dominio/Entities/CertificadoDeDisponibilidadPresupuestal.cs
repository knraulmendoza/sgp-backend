using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    class CertificadoDeDisponibilidadPresupuestal : DocumentoPresupuestal
    {
        public long Id { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public RegistroPresupuestal RegistroPresupuestal { get; set; }
    }
}
