
namespace Dominio.Entities
{
    public class TransacciónUnaria : Transaccion, IDetalleDelMovimiento
    {
        public string Concepto { get; set; }

        public TransacciónUnaria() { }
    }

}