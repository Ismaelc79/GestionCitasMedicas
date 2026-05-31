using GestionCitasMedicas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Repositories
{
    public class PacienteRepository
    {
        private List<Paciente> pacientes = new();

        public void Agregar()
        {
            pacientes.Add(new Paciente());
            Console.WriteLine("Paciente agregado con éxito...");
        }

        public List<Paciente> ObtenerPaciente()
        {
            return pacientes;
        }
    }
}
