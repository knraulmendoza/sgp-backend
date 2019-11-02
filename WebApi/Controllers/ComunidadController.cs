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
    public class ComunidadController : GenericController<Comunidad>
    {
        private UnitOfWork uow;
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Comunidad Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Comunidad> res = uow.ComunidadRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Comunidad>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ComunidadRepository.Get();
            return res.ToList();
        }

        public override int Insert(Comunidad entity)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Comunidad entity)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Update(entity);
            return 1;
        }
    }
}
