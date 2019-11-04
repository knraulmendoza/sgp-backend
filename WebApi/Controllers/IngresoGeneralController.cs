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
    [Route("api/[controller]")]
    public class IngresoGeneralController : GenericController<IngresoGeneral>
    {
        private UnitOfWork uow;

        [HttpDelete]
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.IngresoGeneralRepository.Delete(id);
            uow.Dispose();
            return 1;
        }
        [HttpGet]
        public override ActionResult<IEnumerable<IngresoGeneral>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.IngresoGeneralRepository.Get();
            return res.ToList();
        }

        [HttpGet]
        public override IngresoGeneral Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<IngresoGeneral> res = uow.IngresoGeneralRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }
        [HttpPost]
        public override int Insert(IngresoGeneral entity)
        {
            uow = new UnitOfWork();
            uow.IngresoGeneralRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        [HttpPut]
        public override int Update(IngresoGeneral entity)
        {
            uow = new UnitOfWork();
            uow.IngresoGeneralRepository.Update(entity);
            return 1;
        }
    }
}
