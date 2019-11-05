using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropuestaController : ControllerBase , PropuestaContract
    {
        private UnitOfWork uow;
        
        [HttpGet]
        public ActionResult<IEnumerable<Propuesta>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.PropuestaRepository.Get();
            return res.ToList();
        }
        
        [HttpPost]
        public int Insert(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return 1;
        }

        [HttpDelete]
        public  int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        [HttpPut]
        public  int Update(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Update(entity);
            uow.Save();
            return 1;
        }

        public IList<Componente> GetComponentesPorDimension(long idDimension)
        {
            throw new NotImplementedException();
        }

        public string GetArchivoDelProyecto(long idPropuesta)
        {
            uow = new UnitOfWork();
            var res = uow.PropuestaRepository.GetByID(idPropuesta);
            string respuesta = res.Documento.RespaldoFisicoDigitalizado.ToString();
            return respuesta;
        }
    }
}
