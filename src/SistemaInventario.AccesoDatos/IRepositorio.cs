using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    public interface IRepositorio<T>
    {
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        void Restaurar(int id);

    }
}
