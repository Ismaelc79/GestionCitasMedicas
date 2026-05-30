using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Interfaces
{
    public interface INotificacionService
    {
        public void EnviarNotificacion(string destinatario, string mensaje);
    }
}
