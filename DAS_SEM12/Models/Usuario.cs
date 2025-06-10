namespace DAS_SEM12.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int idRol { get; set; }
        public Rol rol { get; set; }
    }
}
