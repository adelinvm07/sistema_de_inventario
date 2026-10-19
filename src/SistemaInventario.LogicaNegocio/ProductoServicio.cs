using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    public class ProductoServicio
    {
        private readonly IRepositorio<Productos> _repo;
        public ProductoServicio(IRepositorio<Productos> repo)
        {
            _repo = repo;
        }

        public List<Productos> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

    }
}
