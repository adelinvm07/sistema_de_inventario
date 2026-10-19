using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;

namespace SistemaInventario.AccesoDatos
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorioCategoria
    {
        protected override string NombreTabla { get { return "Categorias"; } }
        protected override Categoria DeFilaAEntidad(SqlDataReader lector)
        {
            var c = new Categoria();
            c.Id = (int)lector["id"];
            c.Nombre = lector["nombre"].ToString();
            c.Descripcion = lector["descripcion"].ToString();
            c.FechaCreacion = (DateTime)lector["fecha_creacion"];
            c.FechaModificacion = (DateTime)lector["fecha_modificacion"];
            c.Activo = (bool)lector["activo"];

            return c;
        }
        public override void Insertar(Categoria categoria)
        {
            InsertarYObtenerId(categoria);
        }

        /// <summary>
        /// Inserta la categoría y devuelve el id asignado.
        /// </summary>
        public int InsertarYObtenerId(Categoria categoria)
        {
            string insertar = "INSERT INTO Categorias (nombre, descripcion) OUTPUT INSERTED.id VALUES (@nombre, @descripcion)";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(insertar, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                        comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                        return (int)comando.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }
        }
        public override void Actualizar(Categoria categoria)
        {
            string actualizar = "UPDATE Categorias SET nombre = @nombre, descripcion = @descripcion, " +
                "fecha_modificacion = GETDATE() WHERE id = @id";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(actualizar, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                        comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                        comando.Parameters.AddWithValue("@id", categoria.Id);
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