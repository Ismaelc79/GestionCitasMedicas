using GestionCitasMedicas.Models;


namespace GestionCitasMedicas.Entities
{
    public class Paciente : Persona
    {
       public String? IdPaciente { get; set; }
       public bool? EsPacienteActivo { get; set; }
    }
}
