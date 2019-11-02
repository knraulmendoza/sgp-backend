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
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Componente Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Componente> res = uow.ComponenteRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Componente>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ComponenteRepository.Get();
            return res.ToList();
        }

        public override int Insert(Componente entity)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Componente entity)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Update(entity);
            return 1;
        }
    }
}
