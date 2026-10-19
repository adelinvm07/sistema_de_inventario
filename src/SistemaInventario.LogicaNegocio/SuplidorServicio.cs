using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
    public class SuplidorServicio
    {
        private readonly IRepositorio<Suplidores> _repo;
        private readonly IRepositorio<Productos> _productos;

        /// <summary>
        /// Recibe los repositorios necesarios para las reglas de negocio.
        /// </summary>
        public SuplidorServicio(IRepositorio<Suplidores> repo, IRepositorio<Productos> productos)
        {
            _repo = repo;
            _productos = productos;
        }

        /// <summary>
        /// Devuelve los registros activos.
        /// </summary>
        public List<Suplidores> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        /// <summary>
        /// Valida los datos e inserta o actualiza el registro.
        /// </summary>
        public Dictionary<string, string> Guardar(Suplidores entidad)
        {
            Dictionary<string, string> errores = Validador.ValidarSuplidor(entidad);
            if (errores.Count > 0)
                return errores;

            entidad.NombreEmpresa = entidad.NombreEmpresa.Trim();
            List<Suplidores> registros = _repo.ObtenerTodos();
            registros.AddRange(_repo.ObtenerEliminados());
            foreach (Suplidores registro in registros)
            {
                if (registro.Id != entidad.Id && String.Equals(registro.NombreEmpresa.Trim(), entidad.NombreEmpresa, StringComparison.OrdinalIgnoreCase))
                    errores["NombreEmpresa"] = "Ya existe un registro con ese nombre, incluso en la papelera.";
            }

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
            Suplidores entidad = _repo.ObtenerPorId(id);
            if (entidad == null || !entidad.Activo)
                return "El registro ya no está activo.";
            foreach (Productos producto in _productos.ObtenerTodos())
            {
                if (producto.IdSuplidor == id)
                    return "No se puede eliminar el suplidor porque tiene productos activos.";
            }
            _repo.Eliminar(id);
            return "";
        }

        /// <summary>
        /// Restaura el registro; devuelve el motivo si una regla lo impide.
        /// </summary>
        public string Restaurar(int id)
        {
            Suplidores entidad = _repo.ObtenerPorId(id);
            if (entidad == null)
                return "No se encontró el registro.";
            _repo.Restaurar(id);
            return "";
        }

        /// <summary>
        /// Devuelve los registros de la papelera.
        /// </summary>
        public List<Suplidores> ObtenerEliminados()
        {
            return _repo.ObtenerEliminados();
        }

        /// <summary>
        /// Busca por parte del nombre sin distinguir mayúsculas.
        /// </summary>
        public List<Suplidores> Buscar(string texto)
        {
            texto = texto.Trim();
            return _repo.ObtenerTodos().Where(registro => registro.NombreEmpresa.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Devuelve los cinco suplidores activos con más productos, en orden descendente.
        /// </summary>
        public List<Suplidores> ObtenerTop5ConMasProductos()
        {
            List<Suplidores> suplidores = _repo.ObtenerTodos();
            List<int> idsActivos = suplidores.Select(suplidor => suplidor.Id).ToList();
            List<int> ids = _productos.ObtenerTodos()
                .Where(producto => idsActivos.Contains(producto.IdSuplidor))
                .GroupBy(producto => producto.IdSuplidor)
                .OrderByDescending(grupo => grupo.Count()).ThenBy(grupo => grupo.Key)
                .Take(5).Select(grupo => grupo.Key).ToList();
            List<Suplidores> resultado = new List<Suplidores>();
            foreach (int id in ids)
            {
                foreach (Suplidores suplidor in suplidores)
                {
                    if (suplidor.Id == id)
                        resultado.Add(suplidor);
                }
            }
            return resultado;
        }
    }
}
