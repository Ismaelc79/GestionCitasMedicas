
namespace GestionCitasMedicas.Entities
{
    public class Cita
    {
        public String? IdCita { get; set; } 
        public String? EstadoCita { get; set; } = "Activa";
       public DateTime? FechaHora { get; set; } 
       public Paciente Paciente { get; set; } = new Paciente();
       public Medico Medico { get; set; } = new Medico();


    }
}
