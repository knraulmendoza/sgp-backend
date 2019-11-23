using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities
{
    public class TransaccionBinaria : Transaccion
    {
        [ForeignKey("ProyectoDeDestino")]
        public long IdProyectoDestino { get; set; }
        public Proyecto ProyectoDeDestino { get; set; }

        public TransaccionBinaria() { }
    }
}
