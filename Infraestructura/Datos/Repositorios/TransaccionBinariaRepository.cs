using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repositorios
{
    public class TransaccionBinariaRepository : GenericRepository<TransaccionBinaria>
    {
        public TransaccionBinariaRepository(DbContext context) : base(context) {}
    }
}