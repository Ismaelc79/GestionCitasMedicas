using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Validators
{
    public static class PersonaValidacion
    {
        public static bool ValidarCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula) || cedula.Length != 10)
            {
                return false;
            }
            else
            {
                return true;
            }
               
            
        }
    }
}
