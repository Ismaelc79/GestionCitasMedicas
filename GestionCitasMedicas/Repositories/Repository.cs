using GestionCitasMedicas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected List<T> datos = new();
        public virtual void Agregar(T entidad)
        {
            datos.Add(entidad);
        }

        public List<T> ObtenerTodos()
        {
           return datos;
        }

        public virtual void Eliminar(T entidad)
        {
            datos.Remove(entidad);
        }

        public virtual void Actualizar(T entidad)
        {
     
        }

    }
}
