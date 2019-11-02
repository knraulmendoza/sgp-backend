using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Controllers.Generics
{
    public abstract class GenericController<TEntity> where TEntity : BaseEntity
    {
        public abstract ActionResult<IEnumerable<TEntity>> GetAll();

        public abstract int Insert(TEntity entity);

        public abstract int Delete(long id);

        public abstract int Update(TEntity entity);

        public abstract TEntity Get(long id);
    }
}
