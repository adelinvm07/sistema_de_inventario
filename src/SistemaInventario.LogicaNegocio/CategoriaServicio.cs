using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
    public class CategoriaServicio
    {
        private readonly IRepositorioCategoria _repo;
        private readonly IRepositorio<Productos> _productos;
        private readonly IRepositorioImagen _imagenes;

        /// <summary>
        /// Recibe los repositorios de categorías, productos y fotos.
        /// </summary>
        public CategoriaServicio(IRepositorioCategoria repo, IRepositorio<Productos> productos, IRepositorioImagen imagenes)
        {
            _repo = repo;
            _productos = productos;
            _imagenes = imagenes;
        }

        /// <summary>
        /// Devuelve las categorías activas.
        /// </summary>
        public List<Categoria> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }

        /// <summary>
        /// Valida y guarda la categoría antes de guardar sus fotos nuevas.
        /// </summary>
        public Dictionary<string, string> Guardar(Categoria categoria, List<string>? rutasFotos = null)
        {
            Dictionary<string, string> errores = Validador.ValidarCategoria(categoria);
            if (errores.Count > 0)
                return errores;

            categoria.Nombre = categoria.Nombre.Trim();
            List<Categoria> categorias = _repo.ObtenerTodos();
            categorias.AddRange(_repo.ObtenerEliminados());
            foreach (Categoria registro in categorias)
            {
                if (registro.Id != categoria.Id && String.Equals(registro.Nombre.Trim(), categoria.Nombre, StringComparison.OrdinalIgnoreCase))
                    errores["Nombre"] = "Ya existe una categoría con ese nombre, incluso en la papelera.";
            }

            int cantidad = 0;
            if (categoria.Id > 0)
                cantidad = _imagenes.ObtenerPorCategoria(categoria.Id).Count;
            if (rutasFotos != null)
            {
                if (cantidad + rutasFotos.Count > 5)
                    errores["Fotos"] = "La categoría puede tener un máximo de 5 fotos activas.";
                foreach (string ruta in rutasFotos)
                {
                    if (!Validador.ValidarImagen(ruta))
                        errores["Fotos"] = "Seleccione un archivo existente JPG, JPEG o PNG de máximo 2 MB.";
                }
            }
            if (errores.Count > 0)
                return errores;

            // Lee los archivos antes de insertar para evitar guardar si un archivo no se puede abrir.
            List<ImagenCategoria> fotos = new List<ImagenCategoria>();
            if (rutasFotos != null)
            {
                foreach (string ruta in rutasFotos)
                {
                    ImagenCategoria foto = new ImagenCategoria();
                    foto.Datos = File.ReadAllBytes(ruta);
                    fotos.Add(foto);
                }
            }

            if (categoria.Id == 0)
                categoria.Id = _repo.InsertarYObtenerId(categoria);
            else
                _repo.Actualizar(categoria);

            foreach (ImagenCategoria foto in fotos)
            {
                foto.IdCategoria = categoria.Id;
                _imagenes.Insertar(foto);
            }
            return errores;
        }

        /// <summary>
        /// Elimina la categoría si no tiene productos activos; vacío indica éxito.
        /// </summary>
        public string Eliminar(int id)
        {
            Categoria categoria = _repo.ObtenerPorId(id);
            if (categoria == null || !categoria.Activo)
                return "La categoría ya no está activa.";
            foreach (Productos producto in _productos.ObtenerTodos())
            {
                if (producto.IdCategoria == id)
                    return "No se puede eliminar la categoría porque tiene productos activos.";
            }
            _repo.Eliminar(id);
            return "";
        }

        /// <summary>
        /// Restaura la categoría; devuelve vacío si se pudo restaurar.
        /// </summary>
        public string Restaurar(int id)
        {
            Categoria categoria = _repo.ObtenerPorId(id);
            if (categoria == null)
                return "No se encontró la categoría.";
            _repo.Restaurar(id);
            return "";
        }

        /// <summary>
        /// Devuelve las categorías de la papelera.
        /// </summary>
        public List<Categoria> ObtenerEliminados()
        {
            return _repo.ObtenerEliminados();
        }

        /// <summary>
        /// Busca por parte del nombre o descripción sin distinguir mayúsculas.
        /// </summary>
        public List<Categoria> Buscar(string texto)
        {
            texto = texto.Trim();
            return _repo.ObtenerTodos().Where(categoria =>
                categoria.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                categoria.Descripcion.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Agrega una foto válida a una categoría activa; vacío indica éxito.
        /// </summary>
        public string AgregarFoto(int idCategoria, string ruta)
        {
            if (!Validador.ValidarImagen(ruta))
                return "Seleccione un archivo existente JPG, JPEG o PNG de máximo 2 MB.";
            Categoria categoria = _repo.ObtenerPorId(idCategoria);
            if (categoria == null || !categoria.Activo)
                return "Guarde una categoría activa antes de agregar fotos.";
            if (_imagenes.ObtenerPorCategoria(idCategoria).Count >= 5)
                return "La categoría ya tiene el máximo de 5 fotos activas.";

            ImagenCategoria foto = new ImagenCategoria();
            foto.IdCategoria = idCategoria;
            foto.Datos = File.ReadAllBytes(ruta);
            _imagenes.Insertar(foto);
            return "";
        }

        /// <summary>
        /// Quita una foto de la categoría mediante borrado lógico.
        /// </summary>
        public string QuitarFoto(int idCategoria, int idFoto)
        {
            ImagenCategoria foto = _imagenes.ObtenerPorId(idFoto);
            if (foto == null || foto.IdCategoria != idCategoria || !foto.Activo)
                return "No se encontró una foto activa de esa categoría.";
            _imagenes.Eliminar(idFoto);
            return "";
        }

        /// <summary>
        /// Devuelve las fotos activas de la categoría.
        /// </summary>
        public List<ImagenCategoria> ObtenerFotos(int idCategoria)
        {
            return _imagenes.ObtenerPorCategoria(idCategoria);
        }
    }
}
