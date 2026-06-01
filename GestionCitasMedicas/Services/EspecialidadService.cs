using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Services
{
    public class EspecialidadService
    {
        private IRepository<Especialidad> repository;

        public EspecialidadService(IRepository<Especialidad> repository)
        {
            this.repository = repository;
        }

        public void RegistrarEspecialidad(
        string nombre,
        string codigoEspecialidad)
        {
            var especialidad = new Especialidad
            {
                IdEspecialidad = codigoEspecialidad,
                NombreEspecialidad = nombre
            };
            repository.Agregar(especialidad);
            Console.WriteLine("Especialidad agregada con éxito!");
        }

        public void AsignarMedicoEspecialidad(Medico medico, Especialidad especialidad)
        {
            medico.Especialidad = especialidad;
            Console.WriteLine("Especialidad asignada con éxito!");
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            return repository.ObtenerTodos();
        }
    }
}
