using GestionCitasMedicas.Models;


namespace GestionCitasMedicas.Entities
{
    public  class Medico : Persona
    {
        public String? IdMedico { get; set; }
        public String? Exequatur { get; set; }
        public DateTime? HorarioTrabajo { get; set; }
        public decimal? Sueldo { get; set; }
        public Especialidad Especialidad { get; set; }
        public Cita Cita { get; set; }
        
    }
}
