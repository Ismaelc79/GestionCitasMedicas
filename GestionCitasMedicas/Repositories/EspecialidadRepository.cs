using GestionCitasMedicas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Repositories
{
    public class EspecialidadRepository
    {
        private List<Especialidad> especialidades = new();

        public void Agregar(Especialidad especialidad)
        {
            especialidades.Add(especialidad);
            Console.WriteLine("Especialidad agregada con éxito...");
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            return especialidades;
        }
    }
}
