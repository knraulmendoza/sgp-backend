namespace Dominio.Entities
{
    public class Egreso : Movimiento
    {
        public Proyecto ProyectoDeDestino { get; set; }

        public Egreso() { }
    }
}