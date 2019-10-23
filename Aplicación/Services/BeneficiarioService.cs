using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class BeneficiarioService : GenericService<Beneficiario>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<Beneficiario> Get()
        {
            uow = new UnitOfWork();
            var res = uow.BeneficicarioRepository.Get();
            return res.ToList();
        }

        public override Beneficiario Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Beneficiario> res = uow.BeneficicarioRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(Beneficiario entity)
        {
            uow = new UnitOfWork();
            uow.BeneficicarioRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Beneficiario entity)
        {
            uow = new UnitOfWork();
            uow.BeneficicarioRepository.Update(entity);
            return 1;
        }
    }
}
