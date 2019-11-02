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
    public class CertificadoDeDisponibilidadPresupuestalService : GenericController<CertificadoDeDisponibilidadPresupuestal>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override CertificadoDeDisponibilidadPresupuestal Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<CertificadoDeDisponibilidadPresupuestal> res = uow.CertificadoDeDisponibilidadPresupuestalRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<CertificadoDeDisponibilidadPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CertificadoDeDisponibilidadPresupuestalRepository.Get();
            return res.ToList();
        }

        public override int Insert(CertificadoDeDisponibilidadPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(CertificadoDeDisponibilidadPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Update(entity);
            return 1;
        }
    }
}
