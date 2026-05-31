

namespace GestionCitasMedicas.Interfaces
{
    public interface IRepository<T>
    {
        void Agregar(T entidad);
        List<T> ObtenerTodos();

        void Eliminar(T entidad);

        void Actualizar(T entidad);
    }
}
