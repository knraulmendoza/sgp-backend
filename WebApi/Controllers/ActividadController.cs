using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActividadController : GenericController<Actividad>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<Actividad> Delete(long id)
        {
            // Actividad entity = Get(id);
            uow = new UnitOfWork();
            Actividad entity = uow.ActividadRepository.GetByID(id);
            uow.ActividadRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return entity;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Actividad>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ActividadRepository.Get();;
            return res.ToList();
        }

        [HttpGet("{id}")]
        public  ActionResult<Actividad> Get(long id)
        {
            uow = new UnitOfWork();
            Actividad res = uow.ActividadRepository.GetByID(id);
            uow.Dispose();
            return res;
        }
        [HttpPost]
        public ActionResult<Actividad> Insert(Actividad entity)
        {
            uow = new UnitOfWork();
            uow.ActividadRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<Actividad> Update(Actividad entity)
        {
            uow = new UnitOfWork();
            uow.ActividadRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
