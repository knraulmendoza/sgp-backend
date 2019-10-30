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
    public class PropuestaController : GenericController<Propuesta>, PropuestaContract
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        [HttpGet("propuestas/all")]
        public override ActionResult<IEnumerable<Propuesta>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.PropuestaRepository.Get();
            return res.ToList();
        }

        public override Propuesta Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Propuesta> res = uow.PropuestaRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Update(entity);
            return 1;
        }

        public IList<Componente> GetComponentesPorDimension(long idDimension)
        {
            uow = new UnitOfWork();
            IList<Dimension> res = uow.DimensionRepository.Get(
                d => d.Id == idDimension,
                null,
                "Componentes").ToList();
            uow.Save();
            uow.Dispose();
            return res.FirstOrDefault().Componentes;
        }
    }
}
