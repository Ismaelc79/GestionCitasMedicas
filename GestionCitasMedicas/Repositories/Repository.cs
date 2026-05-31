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
            Console.WriteLine("Datos agregados con éxito!");
        }

        public List<T> ObtenerTodos()
        {
           return datos;
        }
    }
}
