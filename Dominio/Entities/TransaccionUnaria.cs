
namespace Dominio.Entities
{
    public class TransacciónUnaria : Transaccion, IDetalleDelMovimiento
    {
        public TransacciónUnaria() { }

        public string Concepto { get; set; }
    }

}