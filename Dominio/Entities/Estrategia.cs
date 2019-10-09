﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Estrategia : BaseEntity
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Programa> Programas { get; set; }
    }
}
