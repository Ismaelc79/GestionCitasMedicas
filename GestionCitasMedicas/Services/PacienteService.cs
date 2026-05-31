using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Services
{
    public class PacienteService
    {
        private PacienteRepository repository;

        public PacienteService(PacienteRepository repository)
        {
            this.repository = repository;
        }

        public void RegistrarPaciente(
            string nombre,
            string apellido,
            int edad,
            string cedula,
            string telefono,
            string correo,
            string direccion,
            string idPaciente,
            string esPacienteActivo)
        {
            
            Paciente paciente = new()
            {
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Cedula = cedula,
                Telefono = telefono,
                Correo = correo,
                Direccion = direccion,
                IdPaciente = idPaciente,
                EsPacienteActivo = esPacienteActivo
            };
            repository.Agregar(paciente);

        }

    }
}

