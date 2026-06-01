using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Services
{
    public class PacienteService
    {
        private IRepository<Paciente> repository;

        public PacienteService(IRepository<Paciente> repository)
        {
            this.repository = repository;
        }

        public void RegistrarPaciente(
            string idPaciente,
            string nombre,
            string apellido,

            string cedula,
            string telefono,
            string correo)
        {

            var paciente = new Paciente
            {
                IdPaciente = idPaciente,
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Telefono = telefono,
                Correo = correo
            };

            repository.Agregar(paciente);
            Console.WriteLine("Paciente agregado con éxito!");

        }
        public List<Paciente> ObtenerPacientes()
        {
            return repository.ObtenerTodos();
        }
    }
}

