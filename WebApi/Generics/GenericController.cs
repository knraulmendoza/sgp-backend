using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Controllers.Generics
{
    public interface GenericController<TEntity> where TEntity : BaseEntity
    {
        public ActionResult<IEnumerable<TEntity>> GetAll();

        public ActionResult<TEntity> Insert(TEntity entity);

        public ActionResult<TEntity> Delete(long id);

        public ActionResult<TEntity> Update(TEntity entity);

        public ActionResult<TEntity> Get(long id);
    }
}
