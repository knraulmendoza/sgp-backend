using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dominio.Entities
{
    public class Documento : BaseEntity
    {
        public string Nombre { get; set; }
        public byte[] RespaldoFisicoDigitalizado { get; set; }

        public Documento() { }
    }
}