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
        string codigoEspecialidad,
        string descripcion)
        {

            Especialidad especialidad = new()
            {
                NombreEspecialidad = nombre,
                CodigoEspecialidad = codigoEspecialidad,
                Descripcion = descripcion
            };
            repository.Agregar(especialidad);
        }

        public void AsignarMedicoEspecialidad(Medico medico, Especialidad especialidad)
        {
            medico.Especialidad = especialidad;
            
        }
    }
}
