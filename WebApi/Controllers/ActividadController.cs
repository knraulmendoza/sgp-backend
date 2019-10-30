using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActividadController : GenericController<Actividad>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ActividadRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override ActionResult<IEnumerable<Actividad>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ActividadRepository.Get();
            return res.ToList();
        }

        public override Actividad Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Actividad> res = uow.ActividadRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(Actividad entity)
        {
            uow = new UnitOfWork();
            uow.ActividadRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Actividad entity)
        {
            uow = new UnitOfWork();
            uow.ActividadRepository.Update(entity);
            return 1;
        }
    }
}
