using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Validators
{
    public static class CitaValidacion
    {
        public static bool ValidarFechaHora(DateTime fechaHora)
        {
            if (fechaHora < DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public static bool ValidarIdCita(String idCita)
        {
            return !string.IsNullOrEmpty(idCita);
        }
    }
}
