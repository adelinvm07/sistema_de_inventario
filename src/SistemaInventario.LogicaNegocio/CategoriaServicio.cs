using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
    public class CategoriaServicio
    {
        private readonly IRepositorio<Categoria> _repo;

        public CategoriaServicio(IRepositorio<Categoria> repo)
        {
            _repo = repo;
        }

        public List<Categoria> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
