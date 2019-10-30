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
    public class ProgramaController : GenericController<Programa>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ProgramaRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Programa Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Programa> res = uow.ProgramaRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Programa>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ProgramaRepository.Get();
            return res.ToList();
        }

        public override int Insert(Programa entity)
        {
            uow = new UnitOfWork();
            uow.ProgramaRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Programa entity)
        {
            uow = new UnitOfWork();
            uow.ProgramaRepository.Update(entity);
            return 1;
        }
    }
}
