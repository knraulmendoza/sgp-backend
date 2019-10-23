using Dominio;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;

namespace Aplicación
{
    public abstract class GenericService<TEntity> where TEntity : BaseEntity
    {
        public abstract IList<TEntity> Get();

        public abstract int Insert(TEntity entity);

        public abstract int Delete(long id);

        public abstract int Update(TEntity entity);

        public abstract TEntity Get(long id);
    }
}
