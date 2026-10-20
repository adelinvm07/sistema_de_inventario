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
        /// Consulta los datos actuales de una categoría.
        /// </summary>
        public Categoria? ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        /// <summary>
        /// Devuelve los productos activos que pertenecen a la categoría.
        /// </summary>
        public List<Productos> ObtenerProductos(int idCategoria)
        {
            List<Productos> productos = new List<Productos>();
            foreach (Productos producto in _productos.ObtenerTodos())
            {
                if (producto.IdCategoria == idCategoria)
                    productos.Add(producto);
            }
            return productos;
        }

        /// <summary>
        /// Valida y guarda la categoría antes de guardar sus fotos nuevas.
        /// </summary>
        public Dictionary<string, string> Guardar(Categoria categoria, List<string>? rutasFotos = null, List<int>? idsFotosQuitar = null)
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
                    errores["Nombre"] = "Ya existe una categoría con ese nombre.";
            }

            int cantidad = 0;
            List<ImagenCategoria> fotosActuales = new List<ImagenCategoria>();
            if (categoria.Id > 0)
                fotosActuales = _imagenes.ObtenerPorCategoria(categoria.Id);
            cantidad = fotosActuales.Count;
            if (idsFotosQuitar != null)
            {
                foreach (int idFoto in idsFotosQuitar)
                {
                    bool encontrada = false;
                    foreach (ImagenCategoria foto in fotosActuales)
                    {
                        if (foto.Id == idFoto)
                            encontrada = true;
                    }
                    if (!encontrada)
                        errores["Fotos"] = "Una foto seleccionada ya no pertenece a esta categoría o fue eliminada. Abra nuevamente el formulario.";
                }
                foreach (ImagenCategoria foto in fotosActuales)
                {
                    if (idsFotosQuitar.Contains(foto.Id))
                        cantidad--;
                }
            }
            if (rutasFotos != null)
            {
                if (cantidad + rutasFotos.Count > 5)
                    errores["Fotos"] = "La categoría puede tener un máximo de 5 fotos activas.";
                foreach (string ruta in rutasFotos)
                {
                    if (!Validador.ValidarImagen(ruta))
                        errores["Fotos"] = Validador.ObtenerErrorImagen(ruta);
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

            if (idsFotosQuitar != null)
            {
                foreach (ImagenCategoria foto in fotosActuales)
                {
                    if (idsFotosQuitar.Contains(foto.Id))
                        QuitarFoto(categoria.Id, foto.Id);
                }
            }
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
        /// Revisa el archivo y el límite de fotos antes de mostrar una foto nueva.
        /// </summary>
        public string ValidarFoto(int idCategoria, string ruta, int cantidadNuevas, List<int>? idsFotosQuitar = null)
        {
            if (!Validador.ValidarImagen(ruta))
                return Validador.ObtenerErrorImagen(ruta);
            int cantidad = cantidadNuevas;
            if (idCategoria > 0)
            {
                foreach (ImagenCategoria foto in _imagenes.ObtenerPorCategoria(idCategoria))
                {
                    if (idsFotosQuitar == null || !idsFotosQuitar.Contains(foto.Id))
                        cantidad++;
                }
            }
            if (cantidad >= 5)
                return "La categoría puede tener un máximo de 5 fotos activas.";
            return "";
        }

        /// <summary>
        /// Agrega una foto válida a una categoría activa; vacío indica éxito.
        /// </summary>
        public string AgregarFoto(int idCategoria, string ruta)
        {
            string error = ValidarFoto(idCategoria, ruta, 0);
            if (error != "")
                return error;
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
