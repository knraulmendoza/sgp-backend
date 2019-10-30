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
    public class ProyectoController : GenericController<Proyecto>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Proyecto Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> res = uow.ProyectoRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Proyecto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Update(entity);
            return 1;
        }
    }
}
