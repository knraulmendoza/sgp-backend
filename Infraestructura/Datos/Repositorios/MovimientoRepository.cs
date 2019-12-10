using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class MovimientoRepository : GenericRepository<Movimiento>
    {
        public MovimientoRepository(DbContext context) : base(context)
        {
        }

        public override void Delete(long id)
        {
            base.Delete(id);
        }

        public override void Delete(Movimiento entityToDelete)
        {
            base.Delete(entityToDelete);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override IEnumerable<Movimiento> Get(Expression<Func<Movimiento, bool>> filter = null, Func<IQueryable<Movimiento>, IOrderedQueryable<Movimiento>> orderBy = null, string includeProperties = "")
        {
            return base.Get(filter, orderBy, includeProperties);
        }

        public override Movimiento GetByID(long id)
        {
            return base.GetByID(id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Movimiento Insert(Movimiento entity)
        {
            return base.Insert(entity);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Update(Movimiento entityToUpdate)
        {
            base.Update(entityToUpdate);
        }
    }
}