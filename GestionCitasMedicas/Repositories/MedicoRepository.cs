using GestionCitasMedicas.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestionCitasMedicas.Repositories
{
    public class MedicoRepository
    {
        private List<Medico> medicos = new();
        public void Agregar()
        {
          
            medicos.Add(new Medico());
            Console.WriteLine("Médico agregado con éxito...");
        }

        public List<Medico> ObtenerMedicos(){ 
            return medicos;
        }
    }
}
