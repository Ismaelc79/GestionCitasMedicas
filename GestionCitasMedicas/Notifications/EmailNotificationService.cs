using GestionCitasMedicas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Notifications
{
    public class EmailNotificationService : INotificacionService
    {
        public void EnviarNotificacion(string destinatario, string mensaje)
        {
            Console.WriteLine($"[Email enviado a: {destinatario}]: {mensaje}");
        }
    }
}
