using GestionCitasMedicas.Models;


namespace GestionCitasMedicas.Entities
{
    public class Paciente : Persona
    {
       public String? IdPaciente { get; set; }
       public String? EsPacienteActivo { get; set; }
       public List<Cita> Cita { get; set; } = new List<Cita>();
    }
}
