using GestionCitasMedicas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Repositories
{
    public class CitaRepository
    {
        private List<Cita> citas = new();

        public void AgregarCita(Cita cita)
        {
            citas.Add(cita);
            Console.WriteLine("Cita agregada exitosamente");
        }

        public List<Cita> ObtenerCitas()
        {

         return citas;

        }

    }
}
