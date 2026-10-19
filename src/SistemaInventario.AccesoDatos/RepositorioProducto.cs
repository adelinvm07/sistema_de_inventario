using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;

namespace SistemaInventario.AccesoDatos
{
    public class RepositorioProducto : RepositorioBase<Productos>
    {
        protected override string NombreTabla { get { return "Productos"; } }

        protected override Productos DeFilaAEntidad(SqlDataReader lector)
        {
            var p = new Productos();
            p.Id = (int)lector["id"];
            p.IdCategoria = (int)lector["categoria_id"];
            p.IdSuplidor = (int)lector["suplidor_id"];
            p.Nombre = lector["nombre"].ToString();
            p.PrecioUnitario = (decimal)lector["precio_unitario"];
            p.FechaCreacion = (DateTime)lector["fecha_creacion"];
            p.FechaModificacion = (DateTime)lector["fecha_modificacion"];
            p.Activo = (bool)lector["activo"];

            return p;
        }
        public override void Insertar(Productos producto)
        {
            string insertar = "INSERT INTO Productos (categoria_id, suplidor_id, nombre, precio_unitario) " +
                "VALUES (@categoria_id, @suplidor_id, @nombre, @precio_unitario)";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(insertar, conexion))
                    {
                        comando.Parameters.AddWithValue("@categoria_id", producto.IdCategoria);
                        comando.Parameters.AddWithValue("@suplidor_id", producto.IdSuplidor);
                        comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@precio_unitario", producto.PrecioUnitario);
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
        public override void Actualizar(Productos producto)
        {
            string actualizar = "UPDATE Productos SET categoria_id = @categoria_id, suplidor_id = @suplidor_id, nombre = @nombre, " +
                "precio_unitario = @precio_unitario, fecha_modificacion = GETDATE() WHERE id = @id";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(actualizar, conexion))
                    {
                        comando.Parameters.AddWithValue("@categoria_id", producto.IdCategoria);
                        comando.Parameters.AddWithValue("@suplidor_id", producto.IdSuplidor);
                        comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@precio_unitario", producto.PrecioUnitario);
                        comando.Parameters.AddWithValue("@id", producto.Id);
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