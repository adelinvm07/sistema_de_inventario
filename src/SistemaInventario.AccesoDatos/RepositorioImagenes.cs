using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaInventario.AccesoDatos
{
    public class RepositorioImagen : RepositorioBase<ImagenCategoria>
    {
        protected override string NombreTabla { get { return "Imagenes"; } }

        protected override ImagenCategoria DeFilaAEntidad(SqlDataReader lector)
        {
            var i = new ImagenCategoria();
            i.Id = (int)lector["id"];
            i.Datos = (byte[])lector["datos"];
            i.FechaCreacion = (DateTime)lector["fecha_creacion"];
            i.FechaModificacion = (DateTime)lector["fecha_modificacion"];
            i.Activo = (bool)lector["activo"];

            return i;
        }

        public override void Insertar(ImagenCategoria imagen)
        {
            InsertarYObtenerId(imagen);
        }

        /// <summary>
        /// Inserta la imagen y devuelve el id que le asigno la base de datos.
        /// </summary>
        public int InsertarYObtenerId(ImagenCategoria imagen)
        {
            string insertar = "INSERT INTO Imagenes (datos) OUTPUT INSERTED.id VALUES (@datos)";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(insertar, conexion))
                    {
                        comando.Parameters.Add("@datos", SqlDbType.VarBinary, -1).Value = imagen.Datos;
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
        public override void Actualizar(ImagenCategoria imagen)
        {
            string actualizar = "UPDATE Imagenes SET datos = @datos, fecha_modificacion = GETDATE() WHERE id = @id";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(actualizar, conexion))
                    {
                        comando.Parameters.Add("@datos", SqlDbType.VarBinary, -1).Value = imagen.Datos;
                        comando.Parameters.AddWithValue("@id", imagen.Id);
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