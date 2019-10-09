﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    class RegistroPresupuestal : DocumentoPresupuestal
    {
        public long Id { get; set; }
        public DateTime VigenciaFiscal { get; set; }
        public Beneficiario Beneficiario { get; set; }
        public string identificacion { get; set; }
        public CompromisoType CompromisoType { get; set; }
        public Presupuesto Presupuesto { get; set; }
        public Compromiso Compromiso { get; set; }
    }
}
