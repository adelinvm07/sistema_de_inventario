using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades.Utilidades;

namespace SistemaInventario.AccesoDatos
{
    public abstract class RepositorioBase<T> : IRepositorio<T>
    {
        protected abstract string NombreTabla { get; }
        protected abstract T DeFilaAEntidad(SqlDataReader lector);
        public abstract void Insertar(T entidad);
        public abstract void Actualizar(T entidad);
        public List<T> ObtenerTodos()
        {
            var lista = new List<T>();
            string querySelect = $"SELECT * FROM {NombreTabla} WHERE activo = 1";

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(querySelect, conexion))
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(DeFilaAEntidad(lector));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }

            return lista;
        }
        /// <summary>
        /// Devuelve los registros eliminados de forma lógica.
        /// </summary>
        public List<T> ObtenerEliminados()
        {
            var lista = new List<T>();
            string querySelect = $"SELECT * FROM {NombreTabla} WHERE activo = 0";

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(querySelect, conexion))
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(DeFilaAEntidad(lector));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }

            return lista;
        }
        public T ObtenerPorId(int id)
        {
            string sql = $"SELECT * FROM {NombreTabla} WHERE id = @id";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                                return DeFilaAEntidad(lector);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }
            return default(T);
        }
        public void Eliminar(int id)
        {
            CambiarActivo(id, 0);
        }
        public void Restaurar(int id)
        {
            CambiarActivo(id, 1);
        }
        public void CambiarActivo(int id, int valor)
        {
            string sql = $"UPDATE {NombreTabla} SET activo = @valor, fecha_modificacion = GETDATE() WHERE id = @id";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@valor", valor);
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }
        }
    }
}