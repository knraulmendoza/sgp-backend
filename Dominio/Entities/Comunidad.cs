﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Comunidad : BaseEntity
    {
        public string Comunidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Comunidad() { }
    }
}
