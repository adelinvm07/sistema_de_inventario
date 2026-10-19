using SistemaInventario.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    public class FabricaServicios
    {
        public CategoriaServicio CrearCategoriaServicio()
        {
            RepositorioCategoria repo = new RepositorioCategoria();
            return new CategoriaServicio(repo);
        }
        public SuplidorServicio CrearSuplidorServicio()
        {
            RepositorioSuplidor repo = new RepositorioSuplidor();
            return new SuplidorServicio(repo);
        }
        public ProductoServicio CrearProductoServicio()
        {
            RepositorioProducto repo = new RepositorioProducto();
            return new ProductoServicio(repo);
        }
    }
}
