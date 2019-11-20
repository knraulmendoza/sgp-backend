using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities
{
    public class TransaccionBinaria : Transaccion, IDetalleDelMovimiento
    {
        [ForeignKey("ProyectoDeDestino")]
        public long IdProyectoDestino { get; set; }
        public Proyecto ProyectoDeDestino { get; set; }
        public string Concepto {get; set;}

        public TransaccionBinaria() { }
    }
}
