namespace Dominio.Entities
{
    public class ProyectoComunidad : BaseEntity
    {
        public long ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        public long ComunidadId { get; set; }
        public Comunidad Comunidad { get; set; }
        public ProyectoComunidad() { }
    }
}
