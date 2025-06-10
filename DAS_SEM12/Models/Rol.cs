namespace DAS_SEM12.Models
{
    public class Rol
    {
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
