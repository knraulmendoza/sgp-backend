using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class ComunidadService : GenericService<Comunidad>
    {
        private UnitOfWork uow;
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<Comunidad> Get()
        {
            uow = new UnitOfWork();
            var res = uow.ComunidadRepository.Get();
            return res.ToList();
        }

        public override Comunidad Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Comunidad> res = uow.ComunidadRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
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
