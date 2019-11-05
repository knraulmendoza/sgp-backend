using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Controllers.Generics
{
    public abstract class GenericController<TEntity> where TEntity : BaseEntity
    {
        public abstract ActionResult<IEnumerable<TEntity>> GetAll();

        public abstract TEntity Insert(TEntity entity);

        public abstract TEntity Delete(long id);

        public abstract TEntity Update(TEntity entity);

        public abstract TEntity Get(long id);
    }
}
