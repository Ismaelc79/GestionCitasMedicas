

namespace GestionCitasMedicas.Models
{
    public abstract class Persona
    {
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public int? Edad { get; set; }
        public String? Cedula { get; set; }
        public String? Telefono { get; set; }
        public String? Correo { get; set; }
        public String? Direccion { get; set; }

    }
}
