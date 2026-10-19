using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    public interface IRepositorio<T>
    {
        List<T> ObtenerTodos();
        /// <summary>
        /// Devuelve los registros eliminados de forma lógica.
        /// </summary>
        List<T> ObtenerEliminados();
        T ObtenerPorId(int id);
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        void Restaurar(int id);

    }
}
