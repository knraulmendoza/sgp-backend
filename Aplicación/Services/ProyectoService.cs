using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class ProyectoService : GenericService<Proyecto>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<Proyecto> Get()
        {
            uow = new UnitOfWork();
            var res = uow.ProyectoRepository.Get();
            return res.ToList();
        }

        public override Proyecto Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> res = uow.ProyectoRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Update(entity);
            return 1;
        }
    }
}
