using SistemaInventario.AccesoDatos;

namespace SistemaInventario.LogicaNegocio
{
    public class FabricaServicios
    {
        /// <summary>
        /// Crea el servicio de categorías con sus repositorios.
        /// </summary>
        public CategoriaServicio CrearCategoriaServicio()
        {
            RepositorioCategoria repo = new RepositorioCategoria();
            RepositorioProducto productos = new RepositorioProducto();
            RepositorioImagen imagenes = new RepositorioImagen();
            return new CategoriaServicio(repo, productos, imagenes);
        }

        /// <summary>
        /// Crea el servicio de suplidores con sus repositorios.
        /// </summary>
        public SuplidorServicio CrearSuplidorServicio()
        {
            RepositorioSuplidor repo = new RepositorioSuplidor();
            RepositorioProducto productos = new RepositorioProducto();
            return new SuplidorServicio(repo, productos);
        }

        /// <summary>
        /// Crea el servicio de productos con sus repositorios.
        /// </summary>
        public ProductoServicio CrearProductoServicio()
        {
            RepositorioProducto repo = new RepositorioProducto();
            RepositorioCategoria categorias = new RepositorioCategoria();
            RepositorioSuplidor suplidores = new RepositorioSuplidor();
            return new ProductoServicio(repo, categorias, suplidores);
        }
    }
}
