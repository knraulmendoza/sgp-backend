using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dominio.Entities
{
    public class Documento : BaseEntity
    {
        public string Nombre {get; set;}
        public File RespaldoFisicoDigitalizado {get; set;}

        public Documeto(){}
    }
}