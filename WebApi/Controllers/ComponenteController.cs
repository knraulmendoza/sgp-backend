using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponenteController : GenericController<Componente>
    {
        private UnitOfWork uow;
        public ActionResult<Componente> Delete(long id)
        {
            uow = new UnitOfWork();
            Componente res = uow.ComponenteRepository.GetByID(id);
            uow.ComponenteRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public ActionResult<Componente> Get(long id)
        {
            uow = new UnitOfWork();
            Componente res = uow.ComponenteRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public ActionResult<IEnumerable<Componente>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ComponenteRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public ActionResult<Componente> Insert(Componente entity)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public ActionResult<Componente> Update(Componente entity)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
