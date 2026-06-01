

using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;

namespace GestionCitasMedicas.Services
{
    public class RecordatorioService
    {
        private INotificacionService recordatorioService;

        public RecordatorioService(INotificacionService recordatorioService)
        {
            this.recordatorioService = recordatorioService;
        }
        public void EnviarRecordatorio(Cita cita)
        {
            if(string.IsNullOrEmpty(cita.Paciente?.Correo))
            {
                Console.WriteLine("El paciente no tiene un correo electrónico registrado.");
                return;
            }
            string mensaje = $"Recordatorio: Tienes una cita programada para el {cita.FechaHora:dd/MM/yyyy HH:mm} con el Dr. " +
            $"{cita.Medico?.Nombre}.";

            recordatorioService.EnviarNotificacion(cita.Paciente.Correo, mensaje);
        }
    }
}
