using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Services
{
    public class MedicoService
    {
        private IRepository<Medico> repository;

        public MedicoService(IRepository<Medico> repository)
        {
            this.repository = repository;
        }

        public void RegistrarMedico(
            string nombre,
            string apellido,
            int edad,
            string cedula,
            string telefono, 
            string correo,
            string direccion,
            string idMedico,
            string exequatur,
            DateTime horarioTrabajo,
            decimal sueldo
            )
        {
            Medico medico = new()
            {
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Cedula = cedula,
                Telefono = telefono,
                Correo = correo,
                Direccion = direccion,
                IdMedico = idMedico,
                Exequatur = exequatur,
                HorarioTrabajo = horarioTrabajo,
                Sueldo = (decimal)sueldo
            };
            repository.Agregar(medico);
                
        }
    }
}
