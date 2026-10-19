using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    public class SuplidorServicio
    {
        public readonly IRepositorio<Suplidores> _repo;
        public SuplidorServicio(IRepositorio<Suplidores> repo)
        {
            _repo = repo;
        }
        public List<Suplidores> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

    }
}
