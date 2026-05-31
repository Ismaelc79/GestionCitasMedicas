

using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;

namespace GestionCitasMedicas.Services
{
    public class RecordatorioService
    {
        IRepository<Paciente> repository;
        public void EnviarRecordatorio(Paciente paciente, Cita cita)
        {
            repository.ObtenerTodos().ForEach(p =>
            {
                if (p.IdPaciente == paciente.IdPaciente)
                {
                    Console.WriteLine(
                    $"Enviando recordatorio de cita médica a {p.Nombre}..."
                        
                   );
                }
            });

        }
    }
}
