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
        Paciente paciente = new()
        {
            

        };

        public PacienteService(IRepository<Paciente> repository)
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

