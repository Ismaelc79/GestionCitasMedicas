using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Validators
{
    public static class CitaValidacion
    {
        public static bool ValidarFechaHora(DateTime fechaHora)
        {
            return fechaHora > DateTime.Now;
        }
    }
}
