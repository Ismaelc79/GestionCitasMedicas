using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Services
{
    public class EspecialidadService
    {
     private EspecialidadRepository repository;

        public EspecialidadService(EspecialidadRepository repository)
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
    }
}
