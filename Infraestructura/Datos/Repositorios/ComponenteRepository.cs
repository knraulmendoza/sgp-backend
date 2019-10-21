﻿using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Infraestructura.Utils;

namespace Infraestructura.Datos.Repositorios
{
    public class ComponenteRepository : GenericRepository<Componente>
    {
        public ComponenteRepository(DbContext context) : base(context) { }

    }
}