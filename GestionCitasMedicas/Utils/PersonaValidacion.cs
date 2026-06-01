using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Validators
{
    public static class PersonaValidacion
    {
        public static bool ValidarCedula(string cedula)
        {
            return !string.IsNullOrWhiteSpace(cedula) && cedula.Length == 10;
        }
    }
}
