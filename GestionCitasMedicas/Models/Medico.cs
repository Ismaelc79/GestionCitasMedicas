using GestionCitasMedicas.Models;


namespace GestionCitasMedicas.Entities
{
    public  class Medico : Persona
    {
        public String? IdMedico { get; set; }
        public Especialidad? Especialidad { get; set; }
        
    }
}
