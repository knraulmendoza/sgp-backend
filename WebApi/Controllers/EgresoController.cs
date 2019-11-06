using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EgresoController : GenericController<Egreso>, EgresoContract
    {
        private UnitOfWork uow;

        public override Egreso Delete(long id)
        {
            uow = new UnitOfWork();
            uow.EgresoRepository.Delete(id);
            uow.Dispose();
            return null;
        }

        public override Egreso Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Egreso> res = uow.EgresoRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        [HttpGet]
        public override ActionResult<IEnumerable<Egreso>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.EgresoRepository.Get();
            return res.ToList();
        }

        public IList<Egreso> GetGastosProyectos(long idProyecto)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IList<Proyecto> GetProyectosConRP(string proyectoState)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public override Egreso Insert(Egreso entity)
        {
            uow = new UnitOfWork();
            uow.EgresoRepository.Insert(entity);
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public override Egreso Update(Egreso entity)
        {
            uow = new UnitOfWork();
            uow.EgresoRepository.Update(entity);
            return entity;
        }
    }
}