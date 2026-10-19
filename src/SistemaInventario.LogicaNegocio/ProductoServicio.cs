using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
    public class ProductoServicio
    {
        private readonly IRepositorio<Productos> _repo;
        private readonly IRepositorio<Categoria> _categorias;
        private readonly IRepositorio<Suplidores> _suplidores;

        /// <summary>
        /// Recibe los repositorios necesarios para las reglas de negocio.
        /// </summary>
        public ProductoServicio(IRepositorio<Productos> repo, IRepositorio<Categoria> categorias, IRepositorio<Suplidores> suplidores)
        {
            _repo = repo;
            _categorias = categorias;
            _suplidores = suplidores;
        }

        /// <summary>
        /// Devuelve los registros activos.
        /// </summary>
        public List<Productos> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        /// <summary>
        /// Valida los datos e inserta o actualiza el registro.
        /// </summary>
        public Dictionary<string, string> Guardar(Productos entidad)
        {
            Dictionary<string, string> errores = Validador.ValidarProducto(entidad);
            if (errores.Count > 0)
                return errores;

            entidad.Nombre = entidad.Nombre.Trim();
            List<Productos> registros = _repo.ObtenerTodos();
            registros.AddRange(_repo.ObtenerEliminados());
            foreach (Productos registro in registros)
            {
                if (registro.Id != entidad.Id && String.Equals(registro.Nombre.Trim(), entidad.Nombre, StringComparison.OrdinalIgnoreCase))
                    errores["Nombre"] = "Ya existe un registro con ese nombre, incluso en la papelera.";
            }
            Categoria categoria = _categorias.ObtenerPorId(entidad.IdCategoria);
            if (categoria == null || !categoria.Activo)
                errores["IdCategoria"] = "Seleccione una categoría activa.";
            Suplidores suplidor = _suplidores.ObtenerPorId(entidad.IdSuplidor);
            if (suplidor == null || !suplidor.Activo)
                errores["IdSuplidor"] = "Seleccione un suplidor activo.";

            if (errores.Count > 0)
                return errores;

            if (entidad.Id == 0)
                _repo.Insertar(entidad);
            else
                _repo.Actualizar(entidad);
            return errores;
        }

        /// <summary>
        /// Elimina el registro de forma lógica; devuelve vacío si se pudo eliminar.
        /// </summary>
        public string Eliminar(int id)
        {
            Productos entidad = _repo.ObtenerPorId(id);
            if (entidad == null || !entidad.Activo)
                return "El registro ya no está activo.";
            _repo.Eliminar(id);
            return "";
        }

        /// <summary>
        /// Restaura el registro; devuelve el motivo si una regla lo impide.
        /// </summary>
        public string Restaurar(int id)
        {
            Productos entidad = _repo.ObtenerPorId(id);
            if (entidad == null)
                return "No se encontró el registro.";
            Categoria categoria = _categorias.ObtenerPorId(entidad.IdCategoria);
            if (categoria == null || !categoria.Activo)
                return "No se puede restaurar el producto porque su categoría está eliminada.";
            Suplidores suplidor = _suplidores.ObtenerPorId(entidad.IdSuplidor);
            if (suplidor == null || !suplidor.Activo)
                return "No se puede restaurar el producto porque su suplidor está eliminado.";
            _repo.Restaurar(id);
            return "";
        }

        /// <summary>
        /// Devuelve los registros de la papelera.
        /// </summary>
        public List<Productos> ObtenerEliminados()
        {
            return _repo.ObtenerEliminados();
        }

        /// <summary>
        /// Busca por parte del nombre sin distinguir mayúsculas.
        /// </summary>
        public List<Productos> Buscar(string texto)
        {
            texto = texto.Trim();
            return _repo.ObtenerTodos().Where(registro => registro.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Combina búsqueda, categoría, suplidor y límites de precio opcionales.
        /// </summary>
        public List<Productos> Filtrar(string texto, int idCategoria = 0, int idSuplidor = 0, decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            return Buscar(texto).Where(producto =>
                (idCategoria == 0 || producto.IdCategoria == idCategoria) &&
                (idSuplidor == 0 || producto.IdSuplidor == idSuplidor) &&
                (!precioMinimo.HasValue || producto.PrecioUnitario >= precioMinimo.Value) &&
                (!precioMaximo.HasValue || producto.PrecioUnitario <= precioMaximo.Value)).ToList();
        }

        /// <summary>
        /// Agrupa los productos activos por categoría y devuelve sus cantidades.
        /// </summary>
        public Dictionary<int, int> ContarPorCategoria()
        {
            return _repo.ObtenerTodos().GroupBy(producto => producto.IdCategoria)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());
        }

        /// <summary>
        /// Calcula el precio promedio de los productos activos de cada categoría.
        /// </summary>
        public Dictionary<int, decimal> PromedioPreciosPorCategoria()
        {
            return _repo.ObtenerTodos().GroupBy(producto => producto.IdCategoria)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.Average(producto => producto.PrecioUnitario));
        }

        /// <summary>
        /// Devuelve las categorías activas para seleccionar en un producto.
        /// </summary>
        public List<Categoria> ObtenerCategorias()
        {
            return _categorias.ObtenerTodos();
        }

        /// <summary>
        /// Devuelve los suplidores activos para seleccionar en un producto.
        /// </summary>
        public List<Suplidores> ObtenerSuplidores()
        {
            return _suplidores.ObtenerTodos();
        }
    }
}
