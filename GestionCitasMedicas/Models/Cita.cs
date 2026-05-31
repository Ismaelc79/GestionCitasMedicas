
namespace GestionCitasMedicas.Entities
{
    public class Cita
    {
       public String? IdCita { get; set; }
       public String? EstadoCita { get; set; }
       public String? DescripcionCita { get; set; } 
       public DateTime? FechaHoraCita { get; set; } 
       public Paciente Paciente { get; set; }
       public Medico Medico { get; set; }


    }
}
