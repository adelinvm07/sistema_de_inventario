using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos
{
    public interface IRepositorioCategoria : IRepositorio<Categoria>
    {
        /// <summary>
        /// Inserta la categoría y devuelve el id asignado.
        /// </summary>
        int InsertarYObtenerId(Categoria categoria);
    }
}
