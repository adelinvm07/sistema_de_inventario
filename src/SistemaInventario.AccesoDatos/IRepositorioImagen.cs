using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos
{
    public interface IRepositorioImagen : IRepositorio<ImagenCategoria>
    {
        /// <summary>
        /// Devuelve las fotos activas de una categoría.
        /// </summary>
        List<ImagenCategoria> ObtenerPorCategoria(int idCategoria);
    }
}
