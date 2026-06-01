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
            string idMedico,
            string nombre,
            string apellido,
            string cedula,
            string telefono,
            string correo
            )
        {
            var medico = new Medico()
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Telefono = telefono,
                Correo = correo,
                IdMedico = idMedico,
            };
            repository.Agregar(medico);
            Console.WriteLine("Médico agregado con éxito!");     
        }

        public List<Medico> ObtenerMedicos(){
            return repository.ObtenerTodos();
        }
    }
}
